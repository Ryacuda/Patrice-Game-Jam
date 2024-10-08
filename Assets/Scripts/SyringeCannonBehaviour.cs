using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeCannonBehaviour : MonoBehaviour
{
    public GameObject projectile;
    public float shootStartDistance;
    public float cannonPower;
	public int maxAmmo;
	public bool mute;

	int currentAmmo;
    CannonBehaviour CBComponent;
	Sprite ammoSprite;
	List<GameObject> ammoList;
	LevelOneAudioManager audioManager;


	// Start is called before the first frame update
	void Start()
    {
		CBComponent = GetComponent<CannonBehaviour>();
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<LevelOneAudioManager>();

		currentAmmo = maxAmmo;

		ammoSprite = projectile.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite;

		ammoList = new List<GameObject>();
		for(int i = 0; i < maxAmmo; i++)
		{
			GameObject go = new GameObject();
			go.transform.parent = transform.Find("Barrel");
			go.transform.localScale = 0.5f * Vector3.one;
			go.transform.localPosition = new Vector3(-0.6f + (float)i * 1.4f / maxAmmo, 0f, 0f); 
			go.name = "ammo_" + i;

			SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
			sr.material = transform.Find("Barrel").GetComponent<SpriteRenderer>().material;
			sr.sprite = ammoSprite;
			sr.sortingOrder = i;

			ammoList.Add(go);
		}
    }

	// Update is called once per frame
	void Update()
    {
		if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
			Shoot();
        }
	}

	void Shoot()
	{
		Vector3 shoot_dir = new Vector3(Mathf.Cos(CBComponent.barrelAngle),
										Mathf.Sin(CBComponent.barrelAngle),
										0);

		// create a projectile and play SFX
		GameObject proj = Instantiate(projectile, transform.position + shootStartDistance * shoot_dir, Quaternion.identity);
		proj.transform.localScale *= 0.7f;
		proj.GetComponent<Rigidbody2D>().velocity = cannonPower * shoot_dir;
		if(!mute) audioManager.PlayShotSFX();

		// expand ammo
		currentAmmo--;

		// update display
		transform.Find("Barrel/Piston").Translate(new Vector3(0.7f / (float)maxAmmo, 0f, 0f));
		Destroy(ammoList[0]);
		ammoList.RemoveAt(0);

		// update endgame conditions
		if(currentAmmo == 0)
		{
			GameObject.FindAnyObjectByType<LevelOneGameManager>().noAmmo = true;
		}
	}

	/*
	private void OnDrawGizmos()
	{
		// gizmo cannon direction
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position + shootStartDistance *  Vector3.right, 0.05f);
	}
	*/
}

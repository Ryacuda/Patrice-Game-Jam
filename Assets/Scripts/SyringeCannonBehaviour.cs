using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeCannonBehaviour : MonoBehaviour
{
    public GameObject projectile;
    public float shootStartDistance;
    public float cannonPower;
	public int maxAmmo;

	int currentAmmo;
    CannonBehaviour CBComponent;
	Sprite ammoSprite;


	// Start is called before the first frame update
	void Start()
    {
		CBComponent = GetComponent<CannonBehaviour>();

		currentAmmo = maxAmmo;
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

		// create a projectile
		GameObject proj = Instantiate(projectile, transform.position + shootStartDistance * shoot_dir, Quaternion.identity);
		proj.transform.localScale *= 0.66f;
		proj.GetComponent<Rigidbody2D>().velocity = cannonPower * shoot_dir;

		// expand ammo
		currentAmmo--;

		// update display
		transform.Find("Barrel/Piston").Translate(new Vector3(0.7f / (float)maxAmmo, 0f, 0f));

	}

	private void OnDrawGizmos()
	{
		// gizmo cannon direction
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position + shootStartDistance *  Vector3.right, 0.05f);
	}
}

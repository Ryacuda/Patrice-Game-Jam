using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSingleShot : MonoBehaviour
{
    public GameObject projectile;
    public float shootStartDistance;
    public float cannonPower;

    CannonBehaviour CBComponent;


    // Start is called before the first frame update
    void Start()
    {
        CBComponent = GetComponent<CannonBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
        {   // shoot
            Vector3 shoot_dir = new Vector3(Mathf.Cos(CBComponent.barrelAngle),
                                            Mathf.Sin(CBComponent.barrelAngle),
                                            0);

            GameObject proj = Instantiate(projectile, transform.position + shootStartDistance * shoot_dir, Quaternion.Euler(0f,0f, CBComponent.barrelAngle));

            proj.GetComponent<Rigidbody2D>().velocity = cannonPower * shoot_dir;
        }
	}
}

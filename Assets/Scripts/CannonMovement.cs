using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour
{
	public float barrelAngle;                             // radians

	private Transform barrelTransform;

	// Start is called before the first frame update
	void Start()
    {
		barrelTransform = transform.Find("Barrel");
	}

    // Update is called once per frame
    void Update()
    {
		UpdateDirection();
	}

	void UpdateDirection()
	{
		Vector3 vec_direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

		barrelAngle = Mathf.Atan2(vec_direction.y, vec_direction.x);

		if (barrelTransform != null)
		{
			barrelTransform.rotation = Quaternion.Euler(0f, 0f, barrelAngle * 180 / Mathf.PI);
		}
	}

	private void OnDrawGizmos()
	{
		// gizmo cannon direction
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position + new Vector3(Mathf.Cos(barrelAngle), Mathf.Sin(barrelAngle), 0));
	}
}

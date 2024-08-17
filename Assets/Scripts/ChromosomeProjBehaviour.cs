using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChromosomeType { Creativity, Intelligence, Strength };

public class ChromosomeProjBehaviour : MonoBehaviour
{
    public ChromosomeType chromType;
    float rotationSpeed;                    // rotation speed in rad per second

	// Start is called before the first frame update
	void Start()
    {
        rotationSpeed = 2 + Random.value * 8;       // rot speed [2, 10]
		Destroy(gameObject, 10);                    // destroy after 10s
	}

    // Update is called once per frame
    void Update()
    {
        transform.Find("Sprite").Rotate(new Vector3(0f, 0f, Time.deltaTime * rotationSpeed * 180 / Mathf.PI));
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		CharacterTargetBehaviour hitChar = collision.gameObject.GetComponent<CharacterTargetBehaviour>();

        if(hitChar != null)
        {
            hitChar.IncrementStat(chromType);
            Destroy(gameObject);
        }
	}
}

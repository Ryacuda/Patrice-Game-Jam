using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChromosomeType { Creativity, Intelligence, Strength };

public class ChromosomeProjBehaviour : MonoBehaviour
{
    public static int chromosomeCount;
    public ChromosomeType chromType;
    float rotationSpeed;                    // rotation speed in rad per second

	// Start is called before the first frame update
	void Start()
    {
        rotationSpeed = 2 + Random.value * 8;       // rot speed [2, 10]
        if(Random.value > 0)
        {
            rotationSpeed *= -1;
        }

		Destroy(gameObject, 5);                    // destroy after 10s
        chromosomeCount++;
		LevelOneGameManager gm = FindObjectOfType<LevelOneGameManager>();
		gm.gameResolved = false;
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

	private void OnDestroy()
	{
		chromosomeCount--;
        if( chromosomeCount == 0 )
        {
			LevelOneGameManager gm = FindObjectOfType<LevelOneGameManager>();
			gm.gameResolved = true;
			gm.TryEndgameUI();
		}
	}
}

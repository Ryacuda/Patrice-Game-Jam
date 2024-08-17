using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTargetBehaviour : MonoBehaviour
{
    public int statInt;
	public int statStr;
	public int statCrea;

    Transform spriteTransform;
    static float FXDuration = 0.5f;
    static float scaleFactor = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
		spriteTransform = transform.Find("Sprite");
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
    }

    public void IncrementStat(ChromosomeType chromType)
    {
        Color color;

        switch(chromType)
        {
            case ChromosomeType.Intelligence:
                statInt++;
                color = Color.blue;
                break;

            case ChromosomeType.Creativity:
                color = Color.green;
                statCrea++; break;

            case ChromosomeType.Strength:
                color = Color.red;
                statStr++; break;

            default:
                color = Color.white;
                break;
        }

        StartCoroutine(StatIncreaseFX(color));
    }

    private IEnumerator StatIncreaseFX(Color color)
    {
        float elapsed_time = 0.0f;
        // bouncy & color flash
        while (elapsed_time < FXDuration)
        {
            float x = elapsed_time * Mathf.PI * 3 / FXDuration;
            float f = scaleFactor * (2 * Mathf.Sin(x / 3) + Mathf.Sin(x));

			spriteTransform.localScale = (1 + f) * Vector3.one;
            spriteTransform.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white + 3 * new Color(f * color.r, f* color.g, f*color.b) ;

			elapsed_time += Time.deltaTime;

			yield return null;
        }

        // reset scale to starting scale
        spriteTransform.localScale = Vector3.one;
		spriteTransform.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;

		yield return null;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		
	}
}

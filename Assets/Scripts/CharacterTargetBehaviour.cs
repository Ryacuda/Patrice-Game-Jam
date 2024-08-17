using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTargetBehaviour : MonoBehaviour
{
    public int statInt;
	public int statStr;
	public int statCrea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
    }

    public void IncrementStat(ChromosomeType chromType)
    {
        switch(chromType)
        {
            case ChromosomeType.Intelligence:
                statInt++; break;

            case ChromosomeType.Creativity:
                statCrea++; break;

            case ChromosomeType.Strength:
                statStr++; break;

            default:
                break;
        }
    }
}

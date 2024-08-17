using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text textUI;

    // Update is called once per frame
    void Update()
    {
        textUI.text = ChromosomeProjBehaviour.chromosomeCount.ToString();
    }
}

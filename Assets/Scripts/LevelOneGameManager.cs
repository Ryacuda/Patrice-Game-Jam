using UnityEngine;
using UnityEngine.UI;

public class LevelOneGameManager : MonoBehaviour
{
    public bool noAmmo;
    public bool gameResolved;

    public GameObject startUI;

    SyringeCannonBehaviour[] syringes;

	private void Start()
	{
		syringes = GameObject.FindObjectsOfType<SyringeCannonBehaviour>();

        foreach(SyringeCannonBehaviour s in syringes)
        {
            s.enabled = false;
        }
	}

    public void StartGame()
    {
        startUI.SetActive(false);
		foreach (SyringeCannonBehaviour s in syringes)
		{
			s.enabled = true;
		}
	}

	public void TryEndgameUI()
    {
        if(noAmmo && gameResolved)
        {
            //scoreUI.enabled = false;
        }
    }
}

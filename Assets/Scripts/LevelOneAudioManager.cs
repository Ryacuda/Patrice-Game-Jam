using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneAudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource SFXSource;

    public AudioClip music;
	public List<AudioClip> shotSFX = new List<AudioClip>();

	// Start is called before the first frame update
	void Start()
    {
        musicSource.clip = music;
        musicSource.Play();
    }

    public void PlayShotSFX()
    {
        int sfx_index = Random.Range(0, shotSFX.Count);
        SFXSource.PlayOneShot(shotSFX[sfx_index]);
    }
}

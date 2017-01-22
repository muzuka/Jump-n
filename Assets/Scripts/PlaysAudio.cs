using UnityEngine;

public class PlaysAudio : MonoBehaviour {

	void OnTriggerEnter ()
	{
		GetComponent<AudioSource>().Play();
	}
}

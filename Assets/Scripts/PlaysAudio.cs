using UnityEngine;

public class PlaysAudio : MonoBehaviour {

	void OnTriggerEnter ()
	{
		AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
	}
}

using UnityEngine;

public class ButtonPress : MonoBehaviour {

	public AudioSource pressSound;

	public void playSound ()
	{
		pressSound.Play();
	}
}

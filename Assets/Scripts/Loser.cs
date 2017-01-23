using UnityEngine;

public class Loser : MonoBehaviour {

	public AudioSource loseSound;
	public Transform pit;
	public Transform behind;

	void Update () 
	{
		if(transform.position.y <= pit.position.y || transform.position.x <= behind.position.x)
		{
			loseSound.Play();
			FindObjectOfType<GUIController>().lostGame();
		}
	}
}

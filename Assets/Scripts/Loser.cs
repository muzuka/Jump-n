using UnityEngine;

public class Loser : MonoBehaviour {

	public Transform pit;
	public Transform behind;

	void Update () 
	{
		if(transform.position.y <= pit.position.y || transform.position.x <= behind.position.x)
			FindObjectOfType<GUIController>().lostGame();
	}
}

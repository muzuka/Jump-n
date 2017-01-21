using UnityEngine;

public class SetToEdge : MonoBehaviour {

	void Update () 
	{
		transform.position = FindObjectOfType<Camera>().ScreenToWorldPoint(new Vector3(0.0f, Screen.height/2, 0.0f));
	}
}

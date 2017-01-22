using UnityEngine;

public class SetToEdge : MonoBehaviour {

	public bool left;

	void Update () 
	{
		if(left)
			transform.position = FindObjectOfType<Camera>().ScreenToWorldPoint(new Vector3(0.0f, Screen.height/2, 0.0f));
		else
			transform.position = FindObjectOfType<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height/2, 0.0f));
	}
}

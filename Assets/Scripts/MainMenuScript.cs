using UnityEngine;
using UnityEditor.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public bool debug;

	public void startGame ()
	{
		EditorSceneManager.LoadScene("MainLevel");
	}

	public void quitGame ()
	{
		if(debug)
			UnityEditor.EditorApplication.isPlaying = false;
		else
			Application.Quit();
	}
}

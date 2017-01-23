using UnityEngine;

public class MainMenuScript : MonoBehaviour {

	public void startGame ()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainLevel");
	}

	public void quitGame ()
	{
		Application.Quit();
	}
}

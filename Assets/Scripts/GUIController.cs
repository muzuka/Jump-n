using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

	public Image loseMenu;
	public Image pauseMenu;

	bool paused;

	void Start () 
	{
		paused = false;
		pauseMenu.gameObject.SetActive(false);
		loseMenu.gameObject.SetActive(false);
	}

	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			paused = !paused;
			if(paused)
				Time.timeScale = 0.0f;
			else
				Time.timeScale = 1.0f;
			pauseMenu.gameObject.SetActive(paused);
		}
	}

	public void resumeGame ()
	{
		Time.timeScale = 1.0f;
		pauseMenu.gameObject.SetActive(false);
	}

	public void restartGame ()
	{
		paused = false;
		loseMenu.gameObject.SetActive(false);
		pauseMenu.gameObject.SetActive(false);
	}

	public void lostGame ()
	{
		loseMenu.gameObject.SetActive(true);
	}
}

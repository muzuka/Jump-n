using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

	public Image loseMenu;
	public Image pauseMenu;
	public Text timer;

	float currentTime;

	bool paused;

	void Start () 
	{
		currentTime = 0.0f;
		timer.text = currentTime.ToString();

		paused = false;
		pauseMenu.gameObject.SetActive(false);
		loseMenu.gameObject.SetActive(false);
	}

	void Update ()
	{
		currentTime += Time.deltaTime;
		timer.text = currentTime.ToString();

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
		currentTime = 0.0f;
		paused = false;
		loseMenu.gameObject.SetActive(false);
		pauseMenu.gameObject.SetActive(false);
	}

	public void lostGame ()
	{
		loseMenu.gameObject.SetActive(true);
	}
}

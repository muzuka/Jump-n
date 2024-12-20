﻿using UnityEngine;

public class RunsLevel : MonoBehaviour {

	public GameObject player;

	public Transform behind;

	public float speed;

	void Awake ()
	{
		Time.timeScale = 1.0f;
	}

	void Update ()
	{
		BoxCollider2D[] bodies = FindObjectsOfType<BoxCollider2D>();

		for(int i = 0; i < bodies.Length; i++)
		{
			if(bodies[i].tag == "Tile")
			{
				bodies[i].transform.Translate(new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f));

				if(!GetComponent<LevelBuilder>().infinite)
				{
					if(bodies[i].transform.position.x <= behind.position.x - 5)
						Destroy(bodies[i]);
				}
			}
		}
	}

	public void restartGame ()
	{
		BoxCollider2D[] bodies = FindObjectsOfType<BoxCollider2D>();

		for(int i = 0; i < bodies.Length; i++)
		{
			if(bodies[i].tag == "Tile")
				Destroy(bodies[i].gameObject);
		}

		Time.timeScale = 1.0f;

		player.GetComponent<Moveable>().restartGame();
		GetComponent<LevelBuilder>().restartGame();
		GetComponent<GUIController>().restartGame();
	}

	public void quitGame ()
	{
		//Application.Quit();
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}
}

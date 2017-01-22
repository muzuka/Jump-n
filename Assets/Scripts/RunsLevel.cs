using UnityEngine;

public class RunsLevel : MonoBehaviour {

	public bool debug;

	public GameObject player;

	public Transform behind;

	public float speed;

	void Awake () 
	{
		Random.InitState((int)System.DateTime.Now.Ticks);
	}

	void Update ()
	{
		BoxCollider2D[] bodies = FindObjectsOfType<BoxCollider2D>();

		for(int i = 0; i < bodies.Length; i++)
		{
			if(bodies[i].tag == "Tile")
			{
				bodies[i].transform.Translate(new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f));

				if(bodies[i].transform.position.x <= behind.position.x - 5)
					Destroy(bodies[i]);
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
		if(debug)
			UnityEditor.EditorApplication.isPlaying = false;
		else
			Application.Quit();
	}
}

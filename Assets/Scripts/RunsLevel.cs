using UnityEngine;

public class RunsLevel : MonoBehaviour {

	public GameObject player;

	public Transform behind;

	public float speed;

	void Update ()
	{
		GameObject[] bodies = FindObjectsOfType<GameObject>();

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
		player.GetComponent<Moveable>();
		GetComponent<LevelBuilder>().restartGame();
		GetComponent<GUIController>().restartGame();
	}
}

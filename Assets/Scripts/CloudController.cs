using UnityEngine;

public class CloudController : MonoBehaviour {

	public Camera camera;
	public Transform forwardBoundary;
	public Transform behindBoundary;

	GameObject[] realClouds = {null, null, null, null};
	GameObject[] clouds;
	float[] timesToRelease = {5.0f, 2.0f, 7.0f, 10.0f};
	float[] timers = {0.0f, 0.0f, 0.0f, 0.0f};


	// Use this for initialization
	void Start () 
	{
		clouds = new GameObject[4];
		clouds[0] = Resources.Load<GameObject>("Prefabs/CloudSmall");
		clouds[1] = Resources.Load<GameObject>("Prefabs/CloudSmall2");
		clouds[2] = Resources.Load<GameObject>("Prefabs/CloudMedium");
		clouds[3] = Resources.Load<GameObject>("Prefabs/CloudLarge");
	}
	
	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i < 4; i++)
		{
			timers[i] += Time.deltaTime;
			if(timers[i] >= timesToRelease[i])
			{
				releaseCloud(i);
				timers[i] = 0.0f;
			}

			if(realClouds[i] != null)
			{
				realClouds[i].transform.Translate(-7.0f * Time.deltaTime, 0.0f, 0.0f);

				if(realClouds[i].transform.position.x < behindBoundary.position.x - 5.0f)
				{
					Destroy(realClouds[i]);
				}
			}
		}
	}

	void releaseCloud (int i) {
		float height = Random.Range(camera.ScreenToWorldPoint(new Vector2(0.0f, 0.0f)).y, camera.ScreenToWorldPoint(new Vector2(0.0f, Screen.height)).y);

		realClouds[i] = Instantiate(clouds[i], new Vector2(forwardBoundary.position.x + 5.0f, height), Quaternion.identity);
	}
}

using UnityEngine;

public class Platform {

	public int height { get; set; }
	public int width { get; set; }
	public GameObject[] tiles { get; set; }
	public GameObject top { get; set; }
	public GameObject left { get; set; }
	public GameObject right { get; set; }

	public Platform (int h)
	{
		height = h;
		tiles = new GameObject[6];
		top = null;
		left = null;
		right = null;

		//top.GetComponent<AudioSource>().clip = Resources.Load<GameObject>("Prefabs/Notes/Note" + height).GetComponent<AudioSource>().clip;
	}
}

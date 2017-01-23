using UnityEngine;

public class Platform {

	public int height { get; set; }
	public int width { get; set; }
	public GameObject[] tiles { get; set; }
	public GameObject[] tops { get; set; }
	public GameObject left { get; set; }
	public GameObject right { get; set; }

	public Platform (int h, int w)
	{
		height = h;
		width = w;
		tiles = new GameObject[6*width];
		tops = new GameObject[width];
		left = null;
		right = null;
	}

	public Vector2 getPosition ()
	{
		float xSum = 0.0f;
		float ySum = 0.0f;

		foreach(GameObject t in tiles)
		{
			if(t != null)
			{
				xSum += t.transform.position.x;
				ySum += t.transform.position.y;
			}
		}

		return new Vector2(xSum / tiles.Length, ySum / tiles.Length);
	}

	public void destroy ()
	{
		foreach(GameObject g in tiles)
			Object.Destroy(g);
		foreach(GameObject t in tops)
			Object.Destroy(t);
		Object.Destroy(left);
		Object.Destroy(right);
	}
}

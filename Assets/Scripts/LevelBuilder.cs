using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {

	//public List<int> level;
	public int level;

	public Vector2 start;

	public Vector2 moveRight;
	public Vector2 moveUp;

	Vector2 current;

	void Awake ()
	{
		current = start;

		buildLevel(new Level(level));
	}

	public void restartGame ()
	{
		buildLevel(new Level(level));
	}

	public void buildLevel (Level l)
	{
		for(int i = 0; i < l.sequence.Count; i++)
		{
			for(int h = 0; h < l.sequence[i]; h++)
			{
				Instantiate(Resources.Load("Prefabs/PlatformTile"), current, Quaternion.identity); 
				current += moveUp;
			}

			current += moveRight;
			current.y = start.y;
		}
	}
}

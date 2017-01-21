using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {

	public List<int> level;

	public Vector2 start;

	public Vector2 moveRight;
	public Vector2 moveUp;

	Vector2 current;

	void Start ()
	{
		current = start;

		buildLevel(new Level(level));
	}

	public void buildLevel (Level l)
	{
		for(int i = 0; i < l.sequence.Count; i++)
		{
			current += moveRight;
			current.y = start.y;

			if(l.sequence[i] > 1)
			{
				for(int h = 0; h < l.sequence[i]; h++)
				{
					Instantiate(Resources.Load("Prefabs/PlatformTile"), current, Quaternion.identity); 
					current += moveUp;
				}

				//current += new Vector2(0.0f, 0.11f);
			}
		}
	}
}

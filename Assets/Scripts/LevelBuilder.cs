using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {

	//public List<int> level;
	public int level;

	public Vector2 start;

	public Vector2 moveRight;
	public Vector2 moveUp;
	public Vector2 addTop;
	public Vector2 addEnd;

	Vector2 current;

	void Awake ()
	{
		current = start;

		buildLevel(new Level(level));
	}

	public void restartGame ()
	{
		current = start;

		buildLevel(new Level(level));
	}

	public void buildLevel (Level l)
	{
		for(int i = 0; i < l.sequence.Count; i++)
		{
			for(int h = 0; h < l.sequence[i]; h++)
			{
				float tile = Random.Range(0.0f, 3.0f);

				if(tile <= 1.0f)
					Instantiate(Resources.Load("Prefabs/PlatformTile"), current, Quaternion.identity); 
				else if(tile <= 2.0f)
					Instantiate(Resources.Load("Prefabs/PlatformTile2"), current, Quaternion.identity); 
				else if(tile <= 3.0f)
					Instantiate(Resources.Load("Prefabs/PlatformTile3"), current, Quaternion.identity); 
				
				current += moveUp;
			}

			if(l.sequence[i] != 0)
			{
				Instantiate(Resources.Load("Prefabs/PlatformTop"), current + addTop, Quaternion.identity);
				Instantiate(Resources.Load("Prefabs/PlatformLeftEnd"), current + addTop - addEnd, Quaternion.identity);
				Instantiate(Resources.Load("Prefabs/PlatformRightEnd"), current + addTop + addEnd, Quaternion.identity); 
			}

			current += moveRight;
			current.y = start.y;
		}
	}
}

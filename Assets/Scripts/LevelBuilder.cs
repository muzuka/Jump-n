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
	InfiniteLevel infLevel;

	void Awake ()
	{
		current = start;

		if(infinite)
		{
			infLevel = new InfiniteLevel(platforms);
			buildLevel(infLevel);
		}
		buildLevel(new Level(platforms));
	}

	void Update ()
	{
		if(infinite)
		{
			if(infLevel.needsPlatform())
			{
				infLevel.newPlatform();
				buildPlatform(infLevel.sequence.Peek());
			}
			else if(infLevel.tooManyPlatforms())
			{
				
			}
		}
	}

	public void restartGame ()
	{
		current = start;

		if(infinite)
		{
			infLevel.sequence.Clear();
			buildLevel(infLevel);
		}
		else
			buildLevel(new Level(platforms));
	}

	public void buildLevel (InfiniteLevel l)
	{
		while(l.needsPlatform()) {
			l.newPlatform();
			buildPlatform(l.sequence.Peek());
		}
	}

	public void buildLevel (Level l)
	{
		for(int i = 0; i < l.sequence.Count; i++)
		{
			buildPlatform(l.sequence[i]);
		}
	}

	Platform buildPlatform (int height)
	{
		Platform p = new Platform(height);

		for(int h = 0; h < height; h++)
		{
			float tile = Random.Range(0.0f, 3.0f);

			if(tile <= 1.0f)
				Instantiate(Resources.Load("Prefabs/Platforms/PlatformTile"), current, Quaternion.identity); 
			else if(tile <= 2.0f)
				Instantiate(Resources.Load("Prefabs/Platforms/PlatformTile2"), current, Quaternion.identity); 
			else if(tile <= 3.0f)
				Instantiate(Resources.Load("Prefabs/Platforms/PlatformTile3"), current, Quaternion.identity); 

			current += moveUp;
		}

		if(height != 0)
		{
			Instantiate(Resources.Load("Prefabs/Platforms/PlatformTop"), current + addTop, Quaternion.identity);
			Instantiate(Resources.Load("Prefabs/Platforms/PlatformLeftEnd"), current + addTop - addEnd, Quaternion.identity);
			Instantiate(Resources.Load("Prefabs/Platforms/PlatformRightEnd"), current + addTop + addEnd, Quaternion.identity); 
		}

		current += moveRight;
		current.y = start.y;

		return p;
	}
}

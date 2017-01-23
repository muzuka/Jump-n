using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {

	//public List<int> platforms;
	public int platforms;

	public bool infinite;

	public Vector2 start;

	public Vector2 moveRight;
	public Vector2 moveUp;
	public Vector2 addTop;
	public Vector2 addEnd;

	public Transform behindBoundary;

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
		else 
		{
			buildLevel(new Level(platforms));
		}
	}

	void Update ()
	{
		if(infinite)
		{
			float speed = GetComponent<RunsLevel>().speed;
			current -= new Vector2(speed * Time.deltaTime, 0.0f);

			if(infLevel.needsPlatform())
			{
				Debug.Log("Built new platform");

				infLevel.newPlatform();
			}
			else if(infLevel.tooManyPlatforms())
			{
				infLevel.sequence.Dequeue().destroy();
			}

			if(infLevel.sequence.Peek().right.transform.position.x < behindBoundary.position.x)
			{

				infLevel.sequence.Dequeue().destroy();

				infLevel.newPlatform();
				buildPlatform(infLevel.getLast());
			}
		}
	}

	public void restartGame ()
	{
		current = start;

		if(infinite)
		{
			infLevel = new InfiniteLevel(platforms);
			buildLevel(infLevel);
		}
		else
			buildLevel(new Level(platforms));
	}

	public void buildLevel (InfiniteLevel l)
	{
		while(l.needsPlatform()) 
		{
			l.newPlatform();
			buildPlatform(l.getLast());
		}
	}

	public void buildLevel (Level l)
	{
		for(int i = 0; i < l.sequence.Count; i++)
			buildPlatform(l.sequence[i]);
	}

	void buildPlatform (int height)
	{
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
	}

	void buildPlatform (Platform p)
	{
		for(int w = 0; w < p.width; w++)
		{
			for(int h = 0; h < p.height; h++)
			{
				float tile = Random.Range(0.0f, 3.0f);

				if(tile <= 1.0f)
					p.tiles[(p.width * h) + w] = (GameObject)Instantiate(Resources.Load("Prefabs/Platforms/PlatformTile"), current, Quaternion.identity); 
				else if(tile <= 2.0f)
					p.tiles[(p.width * h) + w] = (GameObject)Instantiate(Resources.Load("Prefabs/Platforms/PlatformTile2"), current, Quaternion.identity); 
				else if(tile <= 3.0f)
					p.tiles[(p.width * h) + w] = (GameObject)Instantiate(Resources.Load("Prefabs/Platforms/PlatformTile3"), current, Quaternion.identity); 

				current += moveUp;
			}
				
			p.tops[w] = (GameObject)Instantiate(Resources.Load("Prefabs/Platforms/PlatformTop"), current + addTop, Quaternion.identity);

			if(w == 0)
				p.left = (GameObject)Instantiate(Resources.Load("Prefabs/Platforms/PlatformLeftEnd"), current + addTop - addEnd, Quaternion.identity);
			if(w == p.width - 1)
				p.right = (GameObject)Instantiate(Resources.Load("Prefabs/Platforms/PlatformRightEnd"), current + addTop + addEnd, Quaternion.identity); 


			current += moveRight;
			current.y = start.y;
		}

		buildPlatform(0);
	}
}

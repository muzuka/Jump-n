using System.Collections.Generic;
using UnityEngine;


public class InfiniteLevel {

	public Queue<Platform> sequence { get; set; }

	int idealAmount;

	public InfiniteLevel ()
	{
		Random.InitState((int)System.DateTime.Now.Ticks);

		sequence = new Queue<Platform>();
		idealAmount = 50;
	}

	public InfiniteLevel (int id)
	{
		Random.InitState((int)System.DateTime.Now.Ticks);

		sequence = new Queue<Platform>();
		idealAmount = id;
	}

	public InfiniteLevel (Platform[] l, int id)
	{
		Random.InitState((int)System.DateTime.Now.Ticks);

		sequence = new Queue<Platform>();
		idealAmount = id;
		foreach(Platform i in l)
			sequence.Enqueue(i);
	}

	public InfiniteLevel (List<Platform> l, int id)
	{
		Random.InitState((int)System.DateTime.Now.Ticks);

		sequence = new Queue<Platform>();
		idealAmount = id;
		foreach(Platform i in l)
			sequence.Enqueue(i);
	}

	public bool needsPlatform ()
	{
		return sequence.Count < idealAmount;
	}

	public bool tooManyPlatforms ()
	{
		return sequence.Count > idealAmount;
	}

	public bool justRight ()
	{
		return sequence.Count == idealAmount;
	}

	public void newPlatform()
	{
		Random.InitState((int)System.DateTime.Now.Ticks);

		if(sequence.Count == 0)
			sequence.Enqueue(new Platform(2, 4));
		else if(sequence.Count == 1)
			sequence.Enqueue(new Platform(2, 2));
		else
		{
			int width = (int)System.Math.Round(Random.Range(1.0f, 2.0f));
			Platform[] array = sequence.ToArray();
			int i = array.Length - 1;

			// if last platform was maximum height
			if(array[i-1].height == 5)
				sequence.Enqueue(new Platform((int)Random.Range(1.0f, array[i-1].height), width));
			else
			{
				int rand = (int)Random.Range(1.0f, array[i-1].height + 2);
				var temp = new Platform(rand, width);
				sequence.Enqueue(temp);
			}
		}
	}

	public Platform getLast ()
	{
		Platform[] temp = sequence.ToArray();

		return temp[temp.Length - 1];
	}
}

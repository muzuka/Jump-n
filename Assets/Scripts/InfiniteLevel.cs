using System.Collections.Generic;


public class InfiniteLevel {

	public Queue<int> sequence { get; set; }


	int idealAmount;

	public InfiniteLevel ()
	{
		sequence = new Queue<int>();
		idealAmount = 50;
	}

	public InfiniteLevel (int id)
	{
		sequence = new Queue<int>();
		idealAmount = id;
	}

	public InfiniteLevel (int[] l, int id)
	{
		sequence = new Queue<int>();
		idealAmount = id;
		foreach(int i in l)
			sequence.Enqueue(i);
	}

	public InfiniteLevel (List<int> l, int id)
	{
		sequence = new Queue<int>();
		idealAmount = id;
		foreach(int i in l)
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

	public void newPlatform()
	{
		if(sequence.Count == 0)
			sequence.Enqueue(2);
		else if(sequence.Count == 1)
			sequence.Enqueue(2);
		else if(sequence.Count == 2)
			sequence.Enqueue(2);
		else if(sequence.Count == 3)
			sequence.Enqueue(2);
		else
		{
			int i = 0;
			int[] array = sequence.ToArray();

			if(array[i-1] != 0 && array[i-2] != 0)
				sequence.Enqueue(0);
			else if(array[i-1] == 0)
			{
				if(array[i-2] == 6)
					sequence.Enqueue((int)UnityEngine.Random.Range(1.0f, array[i-2]));
				else
					sequence.Enqueue((int)UnityEngine.Random.Range(1.0f, array[i-2] + 2));
			}
			else if(array[i-1] != 0)
			{
				if((int)System.Math.Round(UnityEngine.Random.value) == 1)
					sequence.Enqueue(0);
				else
					sequence.Enqueue(array[i-1]);
			}
		}
	}

}

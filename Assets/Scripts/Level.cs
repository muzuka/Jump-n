using System.Collections.Generic;

public class Level {

	public List<int> sequence { get; set; }

	public Level ()
	{
		sequence = new List<int>();
	}

	public Level (List<int> l)
	{
		sequence = l;
	}

	public Level (int[] l)
	{
		foreach(int i in l)
			sequence.Add(i);
	}

	public Level (int l)
	{
		sequence = new List<int>();
		generateSequence(l);
	}

	public void generateSequence (int length)
	{
		/*
		 *	For each unit
		 *		Look behind
		 *		if first unit
		 *			place h2
		 *		else if second unit
		 *			place h2
		 *		else
		 *			if last two are not h0
		 *				place h0
		 *			else if last unit is h0
		 *				set height to random
		 *			else if last is not h0
		 *				if random number passes
		 *					place h0
		 *				else
		 *					place same height
		 */

		UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);

		for(int i = 0; i < length; i++)
		{
			if(i == 0)
				sequence.Add(2);
			else if(i == 1)
				sequence.Add(2);
			else if(i == 2)
				sequence.Add(2);
			else if(i == 3)
				sequence.Add(2);
			else
			{
				if(sequence[i-1] != 0 && sequence[i-2] != 0)
					sequence.Add(0);
				else if(sequence[i-1] == 0)
				{
					if(sequence[i-2] == 6)
						sequence.Add((int)UnityEngine.Random.Range(1.0f, sequence[i-2]));
					else
						sequence.Add((int)UnityEngine.Random.Range(1.0f, sequence[i-2] + 2));
				}
				else if(sequence[i-1] != 0)
				{
					if((int)System.Math.Round(UnityEngine.Random.value) == 1)
						sequence.Add(0);
					else
						sequence.Add(sequence[i-1]);
				}
			}
		}
	}

}

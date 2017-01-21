using System.Collections.Generic;

public class Level {

	public List<int> sequence { get; set; }

	public Level (List<int> l)
	{
		sequence = l;
	}

	public Level (int[] l)
	{
		foreach(int i in l)
		{
			sequence.Add(i);
		}
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

		for(int i = 0; i < length; i++)
		{
			
		}
	}

}

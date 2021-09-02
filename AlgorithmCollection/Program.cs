using System;
using SortingAlgorithms;

namespace AlgorithmCollection
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] array = new int[100];

			Random random = new Random();

			for (int i = 0; i < array.Length; i++)
			{
				int rndInt = random.Next(1, 1000);
				if (array[i] != rndInt)
				{
					array[i] = rndInt;
				}
			}

			var result = SelectionSorting.SortArray(array);

			Console.WriteLine("Hello World!");
			Console.ReadKey();
		}
	}
}

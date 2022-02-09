/*===================================================================
 * Copyright (c) 2022 Oleg Naraevskiy                   Date: 02.2022
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [02.2022]
 *===================================================================*/

using SortingAlgorithms;
using System;

namespace AlgorithmCollection
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] array = new int[100000];

			Random random = new Random();

			for (int i = 0; i < array.Length; i++)
			{
				int rndInt = random.Next(1, 1000000);
				
				array[i] = rndInt;
			}
			int[] sourceArray = new int[10] { -4, 2, 1, 0, 8, -3, 12, 6, 3, 4 };
			var result = SelectionSorting.Sort(sourceArray);

			Console.WriteLine(String.Join(':', result));

			Console.WriteLine("Hello World!");
			Console.ReadKey();
		}
	}
}

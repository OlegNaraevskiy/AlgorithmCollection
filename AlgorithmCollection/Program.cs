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

			var result = SelectionSorting.SortAsc(new SortingAlgorithms.Classes.NumericArrays());

			Console.WriteLine(String.Join(':', result));

			Console.WriteLine("Hello World!");
			Console.ReadKey();
		}
	}
}

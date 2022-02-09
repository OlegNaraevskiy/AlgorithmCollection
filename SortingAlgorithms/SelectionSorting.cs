/*===================================================================
 * Copyright (c) 2022 Oleg Naraevskiy                   Date: 02.2022
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [02.2022]
 *===================================================================*/

using SortingAlgorithms.Emuns;
using SortingAlgorithms.Classes;
using System;
using System.Linq;

namespace SortingAlgorithms
{
	public static class SelectionSorting
	{
		/// <summary>
		/// Сортировка массива
		/// </summary>
		/// <param name="sourceArray">Исходный массив</param>
		/// <param name="sortingMethod">Метод сортировки (по-умолчанию: по возрастанию)</param>
		/// <returns>Отсортированный массив</returns>
		public static int[] Sort(int[] sourceArray, SortingEnum sortingMethod = SortingEnum.Ascending)
		{
			int sLength = sourceArray.Length;
			int[] sortArray = new int[sLength];

			for (int i = 0; i < sLength; i++)
			{
				int sIndex = 0;

				if (sortingMethod == SortingEnum.Ascending)
				{
					sIndex = FindSmallest(sourceArray);
				}
				else if (sortingMethod == SortingEnum.Descending)
				{
					sIndex = FindBiggest(sourceArray);
				}

				sortArray[i] = sourceArray[sIndex];

				sourceArray = sourceArray.RemoveAt(sIndex);
			}

			return sortArray;
		}

		/// <summary>
		/// Нахождение наименьшего элемента
		/// </summary>
		/// <param name="sourceArray">Входящий массив</param>
		/// <returns>Индекс наименьшего элемента</returns>
		private static int FindSmallest(int[] sourceArray)
		{
			int smallElementIndex = 0;
			var smallestElement = sourceArray[smallElementIndex];

			for (int i = 0; i < sourceArray.Length; i++)
			{
				var arrayElement = sourceArray[i];

				if (arrayElement < smallestElement)
				{
					smallestElement = arrayElement;
					smallElementIndex = i;
				}
			}

			return smallElementIndex;
		}

		/// <summary>
		/// Нахождение наибольшего значения
		/// </summary>
		/// <param name="sourceArray">Входящий массив</param>
		/// <returns>Индекс наименьшего элемента</returns>
		private static int FindBiggest(int[] sourceArray)
		{
			int bigElementIndex = 0;
			var biggestElement = sourceArray[bigElementIndex];

			for (int i = 0; i < sourceArray.Length; i++)
			{
				var arrayElement = sourceArray[i];

				if (arrayElement > biggestElement)
				{
					biggestElement = arrayElement;
					bigElementIndex = i;
				}
			}

			return bigElementIndex;
		}

		/// <summary>
		/// Удаление элемента из массива по индексу
		/// </summary>
		/// <typeparam name="T">Тип массива</typeparam>
		/// <param name="source">Исходный массив</param>
		/// <param name="index">Индекс удаляемого элемента</param>
		/// <returns>Выходной массив</returns>
		private static int[] RemoveAt(this int[] source, int index)
		{
			int[] dest = new int[source.Length - 1];

			dest = source.Where((val, idx) => idx != index).ToArray();

			return dest;
		}
	}
}

using System;
using System.Linq;

namespace SortingAlgorithms
{
	public static class SelectionSorting
	{
		/// <summary>
		/// Сортировка массива по возрастанию
		/// </summary>
		/// <param name="sourceArray">Исходный массив</param>
		/// <returns>Отсортированный массив</returns>
		public static int[] SortAsc(int[] sourceArray)
		{
			int arrayLength = sourceArray.Length;

			int[] sortArray = new int[arrayLength];

			for (int i = 0; i < arrayLength; i++)
			{
				int sIndex = FindSmallest(sourceArray);

				sortArray[i] = sourceArray[sIndex];

				sourceArray = sourceArray.RemoveAt(sIndex);
			}

			return sortArray;
		}

		/// <summary>
		/// Удаление элемента из массива по индексу
		/// </summary>
		/// <typeparam name="T">Тип массима</typeparam>
		/// <param name="source">Исходный массив</param>
		/// <param name="index">Индекс удаляемого элемента</param>
		/// <returns>Выходной массив</returns>
		private static T[] RemoveAt<T>(this T[] source, int index)
		{
			T[] dest = new T[source.Length - 1];

			if (index > 0)
				Array.Copy(source, 0, dest, 0, index);

			if (index < source.Length - 1)
				Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

			return dest;
		}

		/// <summary>
		/// Нахождение наименьшего элемента
		/// </summary>
		/// <param name="sourceArray">Входящий массив</param>
		/// <returns>Индекс наименьшего элемента</returns>
		private static int FindSmallest<T>(T[] sourceArray) where T: IComparable<T>
		{
			int arrayLength = sourceArray.Length;

			int smallElementIndex = 0;
			T smallestElement = sourceArray[smallElementIndex];

			for (int i = 0; i < arrayLength; i++)
			{
				T arrayElenent = sourceArray[i];

				if (arrayElenent.CompareTo(smallestElement) < 0)
				{
					smallestElement = sourceArray[i];
					smallElementIndex = i;
				}
			}

			return smallElementIndex;
		}
	}
}

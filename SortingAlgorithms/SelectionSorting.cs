using System.Linq;

namespace SortingAlgorithms
{
	public static class SelectionSorting
	{
		private static int FindSmallest(int[] array)
		{
			int arrayLength = array.Length;

			int smallElementIndex = 0;
			var smallestElement = array[smallElementIndex];

			for (int i = 0; i < arrayLength; i++)
			{
				if (array[i] < smallestElement)
				{
					smallestElement = array[i];
					smallElementIndex = i;
				}
			}

			return smallElementIndex;
		}

		public static int[] SortArray(int[] arrayInt)
		{
			int[] sortArray = new int[arrayInt.Length];

			for (int i = 0; i < arrayInt.Length; i++)
			{
				int arrayLength = arrayInt.Length;

				int sIndex = FindSmallest(arrayInt);

				sortArray[i] = arrayInt[sIndex];

				//TO_DO: Необходимо удалить наименьший элемент из изначального массива 
			}

			return sortArray;
		}
	}
}

using SortingAlgorithms.Classes;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace SortingAlgorithms
{
	public static class SelectionSorting
	{
		/// <summary>
		/// Сортировка массива по возрастанию
		/// </summary>
		/// <param name="sourceArray">Исходный массив</param>
		/// <returns>Отсортированный массив</returns>
		public static NumericArrays SortAsc(NumericArrays sourceArray)
		{
			Type myType = Type.GetType("SortingAlgorithms.Classes.NumericArrays", false, true);

			Console.WriteLine("Поля:");

			sourceArray.ByteArray = new byte[] { 2, 1, 4, 3 };

			foreach (var prop in myType.GetProperties())
			{
				Console.WriteLine($"{prop.Name} {prop.PropertyType}");

				var propValue = prop.GetValue(sourceArray);
				if (propValue != null)
				{
					Type tProp = prop.PropertyType;
					//int arrayLength = propValue.Length;

					//T[] sortArray = new T[arrayLength];

					//for (int i = 0; i < arrayLength; i++)
					//{
					//	int sIndex = FindSmallest(sourceArray);

					//	sortArray[i] = sourceArray[sIndex];

					//	sourceArray = sourceArray.RemoveAt(sIndex);
					//}
				}
			}

			return new NumericArrays()/*sortArray*/;
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
		private static int FindSmallest<T>(T[] sourceArray) where T : IComparable
		{
			int smallElementIndex = 0;
			T smallestElement = sourceArray[smallElementIndex];

			for (int i = 0; i < sourceArray.Length; i++)
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

		/// <summary>
		/// Sets a value in an object, used to hide all the logic that goes into
		///     handling this sort of thing, so that is works elegantly in a single line.
		/// </summary>
		/// <param name="target"></param>
		/// <param name="propertyName"></param>
		/// <param name="propertyValue"></param>
		private static void SetPropertyValue(this object target,
									  string propertyName, string propertyValue, PropertyInfo oProp, NumericArrays sourceArray)
		{
			Type tProp = oProp.PropertyType;

			//Nullable properties have to be treated differently, since we 
			//  use their underlying property to set the value in the object
			if (tProp.IsGenericType
				&& tProp.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
			{
				var propValue = oProp.GetValue(sourceArray);
				//if it's null, just set the value from the reserved word null, and return
				if (propValue == null)
				{
					oProp.SetValue(target, null, null);
					return;
				}

				//Get the underlying type property instead of the nullable generic
				tProp = new NullableConverter(oProp.PropertyType).UnderlyingType;
			}

			//use the converter to get the correct value
			oProp.SetValue(target, Convert.ChangeType(propertyValue, tProp), null);
		}
	}
}

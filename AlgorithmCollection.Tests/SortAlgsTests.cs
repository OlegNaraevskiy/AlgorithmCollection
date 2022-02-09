/*===================================================================
 * Copyright (c) 2022 Oleg Naraevskiy                   Date: 02.2022
 * Version IDE: MS VS 2019
 * Designed by: Oleg Naraevskiy / noa.oleg96@gmail.com      [02.2022]
 *===================================================================*/

using FluentAssertions;
using SortingAlgorithms;
using Xunit;
using SortingAlgorithms.Emuns;

namespace AlgorithmCollection.Tests
{
	public class SortAlgsTests
	{
		[Fact]
		public void SortAscTest()
		{
			// Arrange
			int[] sourceArray = new int[10] { -4, 2, 1, 0, 8, -3, 12, 6, 3, 4 };
			int[] resultArray = new int[10] { -4, -3, 0, 1, 2, 3, 4, 6, 8, 12};

			// Act
			var result = SelectionSorting.Sort(sourceArray, SortingEnum.Ascending);

			// Assert
			result.Should().Equal(resultArray);
		}

		[Fact]
		public void SortDescTest()
		{
			// Arrange
			int[] sourceArray = new int[10] { -4, 2, 1, 0, 8, -3, 12, 6, 3, 4 };
			int[] resultArray = new int[10] { 12, 8, 6, 4, 3, 2, 1, 0, -3, -4 };

			// Act
			var result = SelectionSorting.Sort(sourceArray, SortingEnum.Descending);

			// Assert
			result.Should().Equal(resultArray);
		}
	}
}

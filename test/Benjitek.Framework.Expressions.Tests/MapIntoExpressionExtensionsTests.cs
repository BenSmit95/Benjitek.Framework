namespace Benjitek.Framework.Expressions.Tests;

public class MapIntoExpressionExtensionsTests
{
	#region Map 1

	[Fact]
	public void Map1_ShouldMapSourceExpressionIntoDestination()
	{
		// Arrange
		Expression<Func<string, int>> sourceExpression = s => s.Length;
		Expression<Func<int, bool>> resultExpression = i => i % 2 == 0;

		// Act
		var result = sourceExpression.MapInto(resultExpression);

		// Assert
		var resultFunc = result.Compile();
		Assert.True(resultFunc("even"));
		Assert.False(resultFunc("not even."));
	}

	#endregion

	#region Map 2

	[Fact]
	public void Map2_ShouldMapSourceExpressionsIntoDestination()
	{
		// Arrange
		Expression<Func<string, int>> sourceExpression1 = s => s.Length;
		Expression<Func<string, int>> sourceExpression2 = s => s.Length + 1;
		Expression<Func<int, int, string>> resultExpression = (a, b) => $"{a}{b}";

		// Act
		var result = (sourceExpression1, sourceExpression2).MapInto(resultExpression);

		// Assert
		var resultFunc = result.Compile();
		Assert.Equal("23", resultFunc("yo"));
	}

	#endregion

	#region Map 3

	[Fact]
	public void Map3_ShouldMapSourceExpressionsIntoDestination()
	{
		// Arrange
		Expression<Func<string, int>> sourceExpression1 = s => s.Length;
		Expression<Func<string, int>> sourceExpression2 = s => s.Length + 1;
		Expression<Func<string, int>> sourceExpression3 = s => s.Length + 2;
		Expression<Func<int, int, int, string>> resultExpression = (a, b, c) => $"{a}{b}{c}";

		// Act
		var result = (sourceExpression1, sourceExpression2, sourceExpression3).MapInto(resultExpression);

		// Assert
		var resultFunc = result.Compile();
		Assert.Equal("234", resultFunc("yo"));
	}

	#endregion

	#region Map 4

	[Fact]
	public void Map4_ShouldMapSourceExpressionsIntoDestination()
	{
		// Arrange
		Expression<Func<string, int>> sourceExpression1 = s => s.Length;
		Expression<Func<string, int>> sourceExpression2 = s => s.Length + 1;
		Expression<Func<string, int>> sourceExpression3 = s => s.Length + 2;
		Expression<Func<string, int>> sourceExpression4 = s => s.Length + 3;
		Expression<Func<int, int, int, int, string>> resultExpression = (a, b, c, d) => $"{a}{b}{c}{d}";

		// Act
		var result = (sourceExpression1, sourceExpression2, sourceExpression3, sourceExpression4)
			.MapInto(resultExpression);

		// Assert
		var resultFunc = result.Compile();
		Assert.Equal("2345", resultFunc("yo"));
	}

	#endregion
}
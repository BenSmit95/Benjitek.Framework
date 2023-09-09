namespace Benjitek.Framework.Expressions.Tests;

public class ReplaceExpressionsExtensionsTests
{
	[Fact]
	public void Replace_WhenSearchIsFoundWithinExpression_ReplacesAllInstances()
	{
		// Arrange
		var search = Expression.Constant(1);
		var withinExpression = Expression.Lambda<Func<int>>(Expression.Add(search, search));
		var replace = Expression.Constant(2);

		// Act
		var result = withinExpression.Replace(search, replace);

		// Assert
		Assert.Equal(4, result.Compile()());
	}

	[Fact]
	public void Replace_WhenSearchIsNotFoundWithinExpression_ReturnsOriginalExpression()
	{
		// Arrange
		var search = Expression.Constant(3);
		var withinExpression =
			Expression.Lambda<Func<int>>(Expression.Add(Expression.Constant(1), Expression.Constant(1)));
		var replace = Expression.Constant(2);

		// Act
		var result = withinExpression.Replace(search, replace);

		// Assert
		Assert.Equal(2, result.Compile()());
		Assert.Same(result, withinExpression);
	}

	[Fact]
	public void Replace_WhenSearchEqualsExpression_ReplacesExpression()
	{
		// Arrange
		var search = Expression.Constant(2);
		var withinExpression = search;
		var replace = Expression.Constant(3);

		// Act
		var result = Expression.Lambda<Func<int>>(withinExpression.Replace(search, replace));

		// Assert
		Assert.Equal(3, result.Compile()());
	}

	[Fact]
	public void Replace_WhenSearchIsFoundWithinExpression_DoesNotAlterOriginal()
	{
		// Arrange
		var search = Expression.Constant(1);
		var withinExpression = Expression.Lambda<Func<int>>(Expression.Add(search, search));
		var replace = Expression.Constant(2);

		// Act
		var result = withinExpression.Replace(search, replace);

		// Assert
		Assert.NotSame(result, withinExpression);
		Assert.Equal(2, withinExpression.Compile()());
	}

	[Fact]
	public void Replace_WhenWithinExpressionIsNull_ThrowsArgumentNullException()
	{
		// Arrange
		var search = Expression.Constant(1);
		Expression<Func<int>> withinExpression = null;
		var replace = Expression.Constant(2);

		// Act, Assert
		Assert.Throws<ArgumentNullException>(() => withinExpression.Replace(search, replace));
	}

	[Fact]
	public void Replace_WhenSearchExpressionIsNull_ThrowsArgumentNullException()
	{
		// Arrange
		var withinExpression = Expression.Lambda<Func<int>>(Expression.Constant(1));
		var replace = Expression.Constant(2);

		// Act, Assert
		Assert.Throws<ArgumentNullException>(() => withinExpression.Replace(null, replace));
	}

	[Fact]
	public void Replace_WhenReplaceExpressionIsNull_ThrowsArgumentNullException()
	{
		// Arrange
		var search = Expression.Constant(1);
		var withinExpression = Expression.Lambda<Func<int>>(search);

		// Act, Assert
		Assert.Throws<ArgumentNullException>(() => withinExpression.Replace(search, null));
	}
}
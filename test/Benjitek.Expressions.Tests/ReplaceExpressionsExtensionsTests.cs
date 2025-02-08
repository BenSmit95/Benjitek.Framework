using System.Linq.Expressions;

namespace Benjitek.Expressions.Tests;

public class ReplaceExpressionsExtensionsTests
{
    public class Replace
    {
        public class WhenSearchExpressionIsFound
        {
            [Fact]
            public void ShouldReplaceSearchExpression()
            {
                // Arrange
                Expression<Func<int, int>> expression = x => x + 1;
                var search = expression.Body;
                var replace = Expression.Constant(2);

                // Act
                var result = ReplaceExpressionsExtensions.Replace(expression, search, replace);

                // Assert
                Assert.Equal(2, result.Compile()(0));
            }

            [Fact]
            public void ShouldReturnNewExpression()
            {
                // Arrange
                Expression<Func<int, int>> expression = x => x + 1;
                var search = expression.Body;
                var replace = Expression.Constant(2);

                // Act
                var result = ReplaceExpressionsExtensions.Replace(expression, search, replace);

                // Assert
                Assert.NotSame(expression, result);
            }
        }

        public class WhenSearchExpressionIsFoundMultipleTimes
        {
            [Fact]
            public void ShouldReplaceAllFoundSearchExpressions()
            {
                // Arrange
                var constant = Expression.Constant(2);
                var expression = Expression.Lambda<Func<int>>(Expression.Add(constant, constant));
                var search = constant;
                var replace = Expression.Constant(2);

                // Act
                var result = ReplaceExpressionsExtensions.Replace(expression, search, replace);

                // Assert
                Assert.Equal(4, result.Compile()());
            }
        }

        public class WhenSearchExpressionIsNotFound
        {
            [Fact]
            public void ShouldReturnOriginalExpression()
            {
                // Arrange
                Expression<Func<int, int>> expression = x => x + 1;
                var search = Expression.Constant(2);
                var replace = Expression.Constant(2);
                // Act
                var result = ReplaceExpressionsExtensions.Replace(expression, search, replace);
                // Assert
                Assert.Same(expression, result);
            }
        }
    }
}
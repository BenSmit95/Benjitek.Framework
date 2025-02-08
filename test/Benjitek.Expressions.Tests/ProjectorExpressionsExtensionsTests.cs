using System.Linq.Expressions;

namespace Benjitek.Expressions.Tests;

public class ProjectorExpressionsExtensionsTests
{
    public class WhenProjectingOneExpression
    {
        [Fact]
        public void ShouldProjectExpression()
        {
            // Arrange
            Expression<Func<int, int>> expression = x => x + 1;
            Expression<Func<int, int>> projector = x => x * 4;

            // Act
            var result = expression.Project(projector);

            // Assert
            Assert.Equal(4, result.Compile()(0));
        }

        [Fact]
        public void ShouldReturnNewExpression()
        {
            // Arrange
            Expression<Func<int, int>> expression = x => x + 1;
            Expression<Func<int, int>> projector = x => x * 2;

            // Act
            var result = expression.Project(projector);

            // Assert
            Assert.NotSame(expression, result);
        }
    }

    public class WhenProjectingTwoExpressions
    {
        [Fact]
        public void ShouldProjectExpression()
        {
            // Arrange
            Expression<Func<int, int>> expression1 = x => x + 1;
            Expression<Func<int, int>> expression2 = x => x * 2;
            Expression<Func<int, int, int>> projector = (x, y) => x + y;

            // Act
            var result = (expression1, expression2).Project(projector);

            // Assert
            Assert.Equal(7, result.Compile()(2));
        }

        [Fact]
        public void ShouldReturnNewExpression()
        {
            // Arrange
            Expression<Func<int, int>> expression1 = x => x + 1;
            Expression<Func<int, int>> expression2 = x => x * 2;
            Expression<Func<int, int, int>> projector = (x, y) => x + y;

            // Act
            var result = (expression1, expression2).Project(projector);

            // Assert
            Assert.NotSame(expression1, result);
            Assert.NotSame(expression2, result);
        }
    }

    public class WhenProjectingThreeExpressions
    {
        [Fact]
        public void ShouldProjectExpression()
        {
            // Arrange
            Expression<Func<int, int>> expression1 = x => x + 1;
            Expression<Func<int, int>> expression2 = x => x * 2;
            Expression<Func<int, int>> expression3 = x => x * 4;
            Expression<Func<int, int, int, int>> projector = (x, y, z) => x + y + z;

            // Act
            var result = (expression1, expression2, expression3).Project(projector);

            // Assert
            Assert.Equal(15, result.Compile()(2));
        }

        [Fact]
        public void ShouldReturnNewExpression()
        {
            // Arrange
            Expression<Func<int, int>> expression1 = x => x + 1;
            Expression<Func<int, int>> expression2 = x => x * 2;
            Expression<Func<int, int>> expression3 = x => x - 1;
            Expression<Func<int, int, int, int>> projector = (x, y, z) => x + y + z;

            // Act
            var result = (expression1, expression2, expression3).Project(projector);

            // Assert
            Assert.NotSame(expression1, result);
            Assert.NotSame(expression2, result);
            Assert.NotSame(expression3, result);
        }
    }

    public class WhenProjectingFourExpressions
    {
        [Fact]
        public void ShouldProjectExpression()
        {
            // Arrange
            Expression<Func<int, int>> expression1 = x => x + 1;
            Expression<Func<int, int>> expression2 = x => x * 2;
            Expression<Func<int, int>> expression3 = x => x * 4;
            Expression<Func<int, int>> expression4 = x => x * 8;
            Expression<Func<int, int, int, int, int>> projector = (w, x, y, z) => w + x + y + z;

            // Act
            var result = (expression1, expression2, expression3, expression4).Project(projector);

            // Assert
            Assert.Equal(31, result.Compile()(2));
        }
         
        [Fact]
        public void ShouldReturnNewExpression()
        {
            // Arrange
            Expression<Func<int, int>> expression1 = x => x + 1;
            Expression<Func<int, int>> expression2 = x => x * 2;
            Expression<Func<int, int>> expression3 = x => x - 1;
            Expression<Func<int, int>> expression4 = x => x - 2;
            Expression<Func<int, int, int, int, int>> projector = (w, x, y, z) => w + x + y + z;

            // Act
            var result = (expression1, expression2, expression3, expression4).Project(projector);

            // Assert
            Assert.NotSame(expression1, result);
            Assert.NotSame(expression2, result);
            Assert.NotSame(expression3, result);
        }
    }
}


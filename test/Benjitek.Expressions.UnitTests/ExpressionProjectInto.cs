using System.Linq.Expressions;

namespace Benjitek.Expressions.UnitTests;

public static class ExpressionProjectInto
{
    public class With1SourceExpression
    {
        [Fact]
        public void GivenExpressionsAreValid_ShouldReturnProjectedExpression()
        {
            // arrange
            Expression<Func<int, int>> baseExpression = a => a + 1;
        
            // act
            var resultExpression = baseExpression.ProjectInto(a => a * 2);
        
            // assert
            var resultFn = resultExpression.Compile();
            Assert.Equal(4, resultFn(1));
        }
    }
    
    public class With2SourceExpressions
    {
        [Fact]
        public void GivenExpressionsAreValid_ShouldReturnProjectedExpression()
        {
            // arrange
            Expression<Func<int, int>> baseExpression1 = a => a + 1;
            Expression<Func<int, int>> baseExpression2 = a => a + 2;
        
            // act
            var resultExpression = (baseExpression1, baseExpression2).ProjectInto((a, b) => a + b);
        
            // assert
            var resultFn = resultExpression.Compile();
            Assert.Equal(5, resultFn(1));
        }
    }
}
using System.Linq.Expressions;

namespace Benjitek.Expressions.Tests;

public class PredicateExpressionsExtensionsTests
{
    public class And
    {
        public class WhenAPredicateExpressionIsNull
        {
            [Fact]
            public void ShouldThrowArgumentNullException()
            {
                // Arrange
                Expression<Func<int, bool>> notNullPredicate = x => x > 0;
                Expression<Func<int, bool>> nullPredicate = null;

                // Act

                // Assert
                Assert.Throws<ArgumentNullException>(() => notNullPredicate.And(nullPredicate));
                Assert.Throws<ArgumentNullException>(() => nullPredicate.And(notNullPredicate));
                Assert.Throws<ArgumentNullException>(() => nullPredicate.And(nullPredicate));
            }
        }

        public class WhenNeitherPredicateExpressionIsNull
        {
            [Fact]
            public void ShouldCombinePredicatesUsingAndAlsoOperator()
            {
                // Arrange
                Expression<Func<int, bool>> left = x => x > 0;
                Expression<Func<int, bool>> right = x => x < 10;

                // Act
                var result = left.And(right);

                // Assert
                var compiled = result.Compile();
                Assert.True(compiled(5));
                Assert.False(compiled(0));
                Assert.False(compiled(10));
            }
        }
    }

    public class Or
    {
        public class WhenAPredicateExpressionIsNull
        {
            [Fact]
            public void ShouldThrowArgumentNullException()
            {
                // Arrange
                Expression<Func<int, bool>> notNullPredicate = x => x > 0;
                Expression<Func<int, bool>> nullPredicate = null;

                // Act

                // Assert

                Assert.Throws<ArgumentNullException>(() => notNullPredicate.Or(nullPredicate));
                Assert.Throws<ArgumentNullException>(() => nullPredicate.Or(notNullPredicate));
                Assert.Throws<ArgumentNullException>(() => nullPredicate.Or(nullPredicate));
            }
        }

        public class WhenNeitherPredicateExpressionIsNull
        {
            [Fact]
            public void ShouldCombinePredicatesUsingOrElseOperator()
            {
                // Arrange
                Expression<Func<int, bool>> left = x => x < 0;
                Expression<Func<int, bool>> right = x => x > 10;

                // Act
                var result = left.Or(right);

                // Assert
                var compiled = result.Compile();
                Assert.True(compiled(-1));
                Assert.True(compiled(11));
                Assert.False(compiled(5));
            }
        }
    }

    public class Xor
    {
        public class WhenAPredicateExpressionIsNull
        {
            [Fact]
            public void ShouldThrowArgumentNullException()
            {
                // Arrange
                Expression<Func<int, bool>> notNullPredicate = x => x > 0;
                Expression<Func<int, bool>> nullPredicate = null;

                // Act

                // Assert
                Assert.Throws<ArgumentNullException>(() => notNullPredicate.Xor(nullPredicate));
                Assert.Throws<ArgumentNullException>(() => nullPredicate.Xor(notNullPredicate));
                Assert.Throws<ArgumentNullException>(() => nullPredicate.Xor(nullPredicate));
            }
        }

        public class WhenNeitherPredicateExpressionIsNull
        {
            [Fact]
            public void ShouldCombinePredicatesUsingXorOperator()
            {
                // Arrange
                Expression<Func<int, bool>> left = x => x > 0 && x < 15;
                Expression<Func<int, bool>> right = x => x < 10;

                // Act
                var result = left.Xor(right);

                // Assert
                var compiled = result.Compile();
                Assert.True(compiled(-1));
                Assert.True(compiled(11));
                Assert.False(compiled(5));
                Assert.False(compiled(16));
            }
        }
    }

    public static class Xnor
    {
        public class WhenAPredicateExpressionIsNull
        {
            [Fact]
            public void ShouldThrowArgumentNullException()
            {
                // Arrange
                Expression<Func<int, bool>> notNullPredicate = x => x > 0;
                Expression<Func<int, bool>> nullPredicate = null;

                // Act

                // Assert
                Assert.Throws<ArgumentNullException>(() => notNullPredicate.XNor(nullPredicate));
                Assert.Throws<ArgumentNullException>(() => nullPredicate.XNor(notNullPredicate));
                Assert.Throws<ArgumentNullException>(() => nullPredicate.XNor(nullPredicate));
            }
        }
        public class WhenNeitherPredicateExpressionIsNull
        {
            [Fact]
            public void ShouldCombinePredicatesUsingXnorOperator()
            {
                // Arrange
                Expression<Func<int, bool>> left = x => x > 0 && x < 15;
                Expression<Func<int, bool>> right = x => x < 10;

                // Act
                var result = left.XNor(right);

                // Assert
                var compiled = result.Compile();
                Assert.False(compiled(-1));
                Assert.False(compiled(11));
                Assert.True(compiled(5));
                Assert.True(compiled(16));
            }
        }
    }

    public static class Negate
    {
        public class WhenPredicateExpressionIsNull
        {
            [Fact]
            public void ShouldThrowArgumentNullException()
            {
                // Arrange
                Expression<Func<int, bool>> predicate = null;

                // Act

                // Assert
                Assert.Throws<ArgumentNullException>(() => predicate.Negate());
            }
        }

        public class WhenPredicateExpressionIsNotNull
        {
            [Fact]
            public void ShouldNegatePredicateExpression()
            {
                // Arrange
                Expression<Func<int, bool>> predicate = x => x > 0;
                // Act
                var result = predicate.Negate();
                // Assert
                var compiled = result.Compile();
                Assert.False(compiled(5));
                Assert.True(compiled(0));
            }
        }
    }
}
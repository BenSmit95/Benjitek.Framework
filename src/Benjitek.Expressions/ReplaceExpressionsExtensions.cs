using System.Linq.Expressions;

namespace Benjitek.Expressions;

public static class ReplaceExpressionsExtensions
{
    /// <summary>
    ///     Replaces an expression with another expression in a given expression.
    /// </summary>
    /// <typeparam name="TExpression">
    ///     The type of the expression tree in which to replace to expression.
    /// </typeparam>
    /// <param name="expression">
    ///     The expression tree in which to replace the expression.
    /// </param>
    /// <param name="search">
    ///     The expression to search for in the expression tree.
    /// </param>
    /// <param name="replace">
    ///     The expression to replace the search expression with.
    /// </param>
    /// <returns>
    ///     The expression tree with the search expression replaced with the replace expression.
    /// </returns>
    public static TExpression Replace<TExpression>(
        this TExpression expression,
        Expression search,
        Expression replace
        )
        where TExpression : Expression
    {
        return (TExpression)new ReplaceVisitor(search, replace).Visit(expression);
    }

    private class ReplaceVisitor : ExpressionVisitor
    {
        private readonly Expression _search;
        private readonly Expression _replace;

        public ReplaceVisitor(Expression search, Expression replace)
        {
            _search = search;
            _replace = replace;
        }

        public override Expression Visit(Expression node)
        {
            return node == _search ? _replace : base.Visit(node);
        }
    }
}


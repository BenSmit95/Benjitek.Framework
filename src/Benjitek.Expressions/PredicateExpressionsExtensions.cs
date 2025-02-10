using System.Linq.Expressions;

namespace Benjitek.Expressions;

public static class PredicateExpressionsExtensions
{
    private static Expression<Func<T, bool>> CombinePredicates<T>(
        Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right,
        Func<Expression, Expression, BinaryExpression> combiner
        )
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);
        ArgumentNullException.ThrowIfNull(combiner);

        var parameter = Expression.Parameter(typeof(T), "param");

        var leftBody = left.Body.Replace(left.Parameters[0], parameter);
        var rightBody = right.Body.Replace(right.Parameters[0], parameter);

        var body = combiner(leftBody, rightBody);

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }

    /// <summary>
    ///    Combines two predicate expressions using the AND operator.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the parameter in the predicate expressions.
    /// </typeparam>
    /// <param name="left">
    ///     The left predicate expression.
    /// </param>
    /// <param name="right">
    ///     The right predicate expression.
    /// </param>
    /// <returns>
    ///     The combined predicate expression.
    /// </returns>
    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        => CombinePredicates(left, right, Expression.AndAlso);

    /// <summary>
    ///    Combines two predicate expressions using the OR operator.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the parameter in the predicate expressions.
    /// </typeparam>
    /// <param name="left">
    ///     The left predicate expression.
    /// </param>
    /// <param name="right">
    ///     The right predicate expression.
    /// </param>
    /// <returns>
    ///     The combined predicate expression.
    /// </returns>
    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        => CombinePredicates(left, right, Expression.OrElse);

    /// <summary>
    ///    Combines two predicate expressions using the XOR operator.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the parameter in the predicate expressions.
    /// </typeparam>
    /// <param name="left">
    ///     The left predicate expression.
    /// </param>
    /// <param name="right">
    ///     The right predicate expression.
    /// </param>
    /// <returns>
    ///     The combined predicate expression.
    /// </returns>
    public static Expression<Func<T, bool>> Xor<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        => CombinePredicates(left, right, Expression.ExclusiveOr);

    /// <summary>
    ///    Combines two predicate expressions using the XNOR operator.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the parameter in the predicate expressions.
    /// </typeparam>
    /// <param name="left">
    ///     The left predicate expression.
    /// </param>
    /// <param name="right">
    ///     The right predicate expression.
    /// </param>
    /// <returns>
    ///     The combined predicate expression.
    /// </returns>
    public static Expression<Func<T, bool>> XNor<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        => Negate(Xor(left, right));

    /// <summary>
    ///    Negates a predicate expression.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the parameter in the predicate expression.
    /// </typeparam>
    /// <param name="expression">
    ///     The predicate expression.
    /// </param>
    /// <returns>
    ///     The negated predicate expression.
    /// </returns>
    public static Expression<Func<T, bool>> Negate<T>(this Expression<Func<T, bool>> expression)
    {
        ArgumentNullException.ThrowIfNull(expression);
        var parameter = Expression.Parameter(typeof(T), "param");
        var body = Expression.Not(expression.Body.Replace(expression.Parameters[0], parameter));
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}

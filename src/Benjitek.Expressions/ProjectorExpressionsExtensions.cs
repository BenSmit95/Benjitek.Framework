using System.Linq.Expressions;

namespace Benjitek.Expressions;

public static class ProjectorExpressionsExtensions
{
    private static Expression<Func<TParam, TProjectionResult>> CreateProjectedExpression<TParam, TProjectionResult>(
        Expression[] expressions,
        Expression projector
        )
    {
        var parameter = Expression.Parameter(typeof(TParam), "param");

        var args = expressions.Select(e => Expression.Invoke(e, parameter)).ToArray();

        var projection = Expression.Invoke(projector, args);

        return Expression.Lambda<Func<TParam, TProjectionResult>>(projection, parameter);
    }

    /// <summary>
    ///     Returns a new expression that projects the result of the given expression.
    /// </summary>
    /// <typeparam name="TParam">
    ///     The type of the parameter of the expression.
    /// </typeparam>
    /// <typeparam name="TExpressionResult">
    ///     The type of the result of the expression.
    /// </typeparam>
    /// <typeparam name="TProjectionResult">
    ///     The type of the result of the projection expression.
    /// </typeparam>
    /// <param name="expression">
    ///     The expression to project the result of.
    /// </param>
    /// <param name="projector">
    ///     The expression to project the result of the expression.
    /// </param>
    /// <returns>
    ///     The new expression that projects the result of the given expression.
    /// </returns>
    public static Expression<Func<TParam, TProjectionResult>> Project<TParam, TExpressionResult, TProjectionResult>(
        this Expression<Func<TParam, TExpressionResult>> expression,
        Expression<Func<TExpressionResult, TProjectionResult>> projector
        ) => CreateProjectedExpression<TParam, TProjectionResult>([expression], projector);

    /// <summary>
    ///     Returns a new expression that projects the result of the given expressions.
    /// </summary>
    /// <typeparam name="TParam">
    ///     The type of the parameter of the expressions.
    /// </typeparam>
    /// <typeparam name="TExpressionResult1">
    ///     The type of the result of the first expression.
    /// </typeparam>
    /// <typeparam name="TExpressionResult2">
    ///     The type of the result of the second expression.
    /// </typeparam>
    /// <typeparam name="TProjectionResult">
    ///     The type of the result of the projection expression.
    /// </typeparam>
    /// <param name="expressions">
    ///     The expressions to project the result of.
    /// </param>
    /// <param name="projector">
    ///     The expression to project the result of the expressions.
    /// </param>
    /// <returns>
    ///     The new expression that projects the result of the given expressions.
    /// </returns>
    public static Expression<Func<TParam, TProjectionResult>> Project<TParam, TExpressionResult1, TExpressionResult2, TProjectionResult>(
        this (Expression<Func<TParam, TExpressionResult1>>, Expression<Func<TParam, TExpressionResult2>>) expressions,
        Expression<Func<TExpressionResult1, TExpressionResult2, TProjectionResult>> projector
        ) => CreateProjectedExpression<TParam, TProjectionResult>([expressions.Item1, expressions.Item2], projector);

    /// <summary>
    ///     Returns a new expression that projects the result of the given expressions.
    /// </summary>
    /// <typeparam name="TParam">
    ///     The type of the parameter of the expressions.
    /// </typeparam>
    /// <typeparam name="TExpressionResult1">
    ///     The type of the result of the first expression.
    /// </typeparam>
    /// <typeparam name="TExpressionResult2">
    ///     The type of the result of the second expression.
    /// </typeparam>
    /// <typeparam name="TExpressionResult3">
    ///     The type of the result of the third expression.
    /// </typeparam>
    /// <typeparam name="TProjectionResult">
    ///     The type of the result of the projection expression.
    /// </typeparam>
    /// <param name="expressions">
    ///     The expressions to project the result of.
    /// </param>
    /// <param name="projector">
    ///     The expression to project the result of the expressions.
    /// </param>
    /// <returns>
    ///     The new expression that projects the result of the given expressions.
    /// </returns>
    public static Expression<Func<TParam, TProjectionResult>> Project<TParam, TExpressionResult1, TExpressionResult2, TExpressionResult3, TProjectionResult>(
        this (Expression<Func<TParam, TExpressionResult1>>, Expression<Func<TParam, TExpressionResult2>>, Expression<Func<TParam, TExpressionResult3>>) expressions,
        Expression<Func<TExpressionResult1, TExpressionResult2, TExpressionResult3, TProjectionResult>> projector
        ) => CreateProjectedExpression<TParam, TProjectionResult>([expressions.Item1, expressions.Item2, expressions.Item3], projector);

    /// <summary>
    ///     Returns a new expression that projects the result of the given expressions.
    /// </summary>
    /// <typeparam name="TParam">
    ///     The type of the parameter of the expressions.
    /// </typeparam>
    /// <typeparam name="TExpressionResult1">
    ///     The type of the result of the first expression.
    /// </typeparam>
    /// <typeparam name="TExpressionResult2">
    ///     The type of the result of the second expression.
    /// </typeparam>
    /// <typeparam name="TExpressionResult3">
    ///     The type of the result of the third expression.
    /// </typeparam>
    /// <typeparam name="TExpressionResult4">
    ///     The type of the result of the fourth expression.
    /// </typeparam>
    /// <typeparam name="TProjectionResult">
    ///     The type of the result of the projection expression.
    /// </typeparam>
    /// <param name="expressions">
    ///     The expressions to project the result of.
    /// </param>
    /// <param name="projector">
    ///     The expression to project the result of the expressions.
    /// </param>
    /// <returns>
    ///     The new expression that projects the result of the given expressions.
    /// </returns>
    public static Expression<Func<TParam, TProjectionResult>> Project<TParam, TExpressionResult1, TExpressionResult2, TExpressionResult3, TExpressionResult4, TProjectionResult>(
        this (Expression<Func<TParam, TExpressionResult1>>, Expression<Func<TParam, TExpressionResult2>>, Expression<Func<TParam, TExpressionResult3>>, Expression<Func<TParam, TExpressionResult4>>) expressions,
        Expression<Func<TExpressionResult1, TExpressionResult2, TExpressionResult3, TExpressionResult4, TProjectionResult>> projector
        ) => CreateProjectedExpression<TParam, TProjectionResult>([expressions.Item1, expressions.Item2, expressions.Item3, expressions.Item4], projector);
}


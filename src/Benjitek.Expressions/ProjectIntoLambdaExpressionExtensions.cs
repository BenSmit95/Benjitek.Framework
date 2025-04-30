using System.Linq.Expressions;

namespace Benjitek.Expressions;

public static class ProjectIntoLambdaExpressionExtensions
{
    private static Expression<TDelegate> CreateProjectedLambdaExpression<TDelegate>(LambdaExpression[] expressions,
        LambdaExpression mapping)
        where TDelegate : Delegate
    {
        if (expressions == null || expressions.Length == 0) throw new ArgumentNullException(nameof(expressions));

        // Assume for now that all parameters are equal for the expressions
        var parameters = expressions[0].Parameters;

        var resultMappingBody = mapping.Body;

        for (var i = 0; i < expressions.Length; i++)
        {
            var isFirst = i == 0;
            var sourceExpression = expressions[i];
            var sourceExpressionBody = sourceExpression.Body;
            if (!isFirst)
                for (var j = 0; j < parameters.Count; j++)
                    sourceExpressionBody = sourceExpressionBody.Replace(sourceExpression.Parameters[j], parameters[j]);

            resultMappingBody = resultMappingBody.Replace(mapping.Parameters[i], sourceExpressionBody);
        }

        return Expression.Lambda<TDelegate>(resultMappingBody, parameters);
    }

    public static Expression<Func<TIn, TOut>> ProjectInto<TIn, T1, TOut>(
        this Expression<Func<TIn, T1>> expression,
        Expression<Func<T1, TOut>> projectorExpression
    )
    {
        ArgumentNullException.ThrowIfNull(expression);
        ArgumentNullException.ThrowIfNull(projectorExpression);

        return CreateProjectedLambdaExpression<Func<TIn, TOut>>([expression], projectorExpression);
    }

    public static Expression<Func<TIn, TOut>> ProjectInto<TIn, T1, T2, TOut>(
        this (Expression<Func<TIn, T1>>, Expression<Func<TIn, T2>>) expressions,
        Expression<Func<T1, T2, TOut>> projectorExpression
    )
    {
        ArgumentNullException.ThrowIfNull(expressions.Item1);
        ArgumentNullException.ThrowIfNull(expressions.Item2);
        ArgumentNullException.ThrowIfNull(projectorExpression);

        return CreateProjectedLambdaExpression<Func<TIn, TOut>>([expressions.Item1, expressions.Item2],
            projectorExpression);
    }
}
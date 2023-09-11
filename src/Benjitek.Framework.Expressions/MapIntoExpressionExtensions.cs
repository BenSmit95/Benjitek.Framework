namespace Benjitek.Framework.Expressions;

public static class MapIntoExpressionExtensions
{
	private static Expression<Func<TIn, TOut>> HandleMapInto<TIn, TOut>(
		IReadOnlyList<LambdaExpression> sourceExpressions,
		LambdaExpression destinationExpression
	)
	{
		var param = Expression.Parameter(typeof(TIn));

		var resultBody = destinationExpression.Body;

		for (var i = 0; i < sourceExpressions.Count; i++)
		{
			// replace parameter in source expression
			var sourceExpression = sourceExpressions[i];
			var replacedSourceExpression = sourceExpression.Replace(sourceExpression.Parameters[0], param);

			// replace parameter in destination expression
			resultBody = resultBody.Replace(destinationExpression.Parameters[i], replacedSourceExpression.Body);
		}

		return Expression.Lambda<Func<TIn, TOut>>(resultBody, param);
	}


	/// <summary>
	///  Maps the result of <paramref name="sourceExpression" /> into <paramref name="destinationExpression" />.
	/// </summary>
	/// <param name="sourceExpression">
	///  The expression to map into <paramref name="destinationExpression" />.
	/// </param>
	/// <param name="destinationExpression">
	///  The expression to map <paramref name="sourceExpression" /> into.
	/// </param>
	/// <typeparam name="TIn">
	///  The type of the parameter for <paramref name="sourceExpression" />.
	/// </typeparam>
	/// <typeparam name="TSourceResult">
	///  The type of the result of <paramref name="sourceExpression" />.
	/// </typeparam>
	/// <typeparam name="TOut">
	///  The type of the result of <paramref name="destinationExpression" />.
	/// </typeparam>
	/// <returns>
	///  The mapped expression
	/// </returns>
	public static Expression<Func<TIn, TOut>> MapInto<TIn, TSourceResult, TOut>(
		this Expression<Func<TIn, TSourceResult>> sourceExpression,
		Expression<Func<TSourceResult, TOut>> destinationExpression
	)
	{
		return HandleMapInto<TIn, TOut>(new LambdaExpression[] { sourceExpression }, destinationExpression);
	}

	/// <summary>
	///  Maps the result of <paramref name="sourceExpressions" /> into <paramref name="destinationExpression" />.
	/// </summary>
	/// <param name="sourceExpressions">
	///  The expressions to map into <paramref name="destinationExpression" />.
	/// </param>
	/// <param name="destinationExpression">
	///  The expression to map <paramref name="sourceExpressions" /> into.
	/// </param>
	/// <typeparam name="TIn">
	///  The type of the parameter for <paramref name="sourceExpressions" />.
	/// </typeparam>
	/// <typeparam name="TSourceResult1">
	///  The type of the result of <paramref name="sourceExpressions.Item1" />.
	/// </typeparam>
	/// <typeparam name="TSourceResult2">
	///  The type of the result of <paramref name="sourceExpressions.Item2" />.
	/// </typeparam>
	/// <typeparam name="TOut">
	///  The type of the result of <paramref name="destinationExpression" />.
	/// </typeparam>
	/// <returns>
	///  The mapped expression
	/// </returns>
	public static Expression<Func<TIn, TOut>> MapInto<TIn, TSourceResult1, TSourceResult2, TOut>(
		this (Expression<Func<TIn, TSourceResult1>>, Expression<Func<TIn, TSourceResult2>>) sourceExpressions,
		Expression<Func<TSourceResult1, TSourceResult2, TOut>> destinationExpression
	)
	{
		return HandleMapInto<TIn, TOut>(new LambdaExpression[] { sourceExpressions.Item1, sourceExpressions.Item2 },
			destinationExpression);
	}

	/// <summary>
	///  Maps the result of <paramref name="sourceExpressions" /> into <paramref name="destinationExpression" />.
	/// </summary>
	/// <param name="sourceExpressions">
	///  The expressions to map into <paramref name="destinationExpression" />.
	/// </param>
	/// <param name="destinationExpression">
	///  The expression to map <paramref name="sourceExpressions" /> into.
	/// </param>
	/// <typeparam name="TIn">
	///  The type of the parameter for <paramref name="sourceExpressions" />.
	/// </typeparam>
	/// <typeparam name="TSourceResult1">
	///  The type of the result of <paramref name="sourceExpressions.Item1" />.
	/// </typeparam>
	/// <typeparam name="TSourceResult2">
	///  The type of the result of <paramref name="sourceExpressions.Item2" />.
	/// </typeparam>
	/// <typeparam name="TSourceResult3">
	///  The type of the result of <paramref name="sourceExpressions.Item3" />.
	/// </typeparam>
	/// <typeparam name="TOut">
	///  The type of the result of <paramref name="destinationExpression" />.
	/// </typeparam>
	/// <returns>
	///  The mapped expression
	/// </returns>
	public static Expression<Func<TIn, TOut>> MapInto<TIn, TSourceResult1, TSourceResult2, TSourceResult3, TOut>(
		this (
			Expression<Func<TIn, TSourceResult1>>,
			Expression<Func<TIn, TSourceResult2>>,
			Expression<Func<TIn, TSourceResult3>>
			) sourceExpressions,
		Expression<Func<TSourceResult1, TSourceResult2, TSourceResult3, TOut>> destinationExpression
	)
	{
		return HandleMapInto<TIn, TOut>(
			new LambdaExpression[]
			{
				sourceExpressions.Item1,
				sourceExpressions.Item2,
				sourceExpressions.Item3
			}, destinationExpression);
	}


	/// <summary>
	///  Maps the result of <paramref name="sourceExpressions" /> into <paramref name="destinationExpression" />.
	/// </summary>
	/// <param name="sourceExpressions">
	///  The expressions to map into <paramref name="destinationExpression" />.
	/// </param>
	/// <param name="destinationExpression">
	///  The expression to map <paramref name="sourceExpressions" /> into.
	/// </param>
	/// <typeparam name="TIn">
	///  The type of the parameter for <paramref name="sourceExpressions" />.
	/// </typeparam>
	/// <typeparam name="TSourceResult1">
	///  The type of the result of <paramref name="sourceExpressions.Item1" />.
	/// </typeparam>
	/// <typeparam name="TSourceResult2">
	///  The type of the result of <paramref name="sourceExpressions.Item2" />.
	/// </typeparam>
	/// <typeparam name="TSourceResult3">
	///  The type of the result of <paramref name="sourceExpressions.Item3" />.
	/// </typeparam>
	/// <typeparam name="TSourceResult4">
	///  The type of the result of <paramref name="sourceExpressions.Item4" />.
	/// </typeparam>
	/// <typeparam name="TOut">
	///  The type of the result of <paramref name="destinationExpression" />.
	/// </typeparam>
	/// <returns>
	///  The mapped expression
	/// </returns>
	public static Expression<Func<TIn, TOut>> MapInto<TIn, TSourceResult1, TSourceResult2, TSourceResult3,
		TSourceResult4, TOut>(
		this (
			Expression<Func<TIn, TSourceResult1>>,
			Expression<Func<TIn, TSourceResult2>>,
			Expression<Func<TIn, TSourceResult3>>,
			Expression<Func<TIn, TSourceResult4>>
			) sourceExpressions,
		Expression<Func<TSourceResult1, TSourceResult2, TSourceResult3, TSourceResult4, TOut>> destinationExpression
	)
	{
		return HandleMapInto<TIn, TOut>(
			new LambdaExpression[]
			{
				sourceExpressions.Item1,
				sourceExpressions.Item2,
				sourceExpressions.Item3,
				sourceExpressions.Item4
			}, destinationExpression);
	}
}
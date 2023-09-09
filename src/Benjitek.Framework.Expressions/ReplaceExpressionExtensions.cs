namespace Benjitek.Framework.Expressions;

public static class ReplaceExpressionExtensions
{
	/// <summary>
	///  Searches within <paramref name="expression" /> for any instances of <paramref name="search" /> and replaces them with
	///  <paramref name="replace" />.
	/// </summary>
	/// <param name="expression">
	///  The expression tree to search within.
	/// </param>
	/// <param name="search">
	///  The expression to search for.
	/// </param>
	/// <param name="replace">
	///  The expression to replace with.
	/// </param>
	/// <typeparam name="TExpression">
	///  The type of expression to return.
	/// </typeparam>
	/// <returns>
	///  The expression with any instances of <paramref name="search" /> replaced with <paramref name="replace" />.
	///  If no instances have been replaced, returns <paramref name="expression" />
	/// </returns>
	public static TExpression Replace<TExpression>(this TExpression? expression, Expression? search,
		Expression? replace)
		where TExpression : Expression
	{
		if (expression == null)
			throw new ArgumentNullException(nameof(expression));
		if (search == null)
			throw new ArgumentNullException(nameof(search));
		if (replace == null)
			throw new ArgumentNullException(nameof(replace));

		return (TExpression)new ReplaceVisitor(search, replace).Visit(expression)!;
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

		public override Expression? Visit(Expression? node)
		{
			return node == _search ? _replace : base.Visit(node);
		}
	}
}
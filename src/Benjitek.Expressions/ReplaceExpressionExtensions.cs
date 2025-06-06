﻿using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using Benjitek.Expressions.Internals;

namespace Benjitek.Expressions;

public static class ReplaceExpressionExtensions
{
    [Pure]
    public static TExpression Replace<TExpression>(this TExpression node, Expression search, Expression replace)
        where TExpression : Expression
    {
        ArgumentNullException.ThrowIfNull(node);
        ArgumentNullException.ThrowIfNull(search);
        ArgumentNullException.ThrowIfNull(replace);

        // Can't replace the entire node
        if (search == node)
            throw new ArgumentException("The search cannot be the same as the node.", nameof(search));

        var replaceExpressionVisitor = new ReplaceExpressionVisitor(search, replace);

        if (replaceExpressionVisitor.Visit(node) is not TExpression replacedExpression)
            throw new Exception("The replaced expression is not of the expected type.");

        return replacedExpression;
    }
}
using System.Linq.Expressions;

namespace FileContextCore.Extensions
{
    public static class ExpressionExtension
    {
        public static LambdaExpression UnwrapLambdaFromQuote(this Expression expression)
            => (LambdaExpression)(expression is UnaryExpression unary && expression.NodeType == ExpressionType.Quote
                ? unary.Operand
                : expression);
    }
}
using System.Linq.Expressions;

namespace back.Core.Specifications
{
	public class BaseSpecification<T> : ISpecification<T>
	{
		public BaseSpecification()
		{
			
		}
		public BaseSpecification(Expression<Func<T, bool>> criteria)
		{
			Criteria = criteria;
		}
		public Expression<Func<T, bool>> Criteria  { get;}

		public List<Expression<Func<T, object>>> Includes { get; } = [];
		
		protected void AddInclude(Expression<Func<T, object>> includeExpression)
		{
			Includes.Add(includeExpression);
		}
		
		
	}
}
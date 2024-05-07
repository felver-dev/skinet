using System.Linq.Expressions;

namespace back.Core.Specifications
{
	public interface ISpecification<T>
	{
		Expression<Func<T, bool>> Criteria { get; }
		List<Expression<Func<T, Object>>> Includes { get; }
	}
}
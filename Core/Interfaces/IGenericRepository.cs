using back.Core.Entities;
using back.Core.Specifications;

namespace back.Core.Interfaces
{
	public interface IGenericRepository<T> where T : BaseEntity  
	{
		Task<T> GetByIdAsync(int id);
		Task<IReadOnlyList<T>> ListAllAsync();
		Task<T> GetEntityWithSpec(ISpecification<T> spec);
		Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
		Task<int> CountAsync(ISpecification<T> spec);
		
	}
}
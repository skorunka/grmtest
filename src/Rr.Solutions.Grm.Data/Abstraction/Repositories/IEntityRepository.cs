namespace Rr.Solutions.Grm.Data.Abstraction.Repositories
{
	using System.Linq;

	public interface IEntityRepository<T>
	{
		IQueryable<T> Entities { get; }
	}
}

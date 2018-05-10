namespace Rr.Solutions.Grm.Data.Abstraction.DataSources
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IDataSource<out T>
	{
		IEnumerable<T> GetEntities();
	}
}

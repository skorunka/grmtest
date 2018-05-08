namespace Rr.Solutions.Grm.Data.Abstraction.DataSources
{
	using System.Collections.Generic;

	public interface IDataSource<out T>
	{
		IEnumerable<T> GetEntities();
	}
}

namespace Rr.Solutions.Grm.Data.Repositories
{
	using System;
	using System.Linq;
	using Abstraction.DataSources;
	using Abstraction.Repositories;

	public class EntityRepository<T> : IEntityRepository<T>
	{
		private readonly Lazy<IQueryable<T>> _lazyIntities;

		#region ctors

		public EntityRepository(IDataSource<T> dataSource)
		{
			if (dataSource == null)
			{
				throw new ArgumentNullException(nameof(dataSource));
			}

			this._lazyIntities = new Lazy<IQueryable<T>>(() => dataSource.GetEntities().AsQueryable());
		}

		#endregion

		public IQueryable<T> Entities => this._lazyIntities.Value;
	}
}

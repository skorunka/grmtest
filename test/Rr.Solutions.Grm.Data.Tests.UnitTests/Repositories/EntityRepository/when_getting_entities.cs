// ReSharper disable InconsistentNaming
namespace Rr.Solutions.Grm.Data.Tests.UnitTests.Repositories.EntityRepository
{
	using Abstraction.DataSources;
	using Abstraction.Repositories;
	using Data.Repositories;
	using NSubstitute;
	using Xunit;

	public class when_getting_entities
	{
		[Fact]
		public void make_sure_datasource_is_accessed_only_once()
		{
			var dataSource = Substitute.For<IDataSource<int>>();

			var entityReposityry = new EntityRepository<int>(dataSource) as IEntityRepository<int>;

			// ReSharper disable once UnusedVariable
			var entities1 = entityReposityry.Entities;
			// ReSharper disable once UnusedVariable
			var entities2 = entityReposityry.Entities;

			dataSource.Received(1).GetEntities();
		}
	}
}

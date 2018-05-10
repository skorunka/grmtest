// ReSharper disable InconsistentNaming
namespace Rr.Solutions.Grm.Data.Tests.UnitTests.Repositories.EntityRepository
{
	using System;
	using Data.Repositories;
	using Xunit;

	public class when_creating_instance
	{
		[Fact]
		public void throw_ArgumentNullException_if_dataSource_is_null()
		{
			var exception = Assert.Throws<ArgumentNullException>(() => new EntityRepository<int>(null));

			Assert.Equal("dataSource", exception.ParamName);
		}
	}
}

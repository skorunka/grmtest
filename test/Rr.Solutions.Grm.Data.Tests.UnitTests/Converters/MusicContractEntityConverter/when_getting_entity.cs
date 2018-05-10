// ReSharper disable InconsistentNaming

using System;
using System.Globalization;
using NSubstitute;
using Rr.Solutions.Grm.Data.Abstraction.Converters;
using Rr.Solutions.Grm.Entities;

namespace Rr.Solutions.Grm.Data.Tests.UnitTests.Converters.MusicContractEntityConverter
{
	using Xunit;

	public class when_getting_entity
	{

		[Fact]
		public void throw_ArgumentNullException_when_data_is_null()
		{
			var dateConverter = Substitute.For<IEntityConverter<DateTime>>();
			var musicUsageConverter = Substitute.For<IEntityConverter<MusicUsage>>();

			var dataSource = new Data.Converters.MusicContractEntityConverter(dateConverter, musicUsageConverter);

			var e = Assert.Throws<ArgumentNullException>(() => dataSource.GetEntity(null));

			Assert.Equal("data", e.ParamName);
		}

		[Fact]
		public void throw_Exception_if_data_length_is_lt_5()
		{
			var data = new[] { "Motörhead", "Ace of Spades", "digital download", "1st Feb 2012" };
			var dateConverter = Substitute.For<IEntityConverter<DateTime>>();
			var musicUsageConverter = Substitute.For<IEntityConverter<MusicUsage>>();

			var dataSource = new Data.Converters.MusicContractEntityConverter(dateConverter, musicUsageConverter);

			var e = Assert.Throws<ArgumentException>(() => dataSource.GetEntity(data));

			Assert.Equal("data", e.ParamName);
			Assert.StartsWith("Invalid input string. The number of elements must be at least 5.", e.Message);
		}

		[Fact]
		public void return_MusicContract_for_valid_data()
		{
			var data = new[] { "Motörhead", "Ace of Spades", "digital download", "1st Feb 2012", "25st Dec 2012" };
			var dateConverter = Substitute.For<IEntityConverter<DateTime>>();
			var musicUsageConverter = Substitute.For<IEntityConverter<MusicUsage>>();

			var dataSource = new Data.Converters.MusicContractEntityConverter(dateConverter, musicUsageConverter);

			var entity = dataSource.GetEntity(data);

			Assert.NotNull(entity);
			Assert.Equal("Motörhead", entity.ArtistName);
			Assert.Equal("Ace of Spades", entity.MusicTitle);
			Assert.Equal(MusicUsage.DigitalDownload, entity.Usages);
			Assert.Equal(new DateTime(2012, 2, 1), entity.ContractStartDate);
			Assert.Equal(new DateTime(2012, 12, 25), entity.ContractEndDate);
		}
	}
}
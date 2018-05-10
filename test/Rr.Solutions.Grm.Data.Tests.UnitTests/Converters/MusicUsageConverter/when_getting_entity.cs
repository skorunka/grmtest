// ReSharper disable InconsistentNaming

using System;
using Rr.Solutions.Grm.Entities;
using Xunit;

namespace Rr.Solutions.Grm.Data.Tests.UnitTests.Converters.MusicUsageConverter
{
	public class when_getting_entity
	{
		[Fact]
		public void return_MediaUssage_for_DigitalDownload()
		{
			var data = new[] { "digital download" };

			var dataSource = new Data.Converters.MusicUsageConverter();

			var entity = dataSource.GetEntity(data);

			Assert.Equal(MusicUsage.DigitalDownload, entity);
		}

		[Fact]
		public void return_MediaUssage_for_DigitalDownloadAndStreaming()
		{
			var data = new[] { "digital download, streaming" };

			var dataSource = new Data.Converters.MusicUsageConverter();

			var entity = dataSource.GetEntity(data);

			Assert.Equal(MusicUsage.Streaming | MusicUsage.DigitalDownload, entity);
		}

		[Fact]
		public void return_MediaUssage_for_Streaming()
		{
			var data = new[] { "streaming" };

			var dataSource = new Data.Converters.MusicUsageConverter();

			var entity = dataSource.GetEntity(data);

			Assert.Equal(MusicUsage.Streaming, entity);
		}

		[Fact]
		public void throw_ArgumentException_when_data_is_empty()
		{
			var e = Assert.Throws<ArgumentException>(() => new Data.Converters.MusicUsageConverter().GetEntity(new string[0]));

			Assert.Equal("data", e.ParamName);
			Assert.StartsWith("Data input is empty.", e.Message);
		}

		[Fact]
		public void throw_ArgumentException_when_data_is_invalid()
		{
			Assert.Throws<ArgumentException>(() => new Data.Converters.MusicUsageConverter().GetEntity(new[] { "xxx" }));
		}

		[Fact]
		public void throw_ArgumentNullException_when_data_is_null()
		{
			var e = Assert.Throws<ArgumentNullException>(() => new Data.Converters.MusicUsageConverter().GetEntity(null));

			Assert.Equal("data", e.ParamName);
		}
	}
}

// ReSharper disable InconsistentNaming

using System;
using Xunit;

namespace Rr.Solutions.Grm.Data.Tests.UnitTests.Converters.CsvInputDateTimeConverter
{
	public class when_getting_entity
	{
		[Theory]
		[InlineData("1st")]
		[InlineData("1st Dec")]
		public void throw_ArgumentException_when_data_is_invalid(string invalidString)
		{
			var e = Assert.Throws<ArgumentException>(() => new Data.Converters.CsvInputDateTimeConverter().GetEntity(new[] {invalidString}));

			Assert.Equal("data", e.ParamName);
			Assert.StartsWith("Invalid input string. The valid string is like \"1st Jan 2018\".", e.Message);
		}

		[Fact]
		public void return_Date_for_1stFeb2012()
		{
			var data = new[] {"1st Feb 2012"};

			var dataSource = new Data.Converters.CsvInputDateTimeConverter();

			var entity = dataSource.GetEntity(data);

			Assert.Equal(new DateTime(2012, 2, 1), entity);
		}

		[Fact]
		public void return_Date_for_25stDec2012()
		{
			var data = new[] {"25st Dec 2012"};

			var dataSource = new Data.Converters.CsvInputDateTimeConverter();

			var entity = dataSource.GetEntity(data);

			Assert.Equal(new DateTime(2012, 12, 25), entity);
		}

		[Fact]
		public void return_Date_for_25thDec2012()
		{
			var data = new[] {"25th Dec 2012"};

			var dataSource = new Data.Converters.CsvInputDateTimeConverter();

			var entity = dataSource.GetEntity(data);

			Assert.Equal(new DateTime(2012, 12, 25), entity);
		}

		[Fact]
		public void return_Date_for_2ndDec2012()
		{
			var data = new[] {"2nd Dec 2012"};

			var dataSource = new Data.Converters.CsvInputDateTimeConverter();

			var entity = dataSource.GetEntity(data);

			Assert.Equal(new DateTime(2012, 12, 2), entity);
		}

		[Fact]
		public void return_Date_for_3thDec2012()
		{
			var data = new[] {"3th Dec 2012"};

			var dataSource = new Data.Converters.CsvInputDateTimeConverter();

			var entity = dataSource.GetEntity(data);

			Assert.Equal(new DateTime(2012, 12, 3), entity);
		}

		[Fact]
		public void throw_ArgumentException_when_data_is_empty()
		{
			var e = Assert.Throws<ArgumentException>(() => new Data.Converters.CsvInputDateTimeConverter().GetEntity(new string[0]));

			Assert.Equal("data", e.ParamName);
			Assert.StartsWith("Data input is empty.", e.Message);
		}

		[Fact]
		public void throw_ArgumentNullException_when_data_is_null()
		{
			var e = Assert.Throws<ArgumentNullException>(() => new Data.Converters.CsvInputDateTimeConverter().GetEntity(null));

			Assert.Equal("data", e.ParamName);
		}
	}
}
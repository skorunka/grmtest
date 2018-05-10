// ReSharper disable InconsistentNaming
namespace Rr.Solutions.Grm.Data.Tests.UnitTests.DataSources.CsvFileDataSource
{
	using System;
	using Abstraction.Converters;
	using Data.DataSources;
	using NSubstitute;
	using Xunit;

	public class when_creating_instance
	{
		[Fact]
		public void throw_ArgumentNullException_if_converter_is_null()
		{
			var exception = Assert.Throws<ArgumentNullException>(() => new CsvFileDataSource<object>(null, "file.txt"));

			Assert.Equal("converter", exception.ParamName);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData(" ")]
		[InlineData("\n")]
		public void throw_ArgumentNullException_if_converter_IsNullOrWhiteSpace(string fileName)
		{
			var converter = Substitute.For<IEntityConverter<object>>();

			var exception = Assert.Throws<ArgumentException>(() => new CsvFileDataSource<object>(converter, fileName));

			Assert.Equal("fileName", exception.ParamName);
			Assert.StartsWith("Value cannot be null or whitespace.", exception.Message);
		}
	}
}

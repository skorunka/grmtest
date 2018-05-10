// ReSharper disable InconsistentNaming

using System.IO;
using Rr.Solutions.Grm.Data.Converters;
using Rr.Solutions.Grm.Data.DataSources;
using Rr.Solutions.Grm.Entities;

namespace Rr.Solutions.Grm.Tests.IntegrationTests.Data.DataSources
{
	using Xunit;

	public class CsvFileDataSourceUnitTest
	{
		private const string InputFolder = "_inputs/";
		private const string MusicContractsInputFile = InputFolder + "MusicContracts.csv";
		private const string DistributionPartnerContractsInputFile = InputFolder + "DistributionPartnerContracts.csv";

		[Fact]
		public void LoadMusicContracts()
		{
			var converter = new MusicContractEntityConverter(new CsvInputDateTimeConverter(), new MusicUsageConverter());
			var dataSource = new CsvFileDataSource<MusicContract>(converter, MusicContractsInputFile);

			var musicContracts = dataSource.GetEntities();

			Assert.NotEmpty(musicContracts);
		}
	}
}
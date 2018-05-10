namespace Rr.Solutions.Grm.Data.Converters
{
	using System;
	using Abstraction.Converters;
	using Entities;

	public class MusicContractEntityConverter : IEntityConverter<MusicContract>
	{
		private readonly IEntityConverter<DateTime> _dateTimeConverter;
		private readonly IEntityConverter<MusicUsage> _musicUsageConverter;

		#region ctors

		public MusicContractEntityConverter(IEntityConverter<DateTime> darteTimeConverter, IEntityConverter<MusicUsage> musicUsageConverter)
		{
			this._dateTimeConverter = darteTimeConverter ?? throw new ArgumentNullException(nameof(darteTimeConverter));
			this._musicUsageConverter = musicUsageConverter ?? throw new ArgumentNullException(nameof(musicUsageConverter));
		}

		#endregion

		public MusicContract GetEntity(string[] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			if (data.Length < 5)
			{
				throw new ArgumentException("Invalid input string. The number of elements must be at least 5.", nameof(data));
			}

			var entity = new MusicContract
			{
				ArtistName = data[0],
				MusicTitle = data[1],
				Usages = this._musicUsageConverter.GetEntity(new[] { data[2] }),
				ContractStartDate = this._dateTimeConverter.GetEntity(new[] { data[3] }),
				ContractEndDate = !string.IsNullOrEmpty(data[4]) ? (DateTime?)(this._dateTimeConverter.GetEntity(new[] { data[4] })) : null
			};

			return entity;
		}
	}
}

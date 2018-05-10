using System.Linq;
using Rr.Solutions.Grm.Entities;

namespace Rr.Solutions.Grm.Data.Converters
{
	using System;
	using Abstraction.Converters;

	public class MusicUsageConverter : IEntityConverter<MusicUsage>
	{
		public MusicUsage GetEntity(string[] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			if (!data.Any())
			{
				throw new ArgumentException("Data input is empty.", nameof(data));
			}

			var splits = data[0].Split(',');

			return splits.Skip(1).Aggregate(GetMusicUsage(splits[0]), (current, text) =>
			{
				return current | GetMusicUsage(text);
			});
		}

		private static MusicUsage GetMusicUsage(string text)
		{
			var musicUsage = (MusicUsage)Enum.Parse(typeof(MusicUsage), RemoveWhitespace(text), true);
			return musicUsage;
		}

		private static string RemoveWhitespace(string input)
		{
			var textWithoutWhiteSpace = new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
			return textWithoutWhiteSpace;
		}
	}
}

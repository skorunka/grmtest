using System.Linq;

namespace Rr.Solutions.Grm.Data.Converters
{
	using System;
	using Abstraction.Converters;
	public class CsvInputDateTimeConverter : IEntityConverter<DateTime>
	{
		public DateTime GetEntity(string[] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			if (!data.Any())
			{
				throw new ArgumentException("Data arrays is empty.", nameof(data));
			}

			var splits = data[0].Split(' ');


			if (splits.Length != 3)
			{
				throw new ArgumentException("Invalid input string. The valid string is like \"1st Jan 2018\".", nameof(data));
			}


			return DateTime.Parse($"{GetDayPart(splits[0])} {splits[1]} {splits[2]}");
		}

		private static string GetDayPart(string text)
		{
			var day = new string(text.Where(char.IsDigit).ToArray());
			return day;
		}
	}
}

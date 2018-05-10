namespace Rr.Solutions.Grm.Data.DataSources
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Threading.Tasks;
	using Abstraction.Converters;
	using Abstraction.DataSources;

	public class CsvFileDataSource<T> : IDataSource<T>
	{
		private const bool HasHeader = true;
		private const char DataRowDelimeter = '|';

		private readonly IEntityConverter<T> _converter;
		private readonly string _fileName;

		#region ctors

		public CsvFileDataSource(IEntityConverter<T> converter, string fileName)
		{
			this._converter = converter ?? throw new ArgumentNullException(nameof(converter));

			if (string.IsNullOrWhiteSpace(fileName))
			{
				throw new ArgumentException("Value cannot be null or whitespace.", nameof(fileName));
			}

			this._fileName = fileName;
		}

		#endregion

		public IEnumerable<T> GetEntities()
		{
			var entities = File.ReadAllLines(this._fileName)
								.Where(x => !string.IsNullOrWhiteSpace(x))
								.Skip(HasHeader ? 1 : 0)
								.Select(row => this._converter.GetEntity(GetRowData(row)))
								.Where(entity => entity != null);
			return entities;
		}

		private static string[] GetRowData(string row)
		{
			return row?.Split(DataRowDelimeter);
		}
	}
}
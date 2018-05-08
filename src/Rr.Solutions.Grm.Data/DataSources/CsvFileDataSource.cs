namespace Rr.Solutions.Grm.Data.DataSources
{
	using System;
	using System.Collections.Generic;
	using Abstraction.Converters;
	using Abstraction.DataSources;

	public class CsvFileDataSource<T> : IDataSource<T>
	{
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
			throw new NotImplementedException();
		}
	}
}
namespace Rr.Solutions.Grm.Entities
{
	using System;

	public class MusicContract
	{
		public string ArtistName { get; set; }

		public string MusicTitle { get; set; }

		public MusicUsage Usages { get; set; }

		public DateTime ContractStartDate { get; set; }

		public DateTime? ContractEndDate { get; set; }
	}
}

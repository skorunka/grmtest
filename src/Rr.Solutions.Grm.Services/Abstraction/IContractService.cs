namespace Rr.Solutions.Grm.Services.Abstraction
{
	using System;
	using System.Collections.Generic;
	using Entities;

	public interface IContractService
	{
		ICollection<MusicContract> GetAvailableContractsForPartner(string partnerName, DateTime effectiveDate);
	}
}

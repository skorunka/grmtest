namespace Rr.Solutions.Grm.Services
{
	using System;
	using System.Collections.Generic;
	using Abstraction;
	using Entities;

	public class ContractService : IContractService
	{
		public ICollection<MusicContract> GetAvailableContractsForPartner(string partnerName, DateTime effectiveDate)
		{
			throw new NotImplementedException();
		}
	}
}

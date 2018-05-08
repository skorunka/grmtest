namespace Rr.Solutions.Grm.Services
{
	using System;
	using System.Collections.Generic;
	using Abstraction;
	using Data.Abstraction.Repositories;
	using Entities;

	public class ContractService : IContractService
	{
		private readonly IEntityRepository<MusicContract> _musicContractRepository;
		private readonly IEntityRepository<PartnerContract> _partnerContractRepository;

		#region ctors

		public ContractService(IEntityRepository<MusicContract> musicContractRepository, IEntityRepository<PartnerContract> partnerContractRepository)
		{
			this._musicContractRepository = musicContractRepository ?? throw new ArgumentNullException(nameof(musicContractRepository));
			this._partnerContractRepository = partnerContractRepository ?? throw new ArgumentNullException(nameof(partnerContractRepository));
		}

		#endregion

		public ICollection<MusicContract> GetAvailableContractsForPartner(string partnerName, DateTime effectiveDate)
		{
			throw new NotImplementedException();
		}
	}
}

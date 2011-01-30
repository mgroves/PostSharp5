using System.Collections.Generic;

namespace TransactionManagement
{
    public interface ICharityService
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        IEnumerable<Charity> GetAllWhoResponded();
        void UpdateACharity();
    }
}
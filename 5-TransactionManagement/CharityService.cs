using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TransactionManagement
{
    public class CharityService : ICharityService
    {
        private ILogService _logService;
        private readonly IList<Charity> _charityDatabase;

        public CharityService()
        {
            _charityDatabase = PreprogrammedCharities.ToList();
            _logService = new LogService();
        }

        // since we're not hooked up to a real data layer, these are just standins for demonstration
        public void BeginTransaction()
        {
            _logService.AddLogMessage("BeginTransaction");
        }
        public void CommitTransaction()
        {
            _logService.AddLogMessage("CommitTransaction");
        }
        public void RollbackTransaction()
        {
            _logService.AddLogMessage("RollbackTransaction");
        }

        [TransactionScope]
        public IEnumerable<Charity> GetAllWhoResponded()
        {
            SimulateUnreliableService();

            return _charityDatabase;
        }

        [TransactionScope]
        public void UpdateACharity()
        {
            SimulateUnreliableService();

            _charityDatabase[0].Name = PreprogrammedCharities.First().Name + " " + DateTime.Now.Millisecond;
        }

        private static void SimulateUnreliableService()
        {
            var rand = (new Random(DateTime.Now.Millisecond)).Next(0, 50);
            if (rand == 2)
            {
                throw new Exception("Some unknown exception");
            }
            if (rand % 2 == 0)
            {
                throw new DataException("Some exception you might have expected");
            }
        }

        private static IEnumerable<Charity> PreprogrammedCharities
        {
            get
            {
                var list = new List<Charity>();
                list.Add(new Charity { Name = "Sisters of Mercy Bingo Night", CIN = "98-280912", CountyName = "Franklin"});
                list.Add(new Charity { Name = "Humane Association", CIN = "95-343121", CountyName = "Fairfield"});
                list.Add(new Charity { Name = "Salvation Army--Newark Branch", CIN = "15-343123", CountyName = "Licking"});
                list.Add(new Charity { Name = "Salvation Army--Columbus Branch", CIN = "15-343123", CountyName = "Franklin"});
                return list;
            }
        }
    }
}
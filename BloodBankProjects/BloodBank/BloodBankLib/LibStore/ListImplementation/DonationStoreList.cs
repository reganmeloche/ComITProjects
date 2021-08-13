using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBankLib;

namespace BloodBankLib.LibStore
{
    public class DonationStoreList : IDonationStore
    {
        readonly List<Donation> _innerList; 

        public DonationStoreList(List<Donation> innerList) {
            _innerList = innerList ?? new List<Donation>();
        }

        // Should we return a copy of it?
        // May also want to do a generic collection, rather than a list...
        public Task<List<Donation>> GetAll() {
            return Task.FromResult(_innerList);
        }

        public Task Save(Donation donation) {
            _innerList.Add(donation);
            return Task.CompletedTask;
        }

        // Will this work?
        public Task Remove(Donation donation) {
            _innerList.Remove(donation);
            return Task.CompletedTask;
        }
    }
}

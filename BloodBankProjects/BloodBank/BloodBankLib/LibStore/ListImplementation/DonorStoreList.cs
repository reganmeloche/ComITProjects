using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBankLib;

namespace BloodBankLib.LibStore
{
    public class DonorStoreList : IDonorStore
    {
        private readonly List<Donor> _innerList; 

        public DonorStoreList(List<Donor> innerList) {
            _innerList = innerList ?? new List<Donor>();
        }

        public Task<List<Donor>> GetAll() {
            return Task.FromResult(_innerList);
        }

        public Task Save(Donor donor) {
            _innerList.Add(donor);
            return Task.CompletedTask;
        }
    }
}

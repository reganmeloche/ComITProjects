using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBankLib;

namespace BloodBankLib.LibStore
{
    public class ReceiverStoreList : IReceiverStore
    {
        private readonly List<Receiver> _innerList; 

        public ReceiverStoreList(List<Receiver> innerList) {
            _innerList = innerList ?? new List<Receiver>();
        }

        public Task<List<Receiver>> GetAll() {
            return Task.FromResult(_innerList);
        }

        public Task Save(Receiver receiver) {
            _innerList.Add(receiver);
            return Task.CompletedTask;
        }
    }
}

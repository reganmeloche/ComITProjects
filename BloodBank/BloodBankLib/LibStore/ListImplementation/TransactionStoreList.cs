using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBankLib;

namespace BloodBankLib.LibStore
{
    public class TransactionStoreList : ITransactionStore
    {
        readonly List<Transaction> _innerList; 

        public TransactionStoreList(List<Transaction> innerList) {
            _innerList = innerList ?? new List<Transaction>();
        }

        // Should we return a copy of it?
        // May also want to do a generic collection, rather than a list...
        public Task<List<Transaction>> GetAll() {
            return Task.FromResult(_innerList);
        }

        public Task Save(Transaction transaction) {
            _innerList.Add(transaction);
            return Task.CompletedTask;
        }
    }
}

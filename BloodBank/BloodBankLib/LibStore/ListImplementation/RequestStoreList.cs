using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBankLib;

namespace BloodBankLib.LibStore
{
    public class RequestStoreList : IRequestStore
    {
        readonly List<Request> _innerList; 

        public RequestStoreList(List<Request> innerList) {
            _innerList = innerList ?? new List<Request>();
        }

        // Should we return a copy of it?
        // May also want to do a generic collection, rather than a list...
        public Task<List<Request>> GetAll() {
            return Task.FromResult(_innerList);
        }

        public Task Save(Request request) {
            _innerList.Add(request);
            return Task.CompletedTask;
        }

        // Will this work?
        public Task Remove(Request request) {
            _innerList.Remove(request);
            return Task.CompletedTask;
        }
    }
}

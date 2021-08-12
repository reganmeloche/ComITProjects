using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodBankLib;
using BloodBankDB;

namespace BloodBankLib.LibStore
{
    public class RequestStoreDB : IRequestStore
    {
        private readonly MainDB _db;

        public RequestStoreDB(MainDB db) {
            _db = db;
        }

        public async Task<List<Request>> GetAll() {
            var result = new List<Request>();
            var dbResults = await _db.RequestDB.GetAll();
            foreach (var dbResult in dbResults) {
                var receiverDBModel = await _db.ReceiverDB.Get(dbResult.ReceiverId);
                BloodType bloodType = new BloodType(receiverDBModel.BloodType);
                Receiver receiver = new Receiver(receiverDBModel.FirstName, receiverDBModel.LastName, DateTime.Now, bloodType);
                var nextResult = new Request(dbResult.RequestId, receiver, dbResult.RequestDate);
                result.Add(nextResult);
            }
            return result;
        }

        public async Task Save(Request request) {
            var dbModel = new RequestDBModel(request.RequestId, request.DateRequested, request.Receiver.CardId, false);
            await _db.RequestDB.Save(dbModel);
        }

        public async Task Remove(Request request) {
            var dbModel = new RequestDBModel(request.RequestId, request.DateRequested, request.Receiver.CardId, true);
            await _db.RequestDB.Save(dbModel);
        }
    }
}

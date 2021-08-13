using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodBankLib;
using BloodBankDB;

namespace BloodBankLib.LibStore
{
    public class ReceiverStoreDB : IReceiverStore
    {
        private readonly MainDB _db;

        public ReceiverStoreDB(MainDB db) {
            _db = db;
        }

        public async Task<List<Receiver>> GetAll() {
            var result = new List<Receiver>();
            var dbResults = await _db.ReceiverDB.GetAll();
            foreach (var dbResult in dbResults) {
                var bloodType = new BloodType(dbResult.BloodType);
                var nextResult = new Receiver(dbResult.FirstName, dbResult.LastName, DateTime.Now, bloodType);
                result.Add(nextResult);
            }
            return result;
        }

        public async Task Save(Receiver receiver) {
            var dbModel = new ReceiverDBModel(receiver.CardId, receiver.FirstName, receiver.LastName, receiver.BloodType.ToString());
            await _db.ReceiverDB.Save(dbModel); 
        }
    }
}

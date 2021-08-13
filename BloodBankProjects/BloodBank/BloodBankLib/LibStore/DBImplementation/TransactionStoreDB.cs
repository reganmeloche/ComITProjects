using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodBankLib;
using BloodBankDB;

namespace BloodBankLib.LibStore
{
    public class TransactionStoreDB : ITransactionStore
    {
        private readonly MainDB _db;

        public TransactionStoreDB(MainDB db) {
            _db = db;
        }

        public async Task<List<Transaction>> GetAll() {
            var result = new List<Transaction>();
            var dbResults = await _db.TransactionDB.GetAll();
            foreach (var dbResult in dbResults) {
                var donationDBModel = await _db.DonationDB.Get(dbResult.DonationId);
                var donorDBModel = await _db.DonorDB.Get(donationDBModel.DonorId);    
                BloodType donorBloodType = new BloodType(donorDBModel.BloodType);
                Donor donor = new Donor(donorDBModel.FirstName, donorDBModel.LastName, DateTime.Now, donorBloodType);
                Donation donation = new Donation(donationDBModel.DonationId, donor, donationDBModel.DonationDate, donationDBModel.Verified);

                var requestDBModel = await _db.RequestDB.Get(dbResult.RequestId);
                var receiverDBModel = await _db.ReceiverDB.Get(requestDBModel.ReceiverId);
                BloodType receiverBloodType = new BloodType(receiverDBModel.BloodType);
                Receiver receiver = new Receiver(receiverDBModel.FirstName, receiverDBModel.LastName, DateTime.Now, receiverBloodType);
                Request request = new Request(requestDBModel.RequestId, receiver, requestDBModel.RequestDate);

                var nextResult = new Transaction(dbResult.TransactionId, donation, request, dbResult.TransactionDate);
                result.Add(nextResult);
            }
            return result;
        }

        public async Task Save(Transaction transaction) {
            var dbModel = new TransactionDBModel(transaction.TransactionId, transaction.TransactionDate, transaction.Request.RequestId, transaction.Donation.DonationId);
            await _db.TransactionDB.Save(dbModel);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodBankLib;
using BloodBankDB;

namespace BloodBankLib.LibStore
{
    public class DonationStoreDB : IDonationStore
    {
        private readonly MainDB _db;
        
        public DonationStoreDB(MainDB db) {
            _db = db;
        }

        public async Task<List<Donation>> GetAll() {
            var result = new List<Donation>();
            var dbResults = await _db.DonationDB.GetAll();
            foreach (var dbResult in dbResults) {
                var donorDBModel = await _db.DonorDB.Get(dbResult.DonorId);
                BloodType bloodType = new BloodType(donorDBModel.BloodType);
                Donor donor = new Donor(donorDBModel.FirstName, donorDBModel.LastName, DateTime.Now, bloodType);
                var nextResult = new Donation(dbResult.DonationId, donor, dbResult.DonationDate, dbResult.Verified);
                result.Add(nextResult);
            }
            return result;
        }

        public async Task Save(Donation donation) {
            var dbModel = new DonationDBModel(donation.DonationId, donation.DateTaken, donation.Donor.CardId, donation.Verified, false);
            await _db.DonationDB.Save(dbModel);
        }

        public async Task Remove(Donation donation) {
            var dbModel = new DonationDBModel(donation.DonationId, donation.DateTaken, donation.Donor.CardId, donation.Verified, true);
            await _db.DonationDB.Save(dbModel);
        }
    }
}

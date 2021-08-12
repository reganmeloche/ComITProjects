using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodBankLib;
using BloodBankDB;

namespace BloodBankLib.LibStore
{
    public class DonorStoreDB : IDonorStore
    {
        private readonly MainDB _db;

        public DonorStoreDB(MainDB db) {
            _db = db;
        }

        public async Task<List<Donor>> GetAll() {
            var result = new List<Donor>();
            var dbResults = await _db.DonorDB.GetAll();
            foreach (var dbResult in dbResults) {
                var bloodType = new BloodType(dbResult.BloodType);
                var nextResult = new Donor(dbResult.FirstName, dbResult.LastName, DateTime.Now, bloodType);
                result.Add(nextResult);
            }
            return result;
        }

        public async Task Save(Donor donor) {
            var dbModel = new DonorDBModel(donor.CardId, donor.FirstName, donor.LastName, donor.BloodType.ToString(), donor.LastDonationDate, donor.TimesDonated);
            await _db.DonorDB.Save(dbModel);
        }
    }
}

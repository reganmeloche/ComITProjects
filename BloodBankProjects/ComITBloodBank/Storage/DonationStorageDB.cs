using System;
using System.Collections.Generic;
using Npgsql;

using BloodClinic.Models;

namespace BloodClinic.Storage
{
    public class DonationStorageDB : IStoreDonations
    {
        readonly NpgsqlConnection _conn;
        readonly IStoreDonors _donorStorage;

        public DonationStorageDB(NpgsqlConnection conn, IStoreDonors donorStorage) {
            _conn = conn;
            _donorStorage = donorStorage;
        }

        public void Create(Donation model) {
            using (var cmd = new NpgsqlCommand(@"
                INSERT INTO donation as d (id, donation_date, donor_id) 
                VALUES (@a, @b, @c)
                ", 
                _conn))
            {
                cmd.Parameters.AddWithValue("a", model.Id);
                cmd.Parameters.AddWithValue("b", model.DonationDate);
                cmd.Parameters.AddWithValue("c", model.Donor.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Donation> GetAll() {
            // Get all donations first
            var result = new List<Donation>();
            using (var cmd = new NpgsqlCommand(@"SELECT * FROM donation", _conn)) {
                using (var reader = cmd.ExecuteReader()) {
                    while (reader.Read()){
                        var nextResult = ConvertFromDb(reader);
                        result.Add(nextResult);
                    }
                } 
            }     

            foreach (var donation in result) {
                var donor = _donorStorage.GetById(donation.Donor.Id);
                donation.Donor = donor;
            }

            return result;
        }
        public void Remove(Donation donationToRemove) {
            using (var cmd = new NpgsqlCommand("DELETE FROM donation WHERE id = @a", _conn)) {          
                cmd.Parameters.AddWithValue("a", donationToRemove.Id);
                cmd.ExecuteNonQuery();
            }     
        }
    
        private Donation ConvertFromDb(NpgsqlDataReader reader) {
            Guid donationId = Guid.Parse(Convert.ToString(reader["id"]));
            DateTime donationDate = Convert.ToDateTime(reader["donation_date"]);
            Guid donorId = Guid.Parse(Convert.ToString(reader["donor_id"]));
            
            Donor donor = new Donor("","", new DateTime(), null, "") {
                Id = donorId
            };
            

            return new Donation() {
                Id = donationId,
                DonationDate = donationDate,
                Donor = donor
            };
        }
    }
}
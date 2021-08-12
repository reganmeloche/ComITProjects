using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;

namespace BloodBankDB
{
    public class DonationDBModel
    {
        public Guid DonationId {get;}
        public DateTime DonationDate {get;}
        public Guid DonorId {get;}
        public bool Verified {get;}
        public bool Completed {get;}

        public DonationDBModel(Guid donationId, DateTime donationDate, Guid donorId, bool verified, bool completed) {
            DonationId = donationId;
            DonationDate = donationDate;
            DonorId = donorId;
            Verified = verified;
            Completed = completed;
        }        
    }

    public class DonationDB {
        readonly NpgsqlConnection _conn;

        public DonationDB(NpgsqlConnection conn) {
            _conn = conn;
        }

        public async Task Save(DonationDBModel model) {
            using (var cmd = new NpgsqlCommand(@"
                INSERT INTO donations as d (id, donation_date, donor_id, verified, completed) 
                VALUES (@a, @b, @c, @d, @e)
                ON CONFLICT (id) 
                DO UPDATE
                SET completed = @d
                WHERE d.id = @a
                ", 
                _conn))
            {
                cmd.Parameters.AddWithValue("a", model.DonationId);
                cmd.Parameters.AddWithValue("b", model.DonationDate);
                cmd.Parameters.AddWithValue("c", model.DonorId);
                cmd.Parameters.AddWithValue("d", model.Verified);
                cmd.Parameters.AddWithValue("e", model.Completed);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<List<DonationDBModel>> GetAll() {
            var result = new List<DonationDBModel>();
            using (var cmd = new NpgsqlCommand("SELECT * FROM donations where completed = false", _conn)) {
                using (var reader = await cmd.ExecuteReaderAsync()) {
                    while (await reader.ReadAsync()){
                        var nextResult = ConvertFromDb(reader);
                        result.Add(nextResult);
                    }
                    return result;
                } 
            }     
        }
        public async Task<DonationDBModel> Get(Guid donationId) {
            DonationDBModel result = null;
            using (var cmd = new NpgsqlCommand("SELECT * FROM donations where id = @a", _conn)) {          
                cmd.Parameters.AddWithValue("a", donationId);
                using (var reader = await cmd.ExecuteReaderAsync()) {
                    var hasDbValue = await reader.ReadAsync();
                    if (hasDbValue) {
                        result = ConvertFromDb(reader);
                    }
                    return result;
                } 
            }     
        }
    
        private DonationDBModel ConvertFromDb(NpgsqlDataReader reader) {
            Guid donationId = Guid.Parse(Convert.ToString(reader["id"]));
            DateTime donationDate = Convert.ToDateTime(reader["donation_date"]);
            Guid donorId = Guid.Parse(Convert.ToString(reader["donor_id"]));
            bool verified = Convert.ToBoolean(reader["verified"]);
            bool completed = Convert.ToBoolean(reader["completed"]);
            
            return new DonationDBModel(donationId, donationDate, donorId, verified, completed);
        }
    
    }
}

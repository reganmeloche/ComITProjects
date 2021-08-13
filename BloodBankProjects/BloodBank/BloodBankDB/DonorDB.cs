using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;

namespace BloodBankDB
{
    public class DonorDBModel
    {
        public Guid CardId {get;set;}
        public string FirstName {get;}
        public string LastName {get;}
        public string BloodType {get;}
        public DateTime? LastDonationDate {get;}
        public int NumTimesDonated {get;}

        public DonorDBModel(Guid cardId, string firstName, string lastName, string bloodType, DateTime? lastDonationDate, int numTimesDonated) {
            CardId = cardId;
            FirstName = firstName;
            LastName = lastName;
            BloodType = bloodType;
            LastDonationDate = lastDonationDate;
            NumTimesDonated = numTimesDonated;
        }        
    }

    public class DonorDB {
        readonly NpgsqlConnection _conn;

        public DonorDB(NpgsqlConnection conn) {
            _conn = conn;
        }

        public async Task Save(DonorDBModel model) {
            using (var cmd = new NpgsqlCommand(@"
                INSERT INTO donors as d (id, first_name, last_name, blood_type, last_donation_date, num_times_donated) 
                VALUES (@a, @b, @c, @d, @e, @f)
                ON CONFLICT (id)
                DO UPDATE
                SET last_donation_date = @e,
                    num_times_donated = @f
                WHERE d.id = @a", 
                _conn))
            {
                cmd.Parameters.AddWithValue("a", model.CardId);
                cmd.Parameters.AddWithValue("b", model.FirstName);
                cmd.Parameters.AddWithValue("c", model.LastName);
                cmd.Parameters.AddWithValue("d", model.BloodType);
                if (model.LastDonationDate.HasValue) {
                    cmd.Parameters.AddWithValue("e", model.LastDonationDate.Value);
                } else {
                    cmd.Parameters.AddWithValue("e", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("f", model.NumTimesDonated);
                await cmd.ExecuteNonQueryAsync();
            }
        }
    
        public async Task<List<DonorDBModel>> GetAll() {
            var result = new List<DonorDBModel>();
            using (var cmd = new NpgsqlCommand("SELECT * FROM donors", _conn)) {
                using (var reader = await cmd.ExecuteReaderAsync()) {
                    while (await reader.ReadAsync()) {
                        var nextResult = ConvertFromDb(reader);
                        result.Add(nextResult);
                    }
                    return result;
                } 
            }     
        }
    
        public async Task<DonorDBModel> Get(Guid donorId) {
            DonorDBModel result = null;
            using (var cmd = new NpgsqlCommand("SELECT * FROM donors where id = @a", _conn)) {          
                cmd.Parameters.AddWithValue("a", donorId);
                using (var reader = await cmd.ExecuteReaderAsync()) {
                    var hasDbValue = await reader.ReadAsync();
                    if (hasDbValue) {
                        result = ConvertFromDb(reader);
                    }
                    return result;
                } 
            }     
        }
    
        private DonorDBModel ConvertFromDb(NpgsqlDataReader reader) {
            Guid cardId = Guid.Parse(Convert.ToString(reader["id"]));
            string firstName = Convert.ToString(reader["first_name"]);
            string lastName = Convert.ToString(Convert.ToString(reader["last_name"]));
            string bloodType = Convert.ToString(reader["blood_type"]);
            DateTime lastDonationDate = Convert.ToDateTime(reader["last_donation_date"]);
            int numTimesDonated = Convert.ToInt32(reader["num_times_donated"]);
            
            return new DonorDBModel(cardId, firstName, lastName, bloodType, lastDonationDate, numTimesDonated);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;

namespace BloodBankDB
{
    public class ReceiverDBModel
    {
        public Guid CardId {get;}
        public string FirstName {get;}
        public string LastName {get;}
        public string BloodType {get;}

        public ReceiverDBModel(Guid cardId, string firstName, string lastName, string bloodType) {
            CardId = cardId;
            FirstName = firstName;
            LastName = lastName;
            BloodType = bloodType;
        }        
    }

    public class ReceiverDB {
        readonly NpgsqlConnection _conn;

        public ReceiverDB(NpgsqlConnection conn) {
            _conn = conn;
        }

        public async Task Save(ReceiverDBModel model) {
            using (var cmd = new NpgsqlCommand(@"
                INSERT INTO receivers (id, first_name, last_name, blood_type) 
                VALUES (@a, @b, @c, @d)", 
                _conn))
            {
                cmd.Parameters.AddWithValue("a", model.CardId);
                cmd.Parameters.AddWithValue("b", model.FirstName);
                cmd.Parameters.AddWithValue("c", model.LastName);
                cmd.Parameters.AddWithValue("d", model.BloodType);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<List<ReceiverDBModel>> GetAll() {
            var result = new List<ReceiverDBModel>();
            using (var cmd = new NpgsqlCommand("SELECT * FROM receivers", _conn)) {
                using (var reader = await cmd.ExecuteReaderAsync()) {
                    while (await reader.ReadAsync()){
                        Guid cardId = Guid.Parse(Convert.ToString(reader["id"]));
                        string firstName = Convert.ToString(reader["first_name"]);
                        string lastName = Convert.ToString(Convert.ToString(reader["last_name"]));
                        string bloodType = Convert.ToString(reader["blood_type"]);
                        var nextResult = new ReceiverDBModel(cardId, firstName, lastName, bloodType);
                        result.Add(nextResult);
                    }
                    return result;
                } 
            }     
        }

        public async Task<ReceiverDBModel> Get(Guid receiverId) {
            ReceiverDBModel result = null;
            using (var cmd = new NpgsqlCommand("SELECT * FROM receivers where id = @a", _conn)) {          
                cmd.Parameters.AddWithValue("a", receiverId);
                using (var reader = await cmd.ExecuteReaderAsync()) {
                    var hasDbValue = await reader.ReadAsync();
                    if (hasDbValue) {
                        result = ConvertFromDb(reader);
                    }
                    return result;
                } 
            }     
        }
    
        private ReceiverDBModel ConvertFromDb(NpgsqlDataReader reader) {
            Guid cardId = Guid.Parse(Convert.ToString(reader["id"]));
            string firstName = Convert.ToString(reader["first_name"]);
            string lastName = Convert.ToString(Convert.ToString(reader["last_name"]));
            string bloodType = Convert.ToString(reader["blood_type"]);
            
            return new ReceiverDBModel(cardId, firstName, lastName, bloodType);
        }
    }
}

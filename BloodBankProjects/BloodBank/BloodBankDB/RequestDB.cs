using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;

namespace BloodBankDB
{
    public class RequestDBModel
    {
        public Guid RequestId {get;}
        public DateTime RequestDate {get;}
        public Guid ReceiverId {get;}
        public bool Completed {get;}

        public RequestDBModel(Guid requestId, DateTime requestDate, Guid receiverId, bool completed) {
            RequestId = requestId;
            RequestDate = requestDate;
            ReceiverId = receiverId;
            Completed = completed;
        }        
    }

    public class RequestDB {
        readonly NpgsqlConnection _conn;

        public RequestDB(NpgsqlConnection conn) {
            _conn = conn;
        }

        public async Task Save(RequestDBModel model) {
            using (var cmd = new NpgsqlCommand(@"
                INSERT INTO requests as r (id, request_date, receiver_id, completed) 
                VALUES (@a, @b, @c, @d)
                ON CONFLICT (id) 
                DO UPDATE
                SET completed = @d
                WHERE r.id = @a", 
                _conn))
            {
                cmd.Parameters.AddWithValue("a", model.RequestId);
                cmd.Parameters.AddWithValue("b", model.RequestDate);
                cmd.Parameters.AddWithValue("c", model.ReceiverId);
                cmd.Parameters.AddWithValue("d", model.Completed);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<List<RequestDBModel>> GetAll() {
            var result = new List<RequestDBModel>();
            using (var cmd = new NpgsqlCommand("SELECT * FROM requests where completed = false", _conn)) {
                using (var reader = await cmd.ExecuteReaderAsync()) {
                    while (await reader.ReadAsync()){
                        var nextResult = ConvertFromDb(reader);
                        result.Add(nextResult);
                    }
                    return result;
                } 
            }     
        }

        public async Task<RequestDBModel> Get(Guid requestId) {
            RequestDBModel result = null;
            using (var cmd = new NpgsqlCommand("SELECT * FROM requests where id = @a", _conn)) {          
                cmd.Parameters.AddWithValue("a", requestId);
                using (var reader = await cmd.ExecuteReaderAsync()) {
                    var hasDbValue = await reader.ReadAsync();
                    if (hasDbValue) {
                        result = ConvertFromDb(reader);
                    }
                    return result;
                } 
            }     
        }
    
        private RequestDBModel ConvertFromDb(NpgsqlDataReader reader) {
            Guid requestId = Guid.Parse(Convert.ToString(reader["id"]));
            DateTime requestDate = Convert.ToDateTime(reader["request_date"]);
            Guid receiverId = Guid.Parse(Convert.ToString(reader["receiver_id"]));
            bool completed = Convert.ToBoolean(reader["completed"]);
            return new RequestDBModel(requestId, requestDate, receiverId, completed);
        }
    
    }
}

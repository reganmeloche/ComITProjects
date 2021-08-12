using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;

namespace BloodBankDB
{
    public class TransactionDBModel
    {
        public Guid TransactionId {get;}
        public DateTime TransactionDate {get;}
        public Guid RequestId {get;}
        public Guid DonationId {get;}

        public TransactionDBModel(Guid transactionId, DateTime transactionDate, Guid requestId, Guid donationId) {
            TransactionId = transactionId;
            TransactionDate = transactionDate;
            RequestId = requestId;
            DonationId = donationId;
        }        
    }

    public class TransactionDB {
        readonly NpgsqlConnection _conn;

        public TransactionDB(NpgsqlConnection conn) {
            _conn = conn;
        }

        public async Task Save(TransactionDBModel model) {
            using (var cmd = new NpgsqlCommand(@"
                INSERT INTO transactions (id, transaction_date, request_id, donation_id) 
                VALUES (@a, @b, @c, @d)", 
                _conn))
            {
                cmd.Parameters.AddWithValue("a", model.TransactionId);
                cmd.Parameters.AddWithValue("b", model.TransactionDate);
                cmd.Parameters.AddWithValue("c", model.RequestId);
                cmd.Parameters.AddWithValue("d", model.DonationId);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<List<TransactionDBModel>> GetAll() {
            var result = new List<TransactionDBModel>();
            using (var cmd = new NpgsqlCommand("SELECT * FROM transactions", _conn)) {
                using (var reader = await cmd.ExecuteReaderAsync()) {
                    while (await reader.ReadAsync()){
                        Guid transactionId = Guid.Parse(Convert.ToString(reader["id"]));
                        DateTime transactionDate = Convert.ToDateTime(reader["transaction_date"]);
                        Guid requestId = Guid.Parse(Convert.ToString(reader["request_id"]));
                        Guid donationId = Guid.Parse(Convert.ToString(reader["donation_id"]));
                        var nextResult = new TransactionDBModel(transactionId, transactionDate, requestId, donationId);
                        result.Add(nextResult);
                    }
                    return result;
                } 
            }     
        }
    
    }
}

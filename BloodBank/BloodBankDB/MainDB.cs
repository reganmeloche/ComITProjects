using System;
using System.Collections.Generic;
using Npgsql;
using System.Threading.Tasks;

namespace BloodBankDB
{
    public class MainDB
    {
        readonly string connectionString = "";

        public DonorDB DonorDB {get; private set; }
        public ReceiverDB ReceiverDB {get; private set;}
        public RequestDB RequestDB {get; private set;}
        public DonationDB DonationDB {get; private set;}
        public TransactionDB TransactionDB {get; private set;}


        public async Task StartDBs() {
            var conn = new NpgsqlConnection(connectionString);
            await conn.OpenAsync();

            DonorDB = new DonorDB(conn);
            ReceiverDB = new ReceiverDB(conn);
            RequestDB = new RequestDB(conn);
            DonationDB = new DonationDB(conn);
            TransactionDB = new TransactionDB(conn);
        }

    }
}

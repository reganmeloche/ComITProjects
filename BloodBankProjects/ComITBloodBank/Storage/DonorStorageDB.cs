using System;
using System.Collections.Generic;
using Npgsql;
using BloodClinic.Models;

namespace BloodClinic.Storage
{
    public class DonorStorageDB : IStoreDonors
    {

        readonly NpgsqlConnection _conn;

        public DonorStorageDB(NpgsqlConnection conn) {
            _conn = conn;
        }

        public void Create(Donor model) {
            using (var cmd = new NpgsqlCommand(@"
                INSERT INTO donor (id, first_name, last_name, blood_type) 
                VALUES (@a, @b, @c, @d)
                ", 
                _conn))
            {
                cmd.Parameters.AddWithValue("a", model.Id);
                cmd.Parameters.AddWithValue("b", model.FirstName);
                cmd.Parameters.AddWithValue("c", model.LastName);
                cmd.Parameters.AddWithValue("d", model.MemberBloodType.ToString());
                cmd.ExecuteNonQuery();
            }
        }

        public List<Donor> GetAll() {
            var result = new List<Donor>();
            using (var cmd = new NpgsqlCommand(@"SELECT * FROM donor", _conn)) {
                using (var reader = cmd.ExecuteReader()) {
                    while (reader.Read()){
                        var nextResult = ConvertFromDb(reader);
                        result.Add(nextResult);
                    }
                    return result;
                } 
            }     
        }

        public Donor GetById(Guid donorId) {
            Donor result = null;
            using (var cmd = new NpgsqlCommand("SELECT * FROM donor WHERE id = @a", _conn)) {          
                cmd.Parameters.AddWithValue("a", donorId);
                using (var reader = cmd.ExecuteReader()) {
                    var hasDbValue = reader.Read();
                    if (hasDbValue) {
                        result = ConvertFromDb(reader);
                    }
                    return result;
                } 
            }     
        }

        private Donor ConvertFromDb(NpgsqlDataReader reader) {
            Guid donorId = Guid.Parse(Convert.ToString(reader["id"]));
            string firstName = Convert.ToString(reader["first_name"]);
            string lastName = Convert.ToString(reader["last_name"]);
            string bloodType = Convert.ToString(reader["blood_type"]);

            var memberBloodType = new BloodType(bloodType);

            return new Donor(donorId, firstName, lastName, memberBloodType);
        }
    }
}
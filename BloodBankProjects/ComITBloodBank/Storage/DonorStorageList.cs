using System;
using System.Collections.Generic;

using BloodClinic.Models;

namespace BloodClinic.Storage
{
    public class DonorStorageList : IStoreDonors
    {
        private List<Donor> _donors;

        public DonorStorageList() {
            _donors = new List<Donor>();
        }

        public void Create(Donor donorToCreate) {
            _donors.Add(donorToCreate);
        }

        public Donor GetById(Guid donorId) {
            Donor donor = null;
            
            for (int i = 0; i < _donors.Count; i++) {
                if (_donors[i].Id == donorId) {
                    Console.WriteLine($"Found Donor! {_donors[i].FullName}");
                    donor = _donors[i];
                }
            }

            if (donor == null) {
                throw new Exception($"Donor {donorId} not found!");
            }
            return donor;
        }

        public List<Donor> GetAll() {
            return _donors;
        }
    }
}
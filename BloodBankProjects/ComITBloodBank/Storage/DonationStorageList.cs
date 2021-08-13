using System;
using System.Collections.Generic;

using BloodClinic.Models;

namespace BloodClinic.Storage
{
    public class DonationStorageList : IStoreDonations
    {
        private List<Donation> _innerList;

        public DonationStorageList() {
            _innerList = new List<Donation>();
        }
        
        public void Create(Donation newDonation) {
            _innerList.Add(newDonation);
        }

        public List<Donation> GetAll() {
            return _innerList;
        }

        public void Remove(Donation donationToRemove) {
            _innerList.Remove(donationToRemove);
        }
    }
}
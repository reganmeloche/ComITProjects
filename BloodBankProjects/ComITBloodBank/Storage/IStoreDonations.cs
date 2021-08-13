using System;
using System.Collections.Generic;

using BloodClinic.Models;

namespace BloodClinic.Storage
{
    public interface IStoreDonations {
        void Create(Donation newDonation);
        List<Donation> GetAll();
        void Remove(Donation donationToRemove);
    }
}
using System;
using System.Collections.Generic;

using BloodClinic.Models;

namespace BloodClinic.Storage
{
    public interface IStoreDonors
    {
        void Create(Donor donorToCreate);
        Donor GetById(Guid donorId);
        List<Donor> GetAll();
    }
}
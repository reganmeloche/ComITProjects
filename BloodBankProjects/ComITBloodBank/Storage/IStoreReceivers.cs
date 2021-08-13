using System;
using System.Collections.Generic;

using BloodClinic.Models;

namespace BloodClinic.Storage
{
    public interface IStoreReceivers
    {
        void Create(Receiver receiverToCreate);
        Receiver GetById(Guid id);
        List<Receiver> GetAll();
    }
}
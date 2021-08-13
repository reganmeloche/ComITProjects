using System;
using System.Collections.Generic;

using BloodClinic.Models;

namespace BloodClinic.Storage
{
    public class ReceiverStorageList : IStoreReceivers
    {
        private List<Receiver> _receivers;

        public ReceiverStorageList() {
            _receivers = new List<Receiver>();
        }

        public void Create(Receiver receiverToCreate) {
            _receivers.Add(receiverToCreate);
        }

        public Receiver GetById(Guid receiverId) {
            var receiver = _receivers.Find(x => x.Id == receiverId);

            if (receiver == null) {
                throw new Exception($"Donor {receiverId} not found!");
            }
            return receiver;
        }

        public List<Receiver> GetAll() {
            return _receivers;
        }
    }
}
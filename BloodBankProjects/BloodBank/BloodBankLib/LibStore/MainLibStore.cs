using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodBankLib;

namespace BloodBankLib.LibStore
{
    public interface IDonationStore {
        Task<List<Donation>> GetAll();
        Task Save(Donation donation); 
        Task Remove(Donation donation);
    }

    public interface IDonorStore {
        Task<List<Donor>> GetAll();
        Task Save(Donor donor); 
    }

    public interface IReceiverStore {
        Task<List<Receiver>> GetAll();
        Task Save(Receiver receiver); 
    }

    public interface IRequestStore {
        Task<List<Request>> GetAll();
        Task Save(Request request); 
        Task Remove(Request request);
    }

    public interface ITransactionStore {
        Task<List<Transaction>> GetAll();
        Task Save(Transaction transaction); 
    }

    public interface ILibStore {
        IDonorStore DonorStore { get; }
        IReceiverStore ReceiverStore { get; }
        IDonationStore DonationStore { get; }
        IRequestStore RequestStore { get; }
        ITransactionStore TransactionStore { get; }        
    }

    public class MainLibStore : ILibStore
    {
        public IDonorStore DonorStore { get; }
        public IReceiverStore ReceiverStore { get; }
        public IDonationStore DonationStore { get; }
        public IRequestStore RequestStore { get; }
        public ITransactionStore TransactionStore { get; }  

        public MainLibStore(
            IDonorStore donorStore, 
            IReceiverStore receiverStore, 
            IRequestStore requestStore,
            IDonationStore donationStore,
            ITransactionStore transactionStore) 
        {
            DonorStore = donorStore;
            ReceiverStore = receiverStore;
            RequestStore = requestStore;
            DonationStore = donationStore;
            TransactionStore = transactionStore;
        }
    }
}

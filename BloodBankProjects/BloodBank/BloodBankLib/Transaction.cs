using System;
using System.Text;

namespace BloodBankLib
{
    public class Transaction
    {
        public Guid TransactionId {get;}
        public DateTime TransactionDate { get; }
        public Donation Donation {get;}
        public Request Request {get;}

        public Transaction(Donation donation, Request request) {
            TransactionId = Guid.NewGuid();
            Donation = donation;
            Request = request;
            TransactionDate = DateTime.Now;
        }

        public Transaction(Guid transactionId, Donation donation, Request request, DateTime transactionDate) {
            TransactionId = TransactionId;
            Donation = donation;
            Request = request;
            TransactionDate = transactionDate;
        }

        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append("\n----Transaction----");
            sb.Append($"\nDonor: {Donation.Donor.FullName} ({Donation.Donor.BloodType.ToString()})");
            sb.Append($"\nReceiver: {Request.Receiver.FullName} ({Request.Receiver.BloodType.ToString()})");
            sb.Append($"\nDate: {TransactionDate}");
            sb.Append("\n-------------------");
            return sb.ToString();
        }
    }
}

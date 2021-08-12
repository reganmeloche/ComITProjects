using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodBankLib.LibStore;

namespace BloodBankLib
{
    public class Clinic
    {   
        readonly int MAX_DAYS_OLD = 42;
        readonly IPrint _printer;
        readonly ILibStore _libStore;

        public Clinic(IPrint printer, ILibStore libStore) {
            _printer = printer;
            _libStore = libStore;
        }

        /*** REGISTRATION ***/
        public async Task<Donor> RegisterDonor(Person person, BloodType bloodType) {
            var donor = new Donor(person.FirstName, person.LastName, person.DateOfBirth, bloodType);
            await _libStore.DonorStore.Save(donor);
            return donor;
        }

        public async Task<Receiver> RegisterReceiver(Person person, BloodType bloodType) {
            var receiver = new Receiver(person.FirstName, person.LastName, person.DateOfBirth, bloodType);
            await _libStore.ReceiverStore.Save(receiver);
            return receiver;
        }


        /*** MAIN PROCESSING ***/
        public async Task ReceiveDonation(Donor donor) {
            Donation donation = null;
            try {
                donation = donor.Donate();
                await _libStore.DonorStore.Save(donation.Donor);
            } catch (Exception e) {
                _printer.Print("\nError when attempting donation");
                _printer.Print(e.Message);
                return;
            }

            donation.Verify(); // maybe get rid of the verify. Or move it around...
            bool foundMatch = false;
            await _libStore.DonationStore.Save(donation);

            var allRequests = await _libStore.RequestStore.GetAll();
            foreach (var request in allRequests) {
                if (request.Receiver.BloodType.CanReceiveFrom(donor.BloodType)) {
                    try {
                        var transaction = await PerformTransaction(donation, request);
                        foundMatch = true;
                        _printer.Print("\nDonation received and applied");
                        _printer.Print(transaction.ToString());
                        break;
                    } catch (Exception e) {
                        _printer.Print($"\nError with donation: {e.Message}");
                    }
                }
            }

            if (!foundMatch) {          
                _printer.Print("\nDonation stored:");
                _printer.Print(donation.ToString());
            }

        }

        // public void CleanStorage() {
        //     foreach (var donation in ) {
        //         if (donation.DaysOld > MAX_DAYS_OLD) {
        //             //Storage.Remove(donation);
        //             continue;
        //         }

        //         if (!donation.Verified) {
        //             donation.Verify();
        //         }
        //     }
        // }

        public async Task ReceiveRequest(Receiver receiver) {

            bool foundMatch = false;
            var request = new Request(receiver);
            await _libStore.RequestStore.Save(request);

            var allDonations = await _libStore.DonationStore.GetAll();
            foreach (var donation in allDonations) {
                if (receiver.BloodType.CanReceiveFrom(donation.Donor.BloodType)) {

                    if (donation.Verified && donation.DaysOld < MAX_DAYS_OLD) {
                        try {
                            var transaction = await PerformTransaction(donation, request);
                            foundMatch = true;
                            _printer.Print("\nRequest received and donation applied");
                            _printer.Print(transaction.ToString());
                            break;
                        } catch (Exception e) {
                            _printer.Print($"\nError with donation: {e.Message}");
                        }
                    }
                }
            }

            if (!foundMatch) {
                _printer.Print("\nRequest made:");
                _printer.Print(request.ToString());
            }
        }

        private async Task<Transaction> PerformTransaction(Donation donation, Request request) {
            var transaction = new Transaction(donation, request);
            await _libStore.TransactionStore.Save(transaction);
            await _libStore.DonationStore.Remove(donation);  
            await _libStore.RequestStore.Remove(request);  

            return transaction;
        }

        /*** PRINTING FUNCTIONS ***/
        public async Task PrintDonations() {
            _printer.Print("\nAll stored donations");
            var allDonations = await _libStore.DonationStore.GetAll();
            foreach (var donation in allDonations) {
                _printer.Print(donation.ToString());
            }
        }

        public async Task PrintRequests() {
            _printer.Print("\nAll requests");
            var allRequests = await _libStore.RequestStore.GetAll();
            foreach (var req in allRequests) {
                _printer.Print(req.ToString());
            }
        }

        public async Task PrintTransactions() {
            _printer.Print("\nAll transactions");
            var allTransactions = await _libStore.TransactionStore.GetAll();
            foreach (var transaction in allTransactions) {
                _printer.Print(transaction.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using BloodClinic.Models;
using BloodClinic.Storage;

namespace BloodClinic
{
    public class BloodBank
    {
        /*** Constructor ***/
        public BloodBank(
            IStoreDonors donorStorageArg, 
            IStoreDonations donationStorageArg, 
            IStoreReceivers receiverStorageArg
        ) {
            _donorStorage = donorStorageArg;
            _receiverStorage = receiverStorageArg;
            _donationStorage = donationStorageArg;
        
            // TODO: Add all blood types
            BloodType typeONeg = new BloodType("O",'-');
            BloodType typeAbPos = new BloodType("AB", '+');

            // Test members
            Donor firstDonor = new Donor("Pablo", "Listingart", new DateTime(1980, 2, 23), typeONeg, "pablo@comit.org");
            Console.WriteLine($"Sample Donor Id: {firstDonor.Id}");
            Donor secondDonor = new Donor("Jesselyn", "Popoff", new DateTime(1990, 1,1), typeAbPos, "jesselyn@comit.org");
            Receiver testReceiver = new Receiver("Homer", "Simpson", new DateTime(1970, 3, 22), typeONeg, "test@comit.org");
            Console.WriteLine($"Sample Receiver Id: {testReceiver.Id}");

            _donorStorage.Create(firstDonor);
            _donorStorage.Create(secondDonor);
            _receiverStorage.Create(testReceiver);
        }


        /*** Storage ***/
        private IStoreDonors _donorStorage;
        private IStoreReceivers _receiverStorage;
        private IStoreDonations _donationStorage;

        /*** Methods ***/
        public Donation MakeDonation(Guid donorId) {
            var donor = _donorStorage.GetById(donorId);

            var newDonation = new Donation() {
                Donor = donor,
                DonationDate = DateTime.Now,
                Id = Guid.NewGuid()
            };

            donor.Donate();

            _donationStorage.Create(newDonation);

            return newDonation;
        }

        public bool RequestDonation(Guid receiverId) {
            var receiver = _receiverStorage.GetById(receiverId);
            var targetBloodType = receiver.MemberBloodType;

            var donations = _donationStorage.GetAll();

            bool foundMatch = false;

            foreach (var donation in donations) {
                var nextBloodType = donation.Donor.MemberBloodType;
                if (targetBloodType.CanReceiveFrom(nextBloodType)) {
                    foundMatch = true;
                    _donationStorage.Remove(donation);
                    break;
                }
            }

            return foundMatch;
        }

        public List<Donation> GetDonations() {
            return _donationStorage.GetAll();
        }

        public List<Member> GetMembers() {
            var result = new List<Member>();
            result.AddRange(_donorStorage.GetAll());
            result.AddRange(_receiverStorage.GetAll());
            return result;
        }
    }
}
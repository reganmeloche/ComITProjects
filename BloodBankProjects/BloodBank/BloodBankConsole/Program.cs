using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodBankLib;
using BloodBankLib.LibStore;
using BloodBankDB;

namespace BloodBankConsole
{
    class Program
    {

        static async Task Main() {
            // Set up lib store
            var donorStore = new DonorStoreList(new List<Donor>());
            var receiverStore = new ReceiverStoreList(new List<Receiver>());
            var requestStore = new RequestStoreList(new List<Request>());
            var donationStore = new DonationStoreList(new List<Donation>());
            var transactionStore = new TransactionStoreList(new List<Transaction>());
            var libStore = new MainLibStore(donorStore, receiverStore, requestStore, donationStore, transactionStore);

            // Set up db store
            var db = new MainDB();
            await db.StartDBs();
            var donorStoreDB = new DonorStoreDB(db);
            var receiverStoreDB = new ReceiverStoreDB(db);
            var requestStoreDB = new RequestStoreDB(db);
            var donationStoreDB = new DonationStoreDB(db);
            var transactionStoreDB = new TransactionStoreDB(db);
            var libStoreDB = new MainLibStore(donorStoreDB, receiverStoreDB, requestStoreDB, donationStoreDB, transactionStoreDB);


            var printer = new ConsolePrinter();
            var clinic = new Clinic(printer, libStoreDB);

            // Test values
            var bloodTypeDict = BloodType.GetBloodTypeDict();

            var donors = new List<Person>() {
                new Person("John", "Smith", new DateTime(2000, 12, 18)),
                new Person("Hank", "Hill", new DateTime(1970, 11, 18)),
                new Person("Homer", "Simpson", new DateTime(1994, 4, 18)),
            };

            var receivers = new List<Person>() {
                new Person("Lois", "Griffin", new DateTime(1981, 9, 18)),
                new Person("Turanga", "Leela", new DateTime(1966, 1, 18)),
                new Person("Bender", "Rodriguez", new DateTime(1942, 2, 18)),
            };


            // Donor Registration
            var donor1 = await clinic.RegisterDonor(donors[0], bloodTypeDict["AB+"]);
            var donor2 = await clinic.RegisterDonor(donors[1], bloodTypeDict["AB-"]);
            var donor3 = await clinic.RegisterDonor(donors[2], bloodTypeDict["O-"]);

            // Receiver Registration
            var receiver1 = await clinic.RegisterReceiver(receivers[0], bloodTypeDict["B+"]);
            var receiver2 = await clinic.RegisterReceiver(receivers[1], bloodTypeDict["A-"]);
            var receiver3 = await clinic.RegisterReceiver(receivers[2], bloodTypeDict["AB+"]);

            // Receive a request - should log the request
            await clinic.ReceiveRequest(receiver1);

            // Receive a donation - no match - store it 
            await clinic.ReceiveDonation(donor1);

            // Receive a donation - match - apply it
            await clinic.ReceiveDonation(donor2);

            await clinic.ReceiveDonation(donor3);

            await clinic.ReceiveDonation(donor1);

            await clinic.ReceiveRequest(receiver2);

            await clinic.ReceiveRequest(receiver3);

            await clinic.ReceiveRequest(receiver1);

            await clinic.PrintRequests();
            await clinic.PrintDonations();
            await clinic.PrintTransactions();
            
        }
    }
}

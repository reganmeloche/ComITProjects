using System;
using Npgsql;
using BloodClinic.Models;
using BloodClinic.Storage;


namespace BloodClinic
{
    class Program
    {
        static void Main(string[] args)
        {
            // LIST
            // var donorStorageSystem = new DonorStorageList();
            // var receiverStorageSystem = new ReceiverStorageList();
            // var donationStorageSystem = new DonationStorageList();

            // DB 
            string connectionString = "Host=suleiman.db.elephantsql.com;Port=5432;Database=qshjhpqq;Username=qshjhpqq;Password=[REDACTED];";
            var sqlConnection = new NpgsqlConnection(connectionString);
            sqlConnection.Open();

            var donorStorageSystem = new DonorStorageDB(sqlConnection);
            var receiverStorageSystem = new ReceiverStorageList();
            var donationStorageSystem = new DonationStorageDB(sqlConnection, donorStorageSystem);



            // 3.3: Initialize the donationStorageSystem and inject it into the BloodBank constructor
            var theBloodBank = new BloodBank(donorStorageSystem, donationStorageSystem, receiverStorageSystem);

            Console.WriteLine("Welcome to the ComIT Blood bank!");

            while (true) {
                Console.WriteLine("\nPlease select an option:\n" +
                    "- d: make a donation\n" + 
                    "- r: request a donation\n" +
                    "- a: list all donations\n" +
                    "- m: list all members\n" +
                    "- q: quit\n"
                );
                string userInput = Console.ReadLine();

                // MAKE DONATION
                if (userInput == "d") {
                    Console.WriteLine("Please enter the Donor ID:");
                    string donorId = Console.ReadLine();
                    
                    try {
                        Guid donorIdGuid = Guid.Parse(donorId);
                        var donation = theBloodBank.MakeDonation(donorIdGuid);
                        Console.WriteLine($"Donation complete. ID: {donation.Id}");
                    }
                    catch (Exception e) {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                }

                // REQUEST DONATION
                if (userInput == "r") {
                    Console.WriteLine("Please enter the Receiver ID:");
                    string receiverId = Console.ReadLine();
                    
                    try {
                        Guid receiverIdGuid = Guid.Parse(receiverId);
                        bool success = theBloodBank.RequestDonation(receiverIdGuid);
                        
                        if (success) {
                            Console.WriteLine($"Transaction successful");
                        } else {
                            Console.WriteLine($"No available donations at this time.");
                        }
                    }
                    catch (Exception e) {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                }

                // VIEW ALL DONATIONS
                if (userInput == "a") {
                    try {
                        var donations = theBloodBank.GetDonations();
                        foreach (var donation in donations) {
                            Console.WriteLine(donation.ToString());
                        }
                    } catch (Exception e) {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                }

                // VIEW ALL MEMBERS
                if (userInput == "m") {
                    try {
                        var members = theBloodBank.GetMembers();
                        foreach (var member in members) {
                            Console.WriteLine(member.ToString());
                        }
                    } catch (Exception e) {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                }

                if (userInput == "q") {
                    break;
                }
                
            }

            Console.WriteLine("See you later!");


        }
    }
}

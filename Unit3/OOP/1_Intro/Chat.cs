using System;
using System.Collections.Generic;

namespace Unit3
{
    public class User 
    {
        public string Username {get; private set;}

        public string ImageUrl {get; private set;}

        private DateTime _joinDate {get;set;}

        public int DaysActive {
            get {
                return (DateTime.Now - _joinDate).Days;
            }
        }

        private int _messagesReceived;

        private int _messagesSent;

        public User(string username, string imageUrl) {
            Username = username;
            ImageUrl = imageUrl;
            _joinDate = DateTime.Now; // Maybe make this passed in? for fun.
            _messagesReceived = 0;
            _messagesSent = 0;
        }

        public void ReceiveAMessage(Message message) {
            _messagesReceived++;
            Console.WriteLine($"{Username} got the message ({message.Title})");
            Console.WriteLine("Read the message? (y/n)");
            string input = Console.ReadLine();

            if (input == "y") {
                message.OpenMessage();
            }
        }

        public void SendOutboundMessages(Message message, List<User> users) {
            foreach (var user in users) {
                Console.WriteLine($"{Username} sent message to {user.Username}");
                user.ReceiveAMessage(message);
                _messagesSent++;
            }
        }

        public string GetStatsString() {
            return $@"
                User: {Username}
                Total Messages sent: {_messagesSent}
                Messages Received: {_messagesReceived}
                Days Active {DaysActive}
            ";
        }

    }

    public class Message
    {
        public string Title {get; private set;}
        private string _text;
        public DateTime DateSent {get; private set;}

        public Message(string title, string text) {
            Title = title;
            _text = text;
            DateSent = DateTime.Now;
        }

        public void OpenMessage() {
            Console.WriteLine($"-------------\nMessage: {Title}\nDate: {DateSent}\nText:{_text}\n-------------\n");
        }

    }
}

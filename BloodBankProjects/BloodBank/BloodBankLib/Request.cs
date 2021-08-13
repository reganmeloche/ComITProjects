using System;
using System.Text;

namespace BloodBankLib
{
    public class Request
    {
        public Guid RequestId {get;}
        public Receiver Receiver {get;}
        public DateTime DateRequested {get;}

        public Request(Receiver receiver) {
            RequestId = Guid.NewGuid();
            Receiver = receiver;
            DateRequested = DateTime.Now;
        }

        public Request(Guid requestId, Receiver receiver, DateTime requestDate) {
            RequestId = requestId;
            Receiver = receiver;
            DateRequested = requestDate;
        }

        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append("\n----Request----");
            sb.Append($"\nRequester: {Receiver.FullName}");
            sb.Append($"\nType required: {Receiver.BloodType.ToString()}");
            sb.Append("\n--------------");
            return sb.ToString();
        }
    }
}

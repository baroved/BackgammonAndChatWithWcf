using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.common
{
    [DataContract]
    public class MessageCommon
    {
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public List<string> listOfMessages { get; set; }
        public MessageCommon()
        {
            listOfMessages = new List<string>();
        }
    }
}

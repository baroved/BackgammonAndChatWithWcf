using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.common
{
    [DataContract]
    public class UserCommon
    {
        [DataMember]
        public List<string> listOfUser { get; set; }
        public UserCommon()
        {
            listOfUser = new List<string>();
        }
    }
}

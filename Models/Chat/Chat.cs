using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Models.User;
namespace Models.Chat
{
    [DataContract]
    public class Chat
    {
        [DataMember]
        [Key]
        public int ID { get; set; }
        [DataMember]
        public string ChatContent { get; set; }
        [DataMember]
        public int User1ID { get; set; }
        [DataMember]
        public int User2ID { get; set; }

    }
}

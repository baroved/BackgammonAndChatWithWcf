using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    [DataContract]
    public class User
    {
        [DataMember]
        [Key]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string Name { get; set; }
        [DataMember]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}

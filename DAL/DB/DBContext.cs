using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Models.Chat;
using Models.User;
namespace DAL.DB
{
    
    public class DBContext:DbContext
    {
        public DBContext():base("name=Chat")
        {
            Database.SetInitializer(new Init());
        }
        
        public DbSet<User> listOfUser { get; set; }
        public DbSet<Chat> listofChats { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models.User;

namespace DAL.DB
{
    public class Init : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            List <User> list= new List<User>()
            {
                new User(){Name="bar",Password="123"},
                new User(){Name="dean",Password="123"},
                new User(){Name="b",Password="123"},
            }; 
            context.listOfUser.AddRange(list);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}

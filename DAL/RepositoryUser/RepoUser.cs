using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DB;
using Models.User;
namespace DAL.RepositoryUser
{
    public class RepoUser
    {
        public bool Register(string name, string password)
        {
            User check;
            using (var context = new DBContext())
            {
                check = context.listOfUser.Where(a => a.Name == name).FirstOrDefault();
                if (check != null)
                    return false;
                User newUser = new User()
                {
                    Name = name,
                    Password = password
                    
                };
                context.listOfUser.Add(newUser);
                context.SaveChanges();
                return true;

            }
        }
      
        public bool Login(string name, string password)
        {
            User check;
            using (var context = new DBContext())
            {
                check = context.listOfUser.Where(a => a.Name == name && a.Password == password).FirstOrDefault();
                if (check != null)
                    return true;
                return false;
            }
        }

        public int GetIdByName(string name)
        {
            using (var context = new DBContext())
            {
                return context.listOfUser.Where(a => a.Name == name).FirstOrDefault().Id;
            }
        }

    }
}

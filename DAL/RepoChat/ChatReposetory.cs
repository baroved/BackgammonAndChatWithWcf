using DAL.DB;
using Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepoChat
{
    public class ChatReposetory
    {
        public Chat GetChat(int id1,int id2)
        {
            using (var context = new DBContext())
            {
                return context.listofChats.Where(a => (a.User1ID == id1 && a.User2ID == id2) || (a.User1ID == id2 && a.User2ID == id1)).FirstOrDefault();
            }
        }

        public void Updatecontent(Chat c)
        {
            using (var context = new DBContext())
            {
                Chat check=context.listofChats.Where(a => a.ID == c.ID).FirstOrDefault();
                check.ChatContent = c.ChatContent;
                context.SaveChanges();
            }
        }

        public void AddNewchat(int id1,int id2)
        {
            using (var context = new DBContext())
            {
                context.listofChats.Add(new Chat() { User1ID = id1,User2ID = id2});
                context.SaveChanges();
            }
        }
    }
}

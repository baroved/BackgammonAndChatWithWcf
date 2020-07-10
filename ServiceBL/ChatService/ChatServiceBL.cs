using Common.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common.common;
using DAL.DB;
using DAL.RepositoryUser;
using Models.User;
using DAL.RepoChat;
using Models.Chat;

namespace ServiceBL.ChatService
{
    public static class ChatServiceBL
    {
        #region Properties
        public static Dictionary<string, OperationContext> _callBack;
        static List<string> messages;
        static UserCommon uc;
        static MessageCommon mc;
        static List<string> listOfUser;
        public static string GameSender;
        public static string GameReciever;
        public static object obj = new object();
        public static object objReg = new object();
        public static object objSend = new object();
        #endregion
        #region Constructor
        static ChatServiceBL()
        {
            _callBack = new Dictionary<string, OperationContext>();
            listOfUser = new List<string>();
            messages = new List<string>();
            uc = new UserCommon();
            mc = new MessageCommon();

        }
        #endregion
        #region Methods
        public static void Logout(string name)
        {
            listOfUser.Remove(name);
            _callBack.Remove(name);
            uc.listOfUser = listOfUser;
            foreach (var item in _callBack)
                item.Value.GetCallbackChannel<IMessageChatCallBack>().IncomingUserConnected(uc);
        }
        public static void GameRequest(string sender, string reciever)
        {
            _callBack[reciever].GetCallbackChannel<IMessageChatCallBack>().IncomingGameRequest(sender);
        }
        public static void StartGame(string sender, string reciever)
        {
            _callBack[reciever].GetCallbackChannel<IMessageChatCallBack>().IncomingGame(sender);
            _callBack[sender].GetCallbackChannel<IMessageChatCallBack>().IncomingGame(reciever);
            GameSender = sender;
            GameReciever = reciever;
        }
        public static void ChatRequest(string sender, string reciever)
        {
            _callBack[reciever].GetCallbackChannel<IMessageChatCallBack>().IncomingChatRequest(sender);
        }
        public static void StartChat(string sender, string reciever)
        {
            _callBack[sender].GetCallbackChannel<IMessageChatCallBack>().IncomingChatScreen(reciever);
            _callBack[reciever].GetCallbackChannel<IMessageChatCallBack>().IncomingChatScreen(sender);

        }

        public static void SendMessage(string Message, string sender, string reciever)
        {
            lock (objSend)
            {
                ChatReposetory cr = new ChatReposetory();
                RepoUser up = new RepoUser();
                mc.Date = DateTime.Now;
                Message = mc.Date.ToShortTimeString() + ": " + sender + ": " + Message;
                messages = new List<string>();
                int senderid = up.GetIdByName(sender);
                int recieverid = up.GetIdByName(reciever);
                Chat currentchat = cr.GetChat(senderid, recieverid);
                if (currentchat == null)
                {
                    cr.AddNewchat(senderid, recieverid);
                    currentchat = cr.GetChat(senderid, recieverid);
                }
                currentchat.ChatContent += Message + "`";
                cr.Updatecontent(currentchat);
                string temp = "";
                foreach (var item in currentchat.ChatContent)
                {
                    if (item == '`')
                    {
                        messages.Add(temp);
                        temp = "";
                    }
                    else
                        temp += item;
                }
                mc.listOfMessages = messages;
                Task t = Task.Run(() =>
                {
                    _callBack[reciever].GetCallbackChannel<IMessageChatCallBack>().IncomingMessage(mc);
                    _callBack[sender].GetCallbackChannel<IMessageChatCallBack>().IncomingMessage(mc);
                });
            }

        }
       
        public static string Login(string userName, string password)
        {
            lock (obj)
            {
                RepoUser rp = new RepoUser();
                if (userName == null || password == null)
                    return "UserName or/and password must not be empty";
                if (_callBack.ContainsKey(userName))
                    return "User is already connected!!";
                if (rp.Login(userName, password))
                {
                    _callBack.Add(userName, OperationContext.Current);
                    listOfUser.Add(userName);
                    uc.listOfUser = listOfUser;
                    foreach (var item in _callBack)
                        item.Value.GetCallbackChannel<IMessageChatCallBack>().IncomingUserConnected(uc);
                    return "";
                }
                return "No user found";
            }
        }
        
        public static string Register(string userName, string password)
        {
            lock (objReg)
            {
                RepoUser rp = new RepoUser();
                if (userName != null && password != null && rp.Register(userName, password))
                {
                    return "";
                }
                else
                {
                    if (userName == null || password == null)
                        return "UserName or/and password must not be empty";
                    else
                        return "UserName is already regist";
                }
            }

        }

        public static OperationContext GetOperationByName(string name)
        {
            return _callBack[name];
        }
        #endregion
    }

}




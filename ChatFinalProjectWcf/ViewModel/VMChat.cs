using ChatFinalProjectWcf.ClientBL;
using ChatFinalProjectWcf.Proxy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatFinalProjectWcf.ViewModel
{
    public class VMChat : BaseViewModel
    {
        public RelayCommand btnSendMessage { get; set; }
        public string Message { get; set; }
        public string Fault { get; set; }
        public string reciever { get; set; }
        public string sender { get; set; }
        public string Details { get; set; }
        public ObservableCollection<string> list { get; set; }
        public static ClientCallBack clientCallBack;
        MessageCommon messageCommon;
        public VMChat(string otherUser, string name)
        {
            clientCallBack = ClientCallBack.clientCallBack;
            reciever = otherUser;
            sender = name;
            Details = "Username:" + sender + "\n" + "Send to:" + reciever;
            Notify(nameof(Details));
            messageCommon = new MessageCommon();
            btnSendMessage = new RelayCommand(ClickSendMassage);
            ClientCallBack.GetMessages += ReciveMessage;
        }

        void ReciveMessage(string[] messages)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                list = new ObservableCollection<string>(messages);
                list.Clear();

                foreach (var m in messages)
                {
                    list.Add(m);
                }
            });

            Notify(nameof(list));
        }

        void ClickSendMassage(object p)
        {
            Notify(nameof(Message));
            if (Message != null)
            {
                clientCallBack.SendMessage(Message, sender, reciever);
                Fault = "Message has been sent";
            }
            else
            {
                Fault = "You can not send empty message";
            }
            Notify(nameof(Fault));
            Message = null;
            Notify(nameof(Message));
        }

    }
}

using ChatFinalProjectWcf.ClientBL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChatFinalProjectWcf.ViewModel
{
    public class VMMain : BaseViewModel
    {
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FaultLogin { get; set; }
        public string UserNameDetails { get; set; }
        public string FaultMessage { get; set; }
        public string Message { get; set; }
        public string FaultGame { get; set; }
        public static ClientCallBack clientCallBack;
        public RelayCommand BtnLogin { get; set; }
        public RelayCommand BtnRegister { get; set; }
        public RelayCommand BtnLogout { get; set; }
        public RelayCommand BtnSendMassage { get; set; }
        public RelayCommand BtnStartGame { get; set; }
        public RelayCommand BtnStartChat { get; set; }
        public string SelectedUser { get; set; }
        //Login
        public Visibility IsVisibleLogin { get; set; }
        //users list and chat list
        public Visibility IsVisibleLists { get; set; }
        public ObservableCollection<string> ListOfUser { get; set; }
        private string sender;
        public string Sender
        {
            get
            {
                return sender;
            }
            set
            {
                sender = value;
            }
        }
        public VMMain()
        {
            IsVisibleLists = Visibility.Collapsed;
            UserNameDetails = "Username:";
            Notify(nameof(UserNameDetails));
            Notify(nameof(IsVisibleLists));
            clientCallBack = ClientCallBack.clientCallBack;
            Login();
            Register();
            Logout();

            StartGame();
            StartChat();
        }
        private void StartGame()
        {


            BtnStartGame = new RelayCommand((p) =>
            {
                Notify(nameof(SelectedUser));
                if (SelectedUser != null && SelectedUser != Sender)
                    clientCallBack.SendGameRequest(Sender, SelectedUser);
                else
                {
                    if (SelectedUser == null)
                        FaultGame = "You have to choose user to play with";
                    else
                        FaultGame = "You can not play with yourself";
                }
                Notify(nameof(FaultGame));
            });
        }
        private void StartChat()
        {
            BtnStartChat = new RelayCommand((p) =>
            {
                Notify(nameof(SelectedUser));
                if (SelectedUser != null && SelectedUser != Sender)
                    clientCallBack.SendChatRequest(Sender, SelectedUser);
                else
                {
                    if (SelectedUser == null)
                        FaultGame = "You have to choose user to chat with";
                    else
                        FaultGame = "You can not chat with yourself";
                }
                Notify(nameof(FaultGame));
            });
        }
        private void Logout()
        {
            BtnLogout = new RelayCommand((p) =>
            {
                clientCallBack.Logout(Sender);
                UserNameDetails = "Username:" + "\n" + "Send to:";
                Notify(nameof(UserNameDetails));
                IsVisibleLogin = Visibility.Visible;
                IsVisibleLists = Visibility.Collapsed;
                Notify(nameof(IsVisibleLists));
                Notify(nameof(IsVisibleLogin));
            });
        }
        private void Login()
        {
            BtnLogin = new RelayCommand((p) =>
                 {
                     Notify(nameof(Password));
                     Notify(nameof(UserName));
                     FaultLogin = clientCallBack.Login(UserName, Password);
                     Notify(nameof(FaultLogin));
                     if (FaultLogin == "")
                     {
                         IsVisibleLogin = Visibility.Collapsed;
                         Sender = UserName;
                         UserNameDetails = "Username:" + Sender;
                         IsVisibleLists = Visibility.Visible;
                         Notify(nameof(IsVisibleLists));
                         Notify(nameof(UserNameDetails));
                         Notify(nameof(IsVisibleLogin));
                         ListOfUser = clientCallBack.UserList;
                         Notify(nameof(ListOfUser));
                         ClientCallBack.OnUserConnected += (users) =>
                         {
                             Application.Current.Dispatcher.Invoke(() =>
                             {
                                 ListOfUser.Clear();
                                 foreach (var user in users)
                                 {
                                     ListOfUser.Add(user);
                                 }
                             });
                         };

                     }

                     Password = null;
                     UserName = null;
                     Notify(nameof(Password));
                     Notify(nameof(UserName));

                 });

        }
        private void Register()
        {

            BtnRegister = new RelayCommand((p) =>
            {
                Notify(nameof(Password));
                Notify(nameof(UserName));
                FaultLogin = clientCallBack.Register(UserName, Password);
                Notify(nameof(FaultLogin));
                if (FaultLogin == "")
                {
                    FaultLogin = "You have registered";
                    Notify(nameof(FaultLogin));
                }

                Password = null;
                UserName = null;
                Notify(nameof(Password));
                Notify(nameof(UserName));

            });
        }
    }
}

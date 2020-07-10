using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ChatFinalProjectWcf.Proxy;

namespace ChatFinalProjectWcf.ClientBL
{
    public class ClientCallBack : Proxy.IChatContractCallback
    {
        #region Properties
        public ObservableCollection<string> MessagesList { get; set; }
        public ObservableCollection<string> UserList { get; set; }
        public ObservableCollection<string> DiceNums { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<Cell> Cells { get; set; }
        public string Name { get; set; }
        Proxy.ChatContractClient proxy;
        private static ClientCallBack instance;
        public static string TurnOf { get; set; }
        public static event Action<string> turnOf;
        public static event Action<string[]> OnUserConnected;
        public static event Action<string[]> GetMessages;
        public static event Action<string[]> GetDiceNums;
        public static event Action<Cell[]> GetCells;
        #endregion
        #region Singleton
        public static ClientCallBack clientCallBack
        {
            get
            {
                if (instance == null)
                    instance = new ClientCallBack();
                return instance;
            }
        }
        #endregion

        #region Constructor
        public ClientCallBack()
        {
            proxy = new ChatContractClient(new System.ServiceModel.InstanceContext(this));
        }
        #endregion
        #region GameMathod
        public int GetAvailableMoves()
        {
            Task<int> t = Task.Run(() =>
            {
                return proxy.GetAvailableMoves();
            });
            t.ConfigureAwait(false);
            t.Wait();
            return t.Result;
        }
        public string GetColorUser()
        {
            Task<string> t = Task.Run(() =>
            {
                return proxy.UserColor();
            });
            t.ConfigureAwait(false);
            t.Wait();
            return t.Result;
        }

        public bool Roll()
        {

            Task<bool> t = Task.Run(() =>
            {
                return proxy.Roll();
            });
            t.ConfigureAwait(false);
            t.Wait();
            return t.Result;

        }

        public bool MoveSoldier(int current, int target)
        {
            Task<bool> t = Task.Run(() =>
           {
               return proxy.Move(current, target);
           });
            t.ConfigureAwait(false);
            t.Wait();
            return t.Result;
        }
        public bool CheckIfFinishTurn()
        {
            Task<bool> t = Task.Run(() =>
            {
                return proxy.CheckIfFinishTurn();
            });
            t.ConfigureAwait(false);
            t.Wait();
            return t.Result;
        }
        public void EndTurn()
        {
            Task t = Task.Run(() =>
            {
                proxy.EndTurn();
            });
            t.ConfigureAwait(false);
            t.Wait();
        }

        public Cell[] GetBoard(string sender, string reciever)
        {
            Task<Cell[]> t = Task.Run(() =>
              {
                  return proxy.NewGame(sender, reciever);
              });

            t.Wait();
            return t.Result;
        }


        #endregion
        #region Login/Register/Logout
        public string Login(string name, string pass)
        {
            Task<string> t = Task.Run(() =>
            {
                Name = name;
                return proxy.Login(name, pass);
            });
            t.Wait();
            return t.Result;
        }

        public string Register(string name, string pass)
        {
            Task<string> t = Task.Run(() =>
            {
                return proxy.Register(name, pass);
            });
            t.Wait();
            return t.Result;
        }

        public void Logout(string name)
        {
            Task t = Task.Run(() =>
            {
                proxy.Logout(name);
            });
            t.Wait();
        }
        #endregion
        #region ChatMathod
        public void SendMessage(string message, string sender, string reciever)
        {
            Task t = Task.Run(() =>
            {
                proxy.SendMessage(message, sender, reciever);
            });
            t.Wait();

        }
        #endregion
        #region CallBackMathod
        public void SendGameRequest(string sender, string reciever)
        {
            Task t = Task.Run(() =>
            {
                proxy.GameRequest(sender, reciever);
            });
            t.Wait();
        }
        public void SendChatRequest(string sender, string reciever)
        {
            Task t = Task.Run(() =>
            {
                proxy.ChatRequest(sender, reciever);
            });
            t.Wait();
        }
        public void IncomingMessage(MessageCommon mc)
        {
            MessagesList = new ObservableCollection<string>(mc.listOfMessages);
            GetMessages?.Invoke(mc.listOfMessages);
        }

        public void IncomingUserConnected(UserCommon uc)
        {
            UserList = new ObservableCollection<string>(uc.listOfUser);
            OnUserConnected?.Invoke(uc.listOfUser);
        }

        public void IncomingGame(string otherUser)
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                GameWindow game = new GameWindow(otherUser, Name);
                game.Show();
            });
        }

        public void IncomingChatScreen(string otherUser)
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                ChatWindow chat = new ChatWindow(otherUser, Name);
                chat.Show();
            });
        }

        public void IncomingChatRequest(string sender)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (MessageBox.Show(("Start chat with " + sender + "?"), "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    proxy.StartChat(Name, sender);
                }
            });
        }
        public void IncomingGameRequest(string sender)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (MessageBox.Show(("Start game with " + sender + "?"), "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    proxy.StartGame(Name, sender);
                }
            });
        }


        public void IncomingDiceNums(GameCommon gc)
        {
            DiceNums.Clear();
            foreach (var item in gc.DiceNumsImg)
            {
                DiceNums.Add(item);
            }

            GetDiceNums?.Invoke(gc.DiceNumsImg);
        }

        public void GetBoardGame(GameCommon gc)
        {
            Cells = new ObservableCollection<Cell>(gc.Cells);
            GetCells?.Invoke(gc.Cells);
        }
        public void IncomingWinner(string sender)
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                proxy.FinishGame();
                if (MessageBox.Show(("The winner is " + sender + "!!!"), "Question", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                {
                    foreach (Window item in Application.Current.Windows)
                    {
                        if (item is GameWindow)
                            item.Close();
                    }

                }

            });
        }

        public void IncomingTurn(GameCommon gc)
        {

            TurnOf = gc.TurnOf;
            turnOf?.Invoke(gc.TurnOf);

        }
        public void IncomingMessageForPlayer(GameCommon gc)
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                MessageBox.Show(gc.MessageForPlayer);
            });
        }
        #endregion

    }
}

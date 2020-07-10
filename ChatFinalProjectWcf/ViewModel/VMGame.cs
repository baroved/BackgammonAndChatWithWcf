using ChatFinalProjectWcf.ClientBL;
using ChatFinalProjectWcf.Proxy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChatFinalProjectWcf.ViewModel
{
    public class VMGame : BaseViewModel
    {
        public string YourColor { get; set; }
        public string reciever { get; set; }
        public string sender { get; set; }
        private ObservableCollection<Cell> arOfCell = new ObservableCollection<Cell>();
        public RelayCommand btnRoll { get; set; }
        public RelayCommand btnStartChat { get; set; }
        public RelayCommand btnEndTurn { get; set; }
        public RelayCommand SelectedCell { get; set; }
        public Visibility IsVisible { get; set; }
        public Visibility IsVisibleRoll { get; set; }
        public Visibility IsVisibleEnd { get; set; }
        public ClientCallBack client;
        public ObservableCollection<string> arrayOfImgSrc
        {
            get;
            set;
        }
        public ObservableCollection<int> dicenumbers { get; set; }
        public int current { get; set; }
        public string Turn { get; set; }
        public ObservableCollection<Cell> arrayOfCell
        {
            get
            {
                return arOfCell;
            }
            set
            {
                arOfCell = value;
                Notify(nameof(arrayOfCell));
            }
        }


        public VMGame(string otherUser, string name)
        {
            client = ClientCallBack.clientCallBack;
            current = -1;
            IsVisibleEnd = Visibility.Collapsed;
            Notify(nameof(IsVisibleEnd));
            dicenumbers = new ObservableCollection<int>();
            sender = name;
            reciever = otherUser;
            Notify(nameof(sender));
            var a = client.GetBoard(otherUser, name);
            arrayOfCell = new ObservableCollection<Cell>(a);
            arrayOfImgSrc = new ObservableCollection<string>();
            Notify(nameof(arrayOfCell));
            StartChat();
            EndTurn();
            Roll();
            Move();
            YourColor = client.GetColorUser();
            Notify(nameof(YourColor));
            Turn = ClientCallBack.TurnOf;
            Notify(nameof(Turn));
            ClientCallBack.GetCells += (cells) =>
{
    Application.Current.Dispatcher.InvokeAsync(() =>
    {
        arrayOfCell.Clear();
        foreach (var item in cells)
        {
            arrayOfCell.Add(item);
        }

    });
};
            ClientCallBack.GetDiceNums += (nums) =>
{
    Application.Current.Dispatcher.InvokeAsync(() =>
    {
        arrayOfImgSrc.Clear();
        foreach (var item in nums)
        {
            arrayOfImgSrc.Add(item);
        }
        IsVisible = Visibility.Visible;
        Notify(nameof(IsVisible));
        Notify(nameof(arrayOfImgSrc));

    });
};
            ClientCallBack.turnOf += (turn) =>
            {
                Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    Turn = turn;
                    Notify(nameof(Turn));

                });
            };
        }
        public void EndTurn()
        {
            btnEndTurn = new RelayCommand((p) =>
            {
              
                    client.EndTurn();
                    IsVisibleEnd = Visibility.Collapsed;
                    IsVisible = Visibility.Collapsed;
                    Notify(nameof(IsVisibleEnd));
                    Notify(nameof(IsVisible));
                    Turn = ClientCallBack.TurnOf;
                    Notify(nameof(Turn));
                }
            
            );
        }
        public void StartChat()
        {
            btnStartChat = new RelayCommand((p) =>
              {
                  client.SendChatRequest(sender, reciever);
              });
        }
        
        public void Roll()
        {

            btnRoll = new RelayCommand((p) =>
              {
                 

                      if (client.Roll())
                      {
                          IsVisible = Visibility.Visible;
                          if (!client.CheckIfFinishTurn())
                              IsVisibleEnd = Visibility.Visible;
                          Notify(nameof(IsVisibleEnd));
                          Notify(nameof(IsVisible));
                      }
                  
              }

            );
        }
        public void Move()
        {
            SelectedCell = new RelayCommand((p) =>
              {
                  if (current == -1)
                  {
                      current = int.Parse(p.ToString());
                  }
                  else
                  {
                      int target = int.Parse(p.ToString());
                      bool Ok = client.MoveSoldier(current, target);

                      arrayOfCell = new ObservableCollection<Cell>(client.Cells);
                      Notify(nameof(arrayOfCell));
                      current = -1;
                      if (client.GetAvailableMoves() != 0)
                      {
                          IsVisible = Visibility.Visible;
                          Notify(nameof(IsVisible));
                      }
                      //else
                      //{
                      //    IsVisible = Visibility.Collapsed;
                      //    Notify(nameof(IsVisible));
                      //}
                      if (client.GetAvailableMoves() == 0 && !Ok)
                      {
                          IsVisibleEnd = Visibility.Visible;
                          Notify(nameof(IsVisibleEnd));
                      }
                  }
              });

        }
    }
}

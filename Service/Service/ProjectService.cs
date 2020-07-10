using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common.Contract;
using DAL;
using Models.Cell;
using ServiceBL.ChatService;
using ServiceBL.GameService;

namespace Service.Service
{
    [CallbackBehavior(UseSynchronizationContext = false, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ProjectService : IChatContract
    {
        #region ChatMethods
        public string Register(string userName, string password)
        {
            return ChatServiceBL.Register(userName, password);
        }
        public string Login(string userName, string password)
        {
            return ChatServiceBL.Login(userName, password);
        }
        public void Logout(string UserName)
        {
            ChatServiceBL.Logout(UserName);
        }
        public void SendMessage(string Message, string sender, string reciever)
        {
            ChatServiceBL.SendMessage(Message, sender, reciever);
        }
        public void StartGame(string sender,string reciever)
        {
            ChatServiceBL.StartGame(sender, reciever);
        }
        public void GameRequest(string sender, string reciever)
        {
            ChatServiceBL.GameRequest(sender, reciever);
        }
        public void ChatRequest(string sender, string reciever)
        {
            ChatServiceBL.ChatRequest(sender, reciever);
        }

        public void StartChat(string sender, string reciever)
        {
            ChatServiceBL.StartChat(sender, reciever);
        }
        #endregion

        #region GameMethods

        public void CheckFinish()
        {
            GameserviceBL.CheckFinish();
        }

        public bool CheckIfEaten()
        {
            return GameserviceBL.CheckifEaten();
        }
        
        public bool CheckWinner()
        {
            return GameserviceBL.CheckWinner();
        }

        public void Eat()
        {
            GameserviceBL.Eat();
        }

        public void EndTurn()
        {
            GameserviceBL.EndTurn();
        }

        public Cell[] GetGameBoard()
        {
            return GameserviceBL.GetGameBoard();
        }

        public bool Move(int current, int target)
        {
           return GameserviceBL.Move(current, target);
        }

        public Cell[] NewGame(string sender, string reciever)
        {
           return GameserviceBL.NewGame(sender,reciever);
        }

        public bool OutOfEat(int current,int dicenum)
        {
            return GameserviceBL.OutOfEat(current,dicenum);
        }

        public bool Roll()
        {
            return GameserviceBL.Roll();
        }

        public void UpdateGameBoard(int current, int target, Color color)
        {
            GameserviceBL.UpdateGameBoard(current, target, color);
        }
        public int GetAvailableMoves()
        {
            return GameserviceBL.GetAvailableMoves();
        }
        public bool CheckIfFinishTurn()
        {
            return GameserviceBL.CheckIfFinishTurn();
        }
        public string UserColor()
        {
            return GameserviceBL.GetUserColor();
        }
        public void FinishGame()
        {
            GameserviceBL.FinishGame();
        }
        
        #endregion
    }
}

using Models.Cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contract
{
    [ServiceContract(CallbackContract = typeof(IMessageChatCallBack))]
    public interface IChatContract
    {
        [OperationContract]
        string Register(string userName, string Password);
        [OperationContract]
        string Login(string UserName, string password);
        [OperationContract]
        void Logout(string UserName);
        [OperationContract(IsOneWay = true)]
        void SendMessage(string m, string sender, string reciever);
        [OperationContract(IsOneWay = true)]
        void GameRequest(string sender, string reciever);
        [OperationContract(IsOneWay = true)]
        void StartGame(string sender, string reciever);
        [OperationContract(IsOneWay = true)]
        void ChatRequest(string sender, string reciever);
        [OperationContract(IsOneWay = true)]
        void StartChat(string sender, string reciever);
        #region GameContract
        [OperationContract]
        Cell[] GetGameBoard();
        [OperationContract]
        Cell[] NewGame(string sender, string reciever);
        [OperationContract]
        bool Roll();
        [OperationContract]
        void CheckFinish();
        [OperationContract]
        void Eat();
        [OperationContract]
        bool OutOfEat(int current,int dicenum);
        [OperationContract]
        bool CheckIfEaten();
        [OperationContract]
        bool CheckWinner();
        [OperationContract]
        void UpdateGameBoard(int current, int target, Color color);
        [OperationContract]
        bool Move(int current, int dicenum);
        [OperationContract]
        void EndTurn();
        [OperationContract]
        int GetAvailableMoves();
        [OperationContract]
        bool CheckIfFinishTurn();
        [OperationContract]
        string UserColor();
        [OperationContract]
        void FinishGame();
        #endregion

    }
}

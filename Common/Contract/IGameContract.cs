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
    public interface IGameContract
    {
        [OperationContract]
        Cell[] GetGameBoard();
        [OperationContract]
        void NewGame(string sender, string reciever);
        [OperationContract]
        List<int> Roll();
        [OperationContract]
        void CheckFinish();
        [OperationContract]
        void Eat();
        [OperationContract]
        bool OutOfEat(int dicenum);
        [OperationContract]
        bool CheckIfEaten();
        [OperationContract]
        bool CheckWinner();
        [OperationContract]
        void UpdateGameBoard(int current, int target, Color color);
        [OperationContract]
        void Move(int current, int dicenum);
        [OperationContract]
        void EndTurn();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Common.common;
namespace Common.Contract
{
    public interface IMessageChatCallBack
    {
        [OperationContract(IsOneWay = true)]
        void IncomingMessage(MessageCommon mc);
        [OperationContract(IsOneWay = true)]
        void IncomingUserConnected(UserCommon uc);
        [OperationContract(IsOneWay = true)]
        void IncomingGame(string user);
        [OperationContract(IsOneWay = true)]
        void IncomingChatScreen(string user);
        [OperationContract(IsOneWay = true)]
        void IncomingChatRequest(string sender);
        [OperationContract(IsOneWay = true)]
        void IncomingGameRequest(string sender);
        [OperationContract(IsOneWay = true)]
        void IncomingDiceNums(GameCommon gc);
        [OperationContract(IsOneWay = true)]
        void GetBoardGame(GameCommon gc);
        [OperationContract(IsOneWay = true)]
        void IncomingWinner(string sender);
        [OperationContract(IsOneWay =true)]
        void IncomingTurn(GameCommon gc);
        [OperationContract(IsOneWay = true)]
        void IncomingMessageForPlayer(GameCommon gc);
    }
}

using Common.Contract;
using Models.Cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceBL.GameService
{
    public static class GameserviceBL
    {
        public static Dictionary<string, GameBL> ListOfGames;
       
        static GameserviceBL()
        {
            ListOfGames = new Dictionary<string, GameBL>();
            
        }
        public static object obj = new object();
        public static Cell[] NewGame(string user, string otherUser)
        {
            lock (obj)
            {
                if (!ListOfGames.ContainsKey(user) && !ListOfGames.ContainsKey(otherUser))
                {
                    GameBL newgame = new GameBL();
                    newgame.NewGame(user, otherUser);
                    ListOfGames.Add(user, newgame);
                    ListOfGames.Add(otherUser, newgame);

                }
                return ListOfGames[GetName()].GetGameBoard();
            }
        }
        public static string GetUserColor()
        {
            return ListOfGames[GetName()].GetUserColor();
        }
        public static Cell[] GetGameBoard()
        {
            return ListOfGames[GetName()].GetGameBoard();
        }
        public static void Eat()
        {
            ListOfGames[GetName()].Eat();
        }
        public static bool Roll()
        {
           return ListOfGames[GetName()].Roll();
        }
        public static void CheckFinish()
        {
            ListOfGames[GetName()].CheckFinish();
        }

        public static bool OutOfEat(int current,int dicenum)
        {
            return ListOfGames[GetName()].OutOfEat(current,dicenum);
        }
        public static bool CheckifEaten()
        {
            return ListOfGames[GetName()].CheckIfEaten();
        }
        public static bool CheckWinner()
        {
            return ListOfGames[GetName()].CheckWinner();
        }
        public static bool Move(int current, int targer)
        {
            if (ListOfGames[GetName()].Turn)
            {
                
                   return ListOfGames[GetName()].Move(current, targer-current);
                
            }
            else
                return ListOfGames[GetName()].Move(current,(current - targer));

        }
       
        public static int GetAvailableMoves()
        {
           return ListOfGames[GetName()].GetAvailableMoves();
        }
        public static void EndTurn()
        {
            ListOfGames[GetName()].EndTurn();
        }
        public static void UpdateGameBoard(int current, int dicenum, Color color)
        {
            ListOfGames[GetName()].UpdateGameBoard(current, dicenum, color);
        }
        public static bool CheckIfFinishTurn()
        {
           return ListOfGames[GetName()].CheckIfFinishTurn();
        }

        public static void FinishGame()
        {
            ListOfGames.Remove(GetName());
        }
        public static string GetName()
        {
            return ChatService.ChatServiceBL._callBack.FirstOrDefault(x => x.Value.SessionId == OperationContext.Current.SessionId).Key;
        }
    }
}

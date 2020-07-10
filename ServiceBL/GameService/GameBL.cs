using Common.common;
using Common.Contract;
using Models.Cell;
using ServiceBL.ChatService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
namespace ServiceBL.GameService
{
    public class GameBL
    {
        #region Properties
        public Dictionary<string, OperationContext> Players;
        public Cell[] GameBoard { get; set; }
        public List<int> AvailableMoves { get; set; }
        public Random rnd = new Random();
        //if turn is true its red's turn, if turn is false then its black's turn
        public bool Turn;
        bool IsTurn = false;
        public bool RedFinish { get; set; }
        public bool BlackFinish { get; set; }
        public int CountOfOutRed;
        public int CountOfOutBlack;
        public GameCommon gc;
        public string[] arrayOfImage { get; set; }
        #endregion

        #region Constructor
        public GameBL()
        {
            Turn = true;
            Players = new Dictionary<string, OperationContext>();
            AvailableMoves = new List<int>();
            gc = new GameCommon();
            NewGame(ChatServiceBL.GameSender, ChatServiceBL.GameReciever);
            arrayOfImage = new string[6];
            arrayOfImage[0] = "/Images/one.png";
            arrayOfImage[1] = "/Images/two.png";
            arrayOfImage[2] = "/Images/three.png";
            arrayOfImage[3] = "/Images/four.png";
            arrayOfImage[4] = "/Images/five.png";
            arrayOfImage[5] = "/Images/six.png";



        }
        #endregion

        #region GameMethods
        public string GetUserColor()
        {
            return "Your Color is:" + "  " + Players.FirstOrDefault(x => x.Value.SessionId == OperationContext.Current.SessionId).Key;
        }
        public int GetAvailableMoves()
        {
            return AvailableMoves.Count();
        }

        public Cell[] GetGameBoard()
        {
            if (GameBoard == null)
                NewGame(ChatServiceBL.GameSender, ChatServiceBL.GameReciever);
            return GameBoard;
        }

        public void NewGame(string user, string otherUser)
        {

            GameBoard = new Cell[]
            {
                new Cell{ color = Color.Red},
                new Cell {color = Color.Red,SoldierAmount = 2},
                new Cell{color = Color.empty},
                new Cell{color = Color.empty},
                new Cell{color = Color.empty},
                new Cell{color = Color.empty},
                new Cell{color = Color.Black,SoldierAmount = 5 },
                new Cell{color = Color.empty },
                new Cell{color = Color.Black, SoldierAmount = 3},
                new Cell{color = Color.empty },
                new Cell{color = Color.empty },
                new Cell{color = Color.empty },
                new Cell{color = Color.Red,SoldierAmount = 5 },
                new Cell{color = Color.Black,SoldierAmount = 5 },
                new Cell{color = Color.empty },
                new Cell{color = Color.empty },
                new Cell{color = Color.empty },
                new Cell{color = Color.Red,SoldierAmount = 3 },
                new Cell{color = Color.empty },
                new Cell{color = Color.Red,SoldierAmount = 5},
                new Cell{color = Color.empty},
                new Cell{color = Color.empty},
                new Cell{color = Color.empty},
                new Cell{color = Color.empty},
                new Cell{color = Color.Black,SoldierAmount = 2 },
                new Cell{color = Color.Black}
            };
            CountOfOutRed = 0;
            CountOfOutBlack = 0;
            RedFinish = false;
            BlackFinish = false;

            Players["Red"] = ChatServiceBL.GetOperationByName(user);
            Players["Black"] = ChatServiceBL.GetOperationByName(otherUser);
            Players["Red"].GetCallbackChannel<IMessageChatCallBack>().IncomingTurn(gc);
            Players["Black"].GetCallbackChannel<IMessageChatCallBack>().IncomingTurn(gc);

        }

        public bool Roll()
        {

            if (CheckTurn())
            {
                if (!AvailableMoves.Any())
                {
                    int roll1 = rnd.Next(1, 7);
                    int roll2 = rnd.Next(1, 7);
                    if (roll1 == roll2)
                    {
                        AvailableMoves = new List<int>()
                          {
                          roll1,
                          roll1,
                          roll1,
                          roll1
                          };
                    }
                    else
                    {
                        AvailableMoves = new List<int>()
                          {
                        roll1,
                        roll2
                          };
                    }

                }

                if (AvailableMoves.Count() == 2)
                {
                    gc.DiceNumsImg = new string[2];
                    gc.DiceNumsImg[0] = arrayOfImage[AvailableMoves[0] - 1];
                    gc.DiceNumsImg[1] = arrayOfImage[AvailableMoves[1] - 1];
                }
                else
                {
                    if (AvailableMoves.Count() == 4)
                    {
                        gc.DiceNumsImg = new string[4];
                        gc.DiceNumsImg[0] = arrayOfImage[AvailableMoves[0] - 1];
                        gc.DiceNumsImg[1] = arrayOfImage[AvailableMoves[1] - 1];
                        gc.DiceNumsImg[2] = arrayOfImage[AvailableMoves[2] - 1];
                        gc.DiceNumsImg[3] = arrayOfImage[AvailableMoves[3] - 1];
                    }
                }
                gc.DiceNums = AvailableMoves;


                Players["Red"].GetCallbackChannel<IMessageChatCallBack>().IncomingDiceNums(gc);
                Players["Black"].GetCallbackChannel<IMessageChatCallBack>().IncomingDiceNums(gc);
                return true;
            }
            else
            {
                gc.MessageForPlayer = "It's not your turn";
                Players[Players.FirstOrDefault(x => x.Value.SessionId == OperationContext.Current.SessionId).Key].GetCallbackChannel<IMessageChatCallBack>().IncomingMessageForPlayer(gc);
                return false;

            }


        }

        private bool CheckTurn()
        {
            if (Turn)
                return OperationContext.Current.SessionId == Players["Red"].SessionId;
            return OperationContext.Current.SessionId == Players["Black"].SessionId;
        }

        private bool CheckMove(int current, int dicenum)
        {
            if ((GameBoard[current].color == Color.Red && Turn == false) ||
                (GameBoard[current].color == Color.Black && Turn == true))
                return false;
            else
            {
                if (Turn)
                {
                    if ((GameBoard[current + dicenum].color == Color.Red && (current + dicenum) <= 24 ||
                        GameBoard[current + dicenum].color == Color.empty ||
                    (GameBoard[current + dicenum].color == Color.Black && GameBoard[current + dicenum].SoldierAmount <= 1) ||
                     (current + dicenum) >= 24 && RedFinish) && GameBoard[current].SoldierAmount >= 1 &&
                     AvailableMoves.Contains(dicenum))
                        return true;
                    return false;
                }
                else
                {
                    if ((GameBoard[current - dicenum].color == Color.Black && (current - dicenum) > 0 ||
                       GameBoard[current - dicenum].color == Color.empty ||
                   (GameBoard[current - dicenum].color == Color.Red && GameBoard[current - dicenum].SoldierAmount <= 1) ||
                    (current - dicenum) < 0 && BlackFinish) && GameBoard[current].SoldierAmount >= 1
                    && AvailableMoves.Contains(dicenum))
                        return true;
                    return false;
                }
            }

        }

        public void CheckFinish()
        {
            bool RedState = true;
            bool BlackState = true;
            for (int i = 1; i < 19; i++)
            {
                if (GameBoard[i].color == Color.Red)
                    RedState = false;
            }
            if (RedState)
            {
                if (GameBoard[0].SoldierAmount != 0)
                    RedState = false;
            }
            RedFinish = RedState;

            for (int i = 24; i > 6; i--)
            {
                if (GameBoard[i].color == Color.Black)
                    BlackState = false;
            }
            if (BlackState)
            {
                if (GameBoard[25].SoldierAmount != 0)
                    BlackState = false;
            }
            BlackFinish = BlackState;
        }

        public void Eat()
        {
            if (Turn)
            {
                GameBoard[25].SoldierAmount++;
                GameBoard[25].color = Color.Black;

            }
            else
            {
                GameBoard[0].SoldierAmount++;
                GameBoard[0].color = Color.Red;
            }
        }

        public bool OutOfEat(int current, int dicenum)
        {

            if (Turn)
            {
                if (current == 0)
                {
                    if ((GameBoard[current + dicenum].color == Color.Red && (current + dicenum) > 0 ||
                         GameBoard[current + dicenum].color == Color.empty ||
                     (GameBoard[current + dicenum].color == Color.Black && GameBoard[current + dicenum].SoldierAmount <= 1) ||
                      (current + dicenum) <= 6 && RedFinish) &&
                      AvailableMoves.Contains(dicenum))
                    {
                        if (GameBoard[current + dicenum].color == Color.Black && GameBoard[current + dicenum].SoldierAmount == 1)
                        {
                            Eat();
                            GameBoard[current + dicenum].color = Color.Red;
                            GameBoard[0].SoldierAmount--;
                        }
                        else
                            UpdateGameBoard(current, dicenum, Color.Red);
                        return true;
                    }
                    return false;
                }

                return false;
            }
            else
            {
                if (current == 25)
                {

                    if ((GameBoard[current - dicenum].color == Color.Black && (current - dicenum) >= 0 ||
                    GameBoard[current - dicenum].color == Color.empty ||
                    (GameBoard[current - dicenum].color == Color.Red && GameBoard[current - dicenum].SoldierAmount <= 1) ||
                    (current - dicenum) < 0 && BlackFinish) && GameBoard[current].SoldierAmount >= 1
                    && AvailableMoves.Contains(dicenum))
                    {

                        if (GameBoard[current - dicenum].color == Color.Red && GameBoard[current - dicenum].SoldierAmount == 1)
                        {
                            Eat();
                            GameBoard[current - dicenum].color = Color.Black;
                            GameBoard[25].SoldierAmount--;
                        }
                        else
                            UpdateGameBoard(current, current - dicenum, Color.Black);
                        return true;
                    }
                    return false;
                }
                return false;
            }
        }

        public bool CheckIfEaten()
        {
            if (Turn)
                return GameBoard[0].SoldierAmount >= 1;
            else
                return GameBoard[25].SoldierAmount >= 1;
        }

        public bool CheckWinner()
        {
            if (Turn)
            {
                for (int i = 19; i < 25; i++)
                {
                    if (GameBoard[i].SoldierAmount > 0)
                        return false;
                }
                return true;
            }
            for (int i = 1; i < 7; i++)
            {
                if (GameBoard[i].SoldierAmount > 0)
                    return false;
            }
            return true;

        }

        public void UpdateGameBoard(int current, int target, Color color)
        {

            if (GameBoard[target].color == Color.empty)
                GameBoard[target].color = color;
            GameBoard[target].color = color;
            GameBoard[target].SoldierAmount++;
            GameBoard[current].SoldierAmount--;

            if (GameBoard[current].SoldierAmount == 0)
                GameBoard[current].color = Color.empty;

        }

        public bool Move(int current, int dicenum)
        {

            gc.Cells = GameBoard;
            Players["Red"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);
            Players["Black"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);
            if (CheckTurn())
            {
                if (Turn)
                {

                    if (CheckIfEaten())
                    {
                        if (CheckOutOfEat())
                        {
                            if (OutOfEat(current, dicenum))
                            {
                                AvailableMoves.Remove(dicenum);
                                gc.Cells = GameBoard;
                                Players["Red"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);
                                Players["Black"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);
                                return CheckIfFinishTurn();
                            }
                            return CheckIfFinishTurn();
                        }
                        else
                        {
                            EndTurn();
                            return CheckIfFinishTurn();
                        }
                    }
                    if (RedFinish&& current + dicenum > 24)
                    {
                        
                            TryToFinish(current, dicenum);

                            if (CountOfOutRed == 15)
                            {
                                Players["Red"].GetCallbackChannel<IMessageChatCallBack>().IncomingWinner(Players.FirstOrDefault(x => x.Value.SessionId == OperationContext.Current.SessionId).Key);
                                Players["Black"].GetCallbackChannel<IMessageChatCallBack>().IncomingWinner(Players.FirstOrDefault(x => x.Value.SessionId == OperationContext.Current.SessionId).Key);
                            }
                            gc.Cells = GameBoard;
                            Players["Red"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);
                            Players["Black"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);
                            return CheckIfFinishTurn();
                        

                    }

                    if (CheckMove(current, dicenum) && dicenum > 0)
                    {
                        if (GameBoard[current + dicenum].SoldierAmount == 1 && GameBoard[current + dicenum].color == Color.Black)
                        {
                            Eat();
                            GameBoard[current + dicenum].SoldierAmount--;
                            GameBoard[current + dicenum].color = Color.empty;
                            UpdateGameBoard(current, current + dicenum, Color.Red);
                            AvailableMoves.Remove(dicenum);
                            CheckFinish();
                            gc.Cells = GameBoard;
                            Players["Red"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);
                            Players["Black"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);
                            return CheckIfFinishTurn();
                        }
                        else
                        {
                            UpdateGameBoard(current, current + dicenum, Color.Red);
                            AvailableMoves.Remove(dicenum);
                            CheckFinish();
                            if (RedFinish)
                            {
                                gc.MessageForPlayer = "Your target For win is 25(Black Eaten) ";
                                Players[Players.FirstOrDefault(x => x.Value.SessionId == OperationContext.Current.SessionId).Key].GetCallbackChannel<IMessageChatCallBack>().IncomingMessageForPlayer(gc);
                            }
                            gc.Cells = GameBoard;
                            Players["Red"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);
                            Players["Black"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);
                            return CheckIfFinishTurn();
                        }
                    }
                    gc.MessageForPlayer = "Invalid operation";
                    Players[Players.FirstOrDefault(x => x.Value.SessionId == OperationContext.Current.SessionId).Key].GetCallbackChannel<IMessageChatCallBack>().IncomingMessageForPlayer(gc);
                    return CheckIfFinishTurn();
                }
                else
                {
                    if (CheckIfEaten())
                    {
                        if (CheckOutOfEat())
                        {
                            if (OutOfEat(current, dicenum))
                            {
                                AvailableMoves.Remove(dicenum);
                                gc.Cells = GameBoard;
                                Players["Red"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);
                                Players["Black"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);
                                return CheckIfFinishTurn();

                            }
                            else
                                return CheckIfFinishTurn();
                        }
                        else
                        {
                            EndTurn();
                            return true;
                        }
                    }

                    if (BlackFinish&& current - dicenum < 1)
                    {
                        
                            TryToFinish(current, dicenum);

                            if (CountOfOutBlack == 15)
                            {
                                Players["Red"].GetCallbackChannel<IMessageChatCallBack>().IncomingWinner(Players.FirstOrDefault(x => x.Value.SessionId == OperationContext.Current.SessionId).Key);
                                Players["Black"].GetCallbackChannel<IMessageChatCallBack>().IncomingWinner(Players.FirstOrDefault(x => x.Value.SessionId == OperationContext.Current.SessionId).Key);
                            }
                            gc.Cells = GameBoard;
                            Players["Red"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);
                            Players["Black"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);
                            return CheckIfFinishTurn();
                        
                    }
                }


                if (CheckMove(current, dicenum))
                {
                    if (GameBoard[current - dicenum].SoldierAmount == 1 && GameBoard[current - dicenum].color == Color.Red)
                    {
                        Eat();
                        GameBoard[current - dicenum].SoldierAmount--;
                        GameBoard[current - dicenum].color = Color.empty;
                        UpdateGameBoard(current, current - dicenum, Color.Black);
                        AvailableMoves.Remove(dicenum);
                        CheckFinish();
                        gc.Cells = GameBoard;
                        Players["Red"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);
                        Players["Black"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);

                        return CheckIfFinishTurn();
                    }
                    else
                    {
                        UpdateGameBoard(current, current - dicenum, Color.Black);
                        AvailableMoves.Remove(dicenum);
                        CheckFinish();
                        if (BlackFinish)
                        {
                            gc.MessageForPlayer = "Your target For win is 0(Red Eaten) ";
                            Players[Players.FirstOrDefault(x => x.Value.SessionId == OperationContext.Current.SessionId).Key].GetCallbackChannel<IMessageChatCallBack>().IncomingMessageForPlayer(gc);
                        }
                        gc.Cells = GameBoard;
                        Players["Red"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);
                        Players["Black"].GetCallbackChannel<IMessageChatCallBack>().GetBoardGame(gc);

                        return CheckIfFinishTurn();
                    }
                }
                gc.MessageForPlayer = "Invalid operation";
                Players[Players.FirstOrDefault(x => x.Value.SessionId == OperationContext.Current.SessionId).Key].GetCallbackChannel<IMessageChatCallBack>().IncomingMessageForPlayer(gc);
                return CheckIfFinishTurn();

            }
            gc.MessageForPlayer = "It's not your turn!!";
            Players[Players.FirstOrDefault(x => x.Value.SessionId == OperationContext.Current.SessionId).Key].GetCallbackChannel<IMessageChatCallBack>().IncomingMessageForPlayer(gc);
            return false;

        }
        public bool CheckAvailableMoves()
        {
            CheckFinish();
            if (Turn)
            {
                if (RedFinish)
                {
                    return AvailableMoves.Any();
                }
                for (int i = 1; i <= 24; i++)
                {


                    if (GameBoard[i].SoldierAmount >= 1 && GameBoard[i].color == Color.Red)
                    {

                        foreach (var item in AvailableMoves)
                        {
                            if (i + item <= 24)
                            {
                                if (CheckMove(i, item)/*||RedFinish*/)
                                    return true;
                            }
                            else
                                return false;
                        }

                    }

                }
                return false;
            }
            else
            {
                if (BlackFinish)
                {
                    return AvailableMoves.Any();
                }
                for (int i = 24; i >= 1; i--)
                {
                    if (GameBoard[i].SoldierAmount >= 1 && GameBoard[i].color == Color.Black)
                    {
                        foreach (var item in AvailableMoves)
                        {
                            if (i - item >= 1)
                            {
                                if (CheckMove(i, item)/*||BlackFinish*/)
                                    return true;
                            }
                            else
                                return false;
                        }
                    }
                }
            }
            return false;
        }

        public bool CheckOutOfEat()
        {
            if (Turn)
            {
                if (GameBoard[0].SoldierAmount >= 1)
                {
                    foreach (var item in AvailableMoves)
                    {
                        if (CheckMove(0, item))
                            return true;
                    }
                    return false;
                }
                return true;
            }
            else
            {
                if (GameBoard[25].SoldierAmount >= 1)
                {
                    foreach (var item in AvailableMoves)
                    {
                        if (CheckMove(25, item))
                            return true;
                    }
                    return false;
                }
            }
            return true;
        }

        public void EndTurn()
        {
            if (!AvailableMoves.Any())
            {

                Turn = !Turn;
                if (!IsTurn)
                    gc.TurnOf = "Black's Turn!!";
                else
                    gc.TurnOf = "Red's Turn!!";
                IsTurn = !IsTurn;
                Players["Red"].GetCallbackChannel<IMessageChatCallBack>().IncomingTurn(gc);
                Players["Black"].GetCallbackChannel<IMessageChatCallBack>().IncomingTurn(gc);
                gc.DiceNumsImg = new string[4];
                Players["Red"].GetCallbackChannel<IMessageChatCallBack>().IncomingDiceNums(gc);
                Players["Black"].GetCallbackChannel<IMessageChatCallBack>().IncomingDiceNums(gc);
            }
            else
            {
                gc.MessageForPlayer = "You can not press on 'End turn' yet";
                Players[Players.FirstOrDefault(x => x.Value.SessionId == OperationContext.Current.SessionId).Key].GetCallbackChannel<IMessageChatCallBack>().IncomingMessageForPlayer(gc);
            }
        }


        public void TryToFinish(int current, int dicenum)
        {
            if (Turn)
            {
                if (AvailableMoves.Contains(dicenum) && GameBoard[dicenum].SoldierAmount > 0 && GameBoard[dicenum].color == Color.Red)
                {
                    GameBoard[current].SoldierAmount--;
                    CountOfOutRed++;
                    AvailableMoves.Remove(dicenum);
                }
                else if (GameBoard[25 - AvailableMoves.Max()].SoldierAmount > 0 && GameBoard[25 - AvailableMoves.Max()].color == Color.Red)
                {
                    GameBoard[25 - AvailableMoves.Max()].SoldierAmount--;
                    CountOfOutRed++;
                    AvailableMoves.Remove(AvailableMoves.Max());
                }
                else
                {
                    bool flag = true;
                    for (int i = 19; i < 25 - AvailableMoves.Max(); i++)
                    {
                        if (GameBoard[i].SoldierAmount > 0 && GameBoard[i].color == Color.Red)
                        {
                            Move(i, AvailableMoves.Max());
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                        for (int i = 25 - AvailableMoves.Max() + 1; i < 25; i++)
                        {
                            if (GameBoard[i].SoldierAmount > 0 && GameBoard[i].color == Color.Red)
                            {
                                GameBoard[i].SoldierAmount--;
                                CountOfOutRed++;
                                AvailableMoves.Remove(AvailableMoves.Max());
                                break;
                            }
                        }
                }
            }
            else
            {
                if (AvailableMoves.Contains(dicenum) && GameBoard[dicenum].SoldierAmount > 0 && GameBoard[dicenum].color == Color.Black)
                {
                    GameBoard[current].SoldierAmount--;
                    CountOfOutBlack++;
                    AvailableMoves.Remove(dicenum);
                }
                else if (AvailableMoves.Contains(AvailableMoves.Max()) && GameBoard[AvailableMoves.Max()].SoldierAmount > 0
                    && GameBoard[AvailableMoves.Max()].color == Color.Black)
                {
                    GameBoard[AvailableMoves.Max()].SoldierAmount--;
                    CountOfOutBlack++;
                    AvailableMoves.Remove(AvailableMoves.Max());
                }
                else
                {
                    bool flag = true;
                    for (int i = 6; i > AvailableMoves.Max(); i--)
                    {
                        if (GameBoard[i].SoldierAmount > 0 && GameBoard[i].color == Color.Black)
                        {
                            Move(i, AvailableMoves.Max());
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                        for (int i = AvailableMoves.Max() - 1; i > 0; i--)
                        {
                            if (GameBoard[i].SoldierAmount > 0 && GameBoard[i].color == Color.Black)
                            {
                                GameBoard[i].SoldierAmount--;
                                CountOfOutBlack++;
                                AvailableMoves.Remove(AvailableMoves.Max());
                                break;
                            }
                        }
                }
            }
        }

        public bool CheckIfFinishTurn()
        {
            if (CheckIfEaten())
            {
                if (!CheckOutOfEat())
                {
                    gc.MessageForPlayer = "You can not keep playing,please turn on 'End turn'";
                    Players[Players.FirstOrDefault(x => x.Value.SessionId == OperationContext.Current.SessionId).Key].GetCallbackChannel<IMessageChatCallBack>().IncomingMessageForPlayer(gc);
                    AvailableMoves = new List<int>();
                    return false;
                }
                else
                    return true;
            }
            else
            {
                if (!CheckAvailableMoves())
                {
                    AvailableMoves = new List<int>();
                    gc.MessageForPlayer = "Your turn is finish/You can not play with these dicecnums,please turn on 'End turn'";
                    Players[Players.FirstOrDefault(x => x.Value.SessionId == OperationContext.Current.SessionId).Key].GetCallbackChannel<IMessageChatCallBack>().IncomingMessageForPlayer(gc);
                    return false;
                }
                else
                    return true;
            }
        }
    }

}
#endregion
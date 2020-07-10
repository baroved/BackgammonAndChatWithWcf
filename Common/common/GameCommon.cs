using Models.Cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.common
{
    [DataContract]
    public class GameCommon
    {
        [DataMember]
        public List<int> DiceNums { get; set; }
        [DataMember]
        public string[] DiceNumsImg { get; set; }
        [DataMember]
        public Cell[] Cells { get; set; }
        [DataMember]
        public string TurnOf { get; set; }
        [DataMember]
        public string MessageForPlayer { get; set; }
        public GameCommon()
        {
            DiceNums = new List<int>();
            DiceNumsImg = new string[4];
            Cells = new Cell[26];
            TurnOf = "Red's Turn !!";
            MessageForPlayer = "";
        }
    }
}

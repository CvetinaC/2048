using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2048.Models
{
    public class GameVM
    {
        public int[,] Matrix { get; set; }
        public int Score { get; set; }
        public bool hasBeenWon { get; set; }
        public bool isGameOver { get; set; }
        public int Result { get; set; }
    }
}
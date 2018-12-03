using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2048.Models;

namespace Tests
{
    public class FillMatrix
    {
       public Game game = new Game();
        public static List<int> list(int [,] matrix)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    numbers.Add(matrix[i, j]);
                }
            }
            return numbers;
        }
    }
}

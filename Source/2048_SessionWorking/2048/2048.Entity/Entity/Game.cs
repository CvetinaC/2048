using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Entity.Entity
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
        public string direction { get; set; }
        public int[,] matrix =new int[4, 4];
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.DAL.Entities
{
    public class GameOutcome
    {
        public int Id { get; set; }
        public int IdWinner { get; set; }
        public int IdLoser { get; set; }
        public DateTime DateStartGame { get; set; }
        public DateTime DateEndGame { get; set; }
    }
}

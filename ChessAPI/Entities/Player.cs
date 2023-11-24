using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessAPI.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Origin { get; set; }
        public virtual List<Opening> Openings { get; set; }
        public virtual List<Tournament> Tournaments { get; set; }
    }
}
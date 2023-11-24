using ChessAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ChessAPI
{
    public class ChessSeeder
    {
        private readonly ChessDbContext _dbContext;
        public ChessSeeder(ChessDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Players.Any())
                {
                    var players = GetPlayers();
                    _dbContext.Players.AddRange(players);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Player> GetPlayers()
        {
            var players = new List<Player>()
            {
                new Player
                {
                    Name = "Magnus",
                    Surname = "Carlsen",
                    Origin = "Norwey",
                    Openings = new List<Opening>()
                    {
                        new Opening()
                        {
                            Name= "Ruy Lopez, Berlin Defense",
                            Moves= "1. e4 e5 2. Nf3 Nc6 3. Bb5 Nf6",
                        },
                        new Opening()
                        {
                            Name= "Sicilian Defense",
                            Moves= "1. e4 e5 2. Nf3 Nc6 3. Bb5 Nf6",
                        },
                        new Opening()
                        {
                            Name= "Ruy Lopez – Open Variation",
                            Moves= "1. e4 e5 2. Nf3 Nc6 3. Bb5 Nf6 4. O-O Nxe4",
                        },
                    },
                    Tournaments = new List<Tournament>()
                    {
                        new Tournament()
                        {
                            Name= "Poland Rapid and Blitz",
                            Prizepool= "$120,000",
                            Date= "from May 19 to 26, 2023",
                            Status= "Invitational"

                        }
                    },
                },
            };

            return players;
        }
    }
}

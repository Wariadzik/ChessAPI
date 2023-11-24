namespace ChessAPI.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prizepool { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
    }
}
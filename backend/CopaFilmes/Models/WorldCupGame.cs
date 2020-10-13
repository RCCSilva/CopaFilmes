namespace CopaFilmes.Models
{
    public class WorldCupGame
    {
        public Game Game { get; set; }

        public WorldCupGame PriorGameA { get; set; }

        public WorldCupGame PriorGameB { get; set; }
    }
}
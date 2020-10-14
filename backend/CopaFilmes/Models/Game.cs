namespace CopaFilmes.Models
{
    public class Game
    {
        public Movie MovieA { get; set; }

        public Movie MovieB { get; set; }

        public Movie Winner
        {
            get {
                if (MovieA.Rating == MovieB.Rating)
                {
                    return MovieA.Title.CompareTo(MovieB.Title) <= 0 ? MovieA : MovieB;
                }
                return MovieA.Rating > MovieB.Rating ? MovieA : MovieB;
            }
        }

        public Movie Looser => Winner == MovieA ? MovieB : MovieA;
    }
}

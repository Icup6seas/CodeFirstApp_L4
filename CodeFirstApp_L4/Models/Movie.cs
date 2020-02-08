namespace CodeFirstApp_L4.Models
{
    public enum Rating
    {
        E, PG, M, R
    }

    public class Movie
    {
        public int MovieID { get; set; }
        public int GenreID { get; set; }
        public int ActorID { get; set; }
        public Rating? Rating { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
namespace CodeFirstApp_L4.Models
{
    public enum Rating
    {
        E, PG, M, R
    }

    public class Summary
    {
        public int SummaryID { get; set; }
        public int MovieID { get; set; }
        public int ActorID { get; set; }
        public Rating? Rating { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
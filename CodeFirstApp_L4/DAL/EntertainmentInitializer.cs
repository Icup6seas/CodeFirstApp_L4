using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CodeFirstApp_L4.Models;

namespace CodeFirstApp_L4.DAL
{
    public class EntertainmentInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EntertainmentContext>
    {
        protected override void Seed(EntertainmentContext context)
        {
            var actors = new List<Actor>
            {
            new Actor{FirstName="Daniel",LastName="Craig",YearActive=DateTime.Parse("1992-01-01")},
            new Actor{FirstName="Sean",LastName="Connery",YearActive=DateTime.Parse("1954-01-01")},
            new Actor{FirstName="Keanu",LastName="Reeves",YearActive=DateTime.Parse("1984-01-01")},
            new Actor{FirstName="Sylvester",LastName="Stallone",YearActive=DateTime.Parse("1970-01-01")},
            };
            actors.ForEach(s => context.Actors.Add(s));
            context.SaveChanges();

            var movies = new List<Movie>
            {
            new Movie{MovieID=1,Title="Knives Out",},
            new Movie{MovieID=2,Title="Diamonds Are Forever",},
            new Movie{MovieID=3,Title="Casino Royale",},
            new Movie{MovieID=4,Title="The Matrix",},
            new Movie{MovieID=5,Title="Rambo: First Blood",},
            };
            movies.ForEach(s => context.Movies.Add(s));
            context.SaveChanges();

            var summaries = new List<Summary>
            {
            new Summary{ActorID=1,MovieID=1,Rating=Rating.R},
            new Summary{ActorID=2,MovieID=2,Rating=Rating.PG},
            new Summary{ActorID=1,MovieID=3,Rating=Rating.PG},
            new Summary{ActorID=3,MovieID=4,Rating=Rating.R},
            new Summary{ActorID=4,MovieID=5,Rating=Rating.R},
            };
            summaries.ForEach(s => context.Summaries.Add(s));
            context.SaveChanges();
        }
    }
}
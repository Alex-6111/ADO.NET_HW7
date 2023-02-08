using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW7
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Studio { get; set; }
        public string Style { get; set; }
        public DateTime ReleaseYear { get; set; }
    }

    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GameDB;Integrated Security=True");
        }
    }

    public class GameRepository
    {
        private readonly GameContext _context;

        public GameRepository(GameContext context)
        {
            _context = context;
        }

        public List<Game> FindGamesByName(string name)
        {
            return _context.Games.Where(g => g.Name == name).ToList();
        }

        public List<Game> FindGamesByStudio(string studio)
        {
            return _context.Games.Where(g => g.Studio == studio).ToList();
        }

        public List<Game> FindGamesByNameAndStudio(string name, string studio)
        {
            return _context.Games.Where(g => g.Name == name && g.Studio == studio).ToList();
        }

        public List<Game> FindGamesByStyle(string style)
        {
            return _context.Games.Where(g => g.Style == style).ToList();
        }

        public List<Game> FindGamesByReleaseYear(int year)
        {
            return _context.Games.Where(g => g.ReleaseYear.Year == year).ToList();
        }
    }



}

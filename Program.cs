namespace ADO.NET_HW7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new GameContext())
            {
                var repository = new GameRepository(context);
                var games = repository.FindGamesByName("Final Fantasy VII Remake");
                foreach (var game in games)
                {
                    Console.WriteLine("Name: " + game.Name + " | Studio: " + game.Studio + " | Style: " + game.Style + " | Release Year: " + game.ReleaseYear.Year);
                }
            }
            Console.ReadLine();
        }
    }
}
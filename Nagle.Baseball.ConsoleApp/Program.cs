using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagle.Baseball.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var homeTeam = new Team(new User("username123"));
            var awayTeam = new Team(new User("username234"));
            var game = new Game(homeTeam, awayTeam);

            while (game.IsDone == false)
            {
                game.Next();
            }

            var snapshot = game.GenerateSnapshot();

            Console.WriteLine(snapshot);

            Console.ReadLine();
        }
    }
}

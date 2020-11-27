using System.Data.Entity;
using HangManDL.Models;

namespace HangManDL
{
    public class HangmanContext : DbContext
    {
        public HangmanContext() :base ("HangMan")
        {
            Database.SetInitializer(new HangmanContextInitializer());
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<ScoreBoard> ScoreBoards { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Word> Word { get; set; }
    }
}

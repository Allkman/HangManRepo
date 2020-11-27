using HangManBL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using HangManDL.Models;
using HangManDL;
using System.Data.Entity;

namespace HangManBL
{
    public class PlayerManager : IPlayerManager
    {
        public int Add(Player entity)
        {
            var key = 0;
            using (var context = new HangmanContext())
            {
                context.Players.Add(entity);
                context.SaveChanges();
                key = entity.PlayerId;
            }
            return key;
           }

        public void Delete(int key)
        {
            using (var context = new HangmanContext())
            {
                var entity = context.Players.Find(key);
                context.Players.Remove(entity);
                context.SaveChanges();
            }                       
        }
        public Player Get(int key)
        {
            Player entity;
            using (var context = new HangmanContext())
            {
                entity = context.Players.Where(z=>z.PlayerId == key).Include(z=>z.ScoreBoards).FirstOrDefault();                
            }
            return entity;
        }
        public List<Player> GetAll()
        {
        List<Player> list;
        using (var context = new HangmanContext())
        {
            list = context.Players.Include(z=>z.ScoreBoards).ToList();
        }
        return list;
        }
        public void Update(Player entity)
        {
            using (var context = new HangmanContext())
            {
                context.Entry(entity).State = EntityState.Modified;        
                context.SaveChanges();
            }
        }
        public void AddScoreBoard( ScoreBoard scoreBoard)
        {
            using (var context = new HangmanContext())
            {
                context.ScoreBoards.Add(scoreBoard);
                context.SaveChanges();
            }
        }
        public Player GetByUserName(string userName)
        {
            Player entity;
            using (var context = new HangmanContext())
            {
                entity = context.Players.Where(z => z.Name == userName).Include(z => z.ScoreBoards).FirstOrDefault();
            }
            return entity;
        }        
    }
}

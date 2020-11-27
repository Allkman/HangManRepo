using HangManDL.Models;

namespace HangManBL.Interfaces
{
    public interface IPlayerManager : ICRUDRepository<Player>
    {
        void AddScoreBoard(ScoreBoard scoreBoard);
        Player GetByUserName(string userName);
    }
}

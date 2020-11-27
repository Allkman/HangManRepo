using HangMan.Interfaces;
using HangManBL;
using HangManBL.Interfaces;

namespace HangMan.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IPlayerManager _playerManager;
        private readonly IUiMassageFactory _massageFactory;

        public StatisticsService()
        {
            _playerManager = new PlayerManager();
            _massageFactory = new UiMassageFactory();
        }
        public void Begin()
        {
            _massageFactory.GeneralStatisticsMessage(_playerManager.GetAll());
        }
    }
}

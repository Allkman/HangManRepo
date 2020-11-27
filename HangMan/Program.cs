using HangManDL;
using HangMan.Interfaces;
using HangMan.Services;

namespace HangMan
{
    class Program
    {
        const int choiceStatistika = 1;
        const int choiceZaidimas = 2;
        static void Main(string[] args)
        {
            using  (var ctx = new HangmanContext())
            {
                IUiMassageFactory massageFactory = new UiMassageFactory();
                var welcomeChoice = massageFactory.WelcomeMessage();

                if (welcomeChoice == choiceZaidimas)
                {
                    IGameService gameService = new GameService();
                    gameService.Begin();
                }
                if (welcomeChoice == choiceStatistika)
                {
                    IStatisticsService service = new StatisticsService();
                    service.Begin();
                }
            }
        }
    }
}

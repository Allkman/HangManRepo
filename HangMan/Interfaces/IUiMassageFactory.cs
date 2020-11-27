using HangManDL.Models;
using System.Collections.Generic;

namespace HangMan.Interfaces
{
    public interface IUiMassageFactory
    {
        void GeneralStatisticsMessage(List<Player> players);
        void HangmanPictureMessage(int incorrectGuessCount);
        void IncorrectLettersListMessage(List<string> neteisingiSpejimai);
        string LoginMesage();
        void LostGameMessage(string zodis);
        void PlayerStatisticsMessage(Player player);
        bool RepeatGameMessage();
        int WelcomeMessage();
        void WinGameMessage(string zodis);
        string WordInputMessage();
    }
}
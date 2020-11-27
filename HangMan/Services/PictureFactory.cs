using HangMan.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.Services
{
    public class PictureFactory : IPictureFactory
    {
        public void DisplayPicture(int incorrectGuessCount)
        {
            Console.Clear();
            switch (incorrectGuessCount)
            {
                case 0:
                    IsvestiPradiniPaveiksleli();
                    break;
                case 1:
                    IsvestiGalva();
                    break;
                case 2:
                    IsvestiKaklas();
                    break;
                case 3:
                    IsvestiKunas();
                    break;
                case 4:
                    IsvestiRanka1();
                    break;
                case 5:
                    IsvestiRanka2();
                    break;
                case 6:
                    IsvestiKoja1();
                    break;
                case 7:
                    IsvestiKoja2();
                    break;
            }
        }
            private void IsvestiPradiniPaveiksleli()
            {
                Console.WriteLine(@"   ---------|    ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"_ _ _ _");
            }
            private void IsvestiGalva()
            {
                Console.WriteLine(@"   ---------|    ");
                Console.WriteLine(@"|           o    ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"_ _ _ _");
            }
            private void IsvestiKaklas()
            {
                Console.WriteLine(@"   ---------|    ");
                Console.WriteLine(@"|           o    ");
                Console.WriteLine(@"|           |    ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"_ _ _ _");
            }
            private void IsvestiKunas()
            {
                Console.WriteLine(@"   ---------|    ");
                Console.WriteLine(@"|           o    ");
                Console.WriteLine(@"|           |    ");
                Console.WriteLine(@"|           O    ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"_ _ _ _");
            }
            private void IsvestiRanka1()
            {
                Console.WriteLine(@"   ---------|    ");
                Console.WriteLine(@"|           o    ");
                Console.WriteLine(@"|          \|    ");
                Console.WriteLine(@"|           O    ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"_ _ _ _");
            }
            private void IsvestiRanka2()
            {
                Console.WriteLine(@"   ---------|    ");
                Console.WriteLine(@"|           o    ");
                Console.WriteLine(@"|          \|/   ");
                Console.WriteLine(@"|           O    ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"_ _ _ _");
            }
            private void IsvestiKoja1()
            {
                Console.WriteLine(@"   ---------|    ");
                Console.WriteLine(@"|           o    ");
                Console.WriteLine(@"|          \|/   ");
                Console.WriteLine(@"|           O    ");
                Console.WriteLine(@"|          /     ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"_ _ _ _");
            }
            private void IsvestiKoja2()
            {
                Console.Clear();
                Console.WriteLine(@"   ---------|    ");
                Console.WriteLine(@"|           o    ");
                Console.WriteLine(@"|          \|/   ");
                Console.WriteLine(@"|           O    ");
                Console.WriteLine(@"|          / \   ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"|                ");
                Console.WriteLine(@"_ _ _ _");
            }
        }
    }



using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace MyFirstProject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Random rnd = new Random();
            string Kaart = "";
            int wallet = 100;
            int inzet = 0;
            int KaartRnd;
            int totaalspeler = 0;
            int totaaldealer = 0;
            int totaal = 0;
            int totaal2 = 0;
            bool playagain = false;
            string playagaininput;
            bool playerhits = false;
            bool Bust = false;
            bool Dealerbust = false;
            String Playerinput;
            bool playagaininputvalid = true;
            Console.WriteLine($"Welkom bij BlowJack, het casino geeft je: {wallet} euro. veel plezier");

            Console.WriteLine($"Hoeveel wil je inzetten?");
            inzet = Convert.ToInt16(Console.ReadLine());


            String[] kaarten = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            int beginkaarten(int sum)
            {
                Console.WriteLine("je hand:");
                KaartRnd = rnd.Next(0, kaarten.Length);
                Console.Write($"Kaart 1: {kaarten[KaartRnd]} ");

                if (KaartRnd < 9) { sum = sum + KaartRnd + 1; }
                else if (KaartRnd < 12) { sum = sum + 10; }
                else {sum = sum + 11; }

                KaartRnd = rnd.Next(0, kaarten.Length);
                Console.WriteLine($"Kaart 2: {kaarten[KaartRnd]}");

                if (KaartRnd < 9) { sum = sum + KaartRnd + 1; }
                else if (KaartRnd < 14  ) { sum = sum + 10; }
                else { sum = sum + 11; }

                return sum;
            }

            int dealerkaart(int sum)
            {

                KaartRnd = rnd.Next(0, kaarten.Length);
                Console.WriteLine($"Dealer kaart: {kaarten[KaartRnd]}");

                if (KaartRnd < 10) { sum = sum + KaartRnd + 1; }
                else if (KaartRnd < 14) { sum = sum + 10; }
                else { sum = sum + 11; }

                return sum;
            }

            int spelerkaart(int sum)
            {

                KaartRnd = rnd.Next(0, kaarten.Length);
                Console.WriteLine($"Je kaart is {kaarten[KaartRnd]}");

                if (KaartRnd < 9) { sum = sum + KaartRnd + 1; }
                else if (KaartRnd < 14) { sum = sum + 10; }
                else { sum = sum + 11; }


                return sum;
            }





            do
            {

                totaal += beginkaarten(totaalspeler);
                Console.WriteLine($"je hebt nu {totaal}");


                totaal2 += dealerkaart(totaaldealer);



                do
                {



                    if (totaal < 21)
                    {
                        Console.WriteLine($"wil je hitten?");
                        Console.WriteLine($"j/n");
                        Playerinput = Console.ReadLine();
                        Playerinput = Playerinput.ToLower();
                        if (Playerinput == "j")
                        {
                            totaal += spelerkaart(totaalspeler);

                            playerhits = true;

                            Console.WriteLine($"je hebt nu {totaal}");
                        }
                        else if (Playerinput == "n")
                        {
                            playerhits = false;
                        }
                        else
                        {
                            Console.WriteLine("geen valid input, probeer opnieuw");
                        }
                    }
                    else
                    {
                        playerhits = false;
                        Bust = true;
                    }
                } while (playerhits == true);


                if (playerhits == false && Bust == false)
                {
                    while (totaal2 < 17)
                    {
                        totaal2 += dealerkaart(totaaldealer);
                        await Task.Delay(500);
                        Console.WriteLine($"De dealer heeft nu {totaal2}");
                        if (totaal2 <= 21) {
                            if (totaal > totaal2)
                            {
                                wallet = +inzet;
                                Console.WriteLine($"Gewonnen! wallet is nu {wallet}");
                            }
                            else if (totaal == totaal2) { Console.WriteLine("Gelijkspel! je wallet blijft hetzelfde"); }
                            else
                            {
                                wallet -= inzet;
                                Console.WriteLine($"Helaas, je wallet is nu {wallet}");
                            }
                        }
                        else {
                            wallet = +inzet;
                            Console.WriteLine($"Dealer teveel! wallet is nu {wallet}");
                        }
                        await Task.Delay(500);
                    }


                }


                
                    do
                    {
                        Console.WriteLine("Want to play again?");
                        Console.WriteLine("j/n");
                        playagaininput = Console.ReadLine();
                        playagaininput = playagaininput.ToLower();
                        if (playagaininput == "j")
                        {
                            playagain = true;
                        }
                        else if (playagaininput == "n")
                        {
                            playagain = false;
                        }
                        else
                        {
                            Console.WriteLine("invalid input, try again");
                        }
                    } while (playagaininputvalid == false);
                
            } while (playagain == true);
            Console.ReadKey();


        }
    }
}
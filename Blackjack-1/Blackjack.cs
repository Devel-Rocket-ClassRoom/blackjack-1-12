using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Blackjack player = new Blackjack("플레이어");
        Blackjack dealer = new Blackjack("딜러");

        bool gameContinue = true;

        while (gameContinue)
        {
            Blackjack.ResetGame();
            player.ResetHand();
            dealer.ResetHand();
            Console.Clear();
            Console.WriteLine("=== 새 게임 시작 === ");
            Console.WriteLine("\n카드를 섞는 중...");

            player.Drawcard();
            dealer.Drawcard();
            player.Drawcard();
            dealer.Drawcard();


            Console.WriteLine("\n=== 초기패 ===");
            dealer.ShowAllCards(isFirstRound: true);
            player.ShowAllCards();
            player.ShowScore();

            bool roundOver = false;

            if (player.TotalScore == 21)
            {
                Console.WriteLine("\n플레이어 블랙잭!");

                dealer.ShowAllCards();
                dealer.ShowScore();

                roundOver = true;
            }

            while (!roundOver && player.TotalScore < 21)
            {
                Console.Write("\n H(Hit) 또는 S(Stand)를 선택하세요: ");
                string choice = Console.ReadLine().ToUpper();

                if (choice == "H")
                {
                    player.Drawcard();
                    player.ShowLastCard();
                    player.ShowAllCards();
                    player.ShowScore();
                }
                else if (choice == "S")
                {
                    break;
                }
            }

            if (!roundOver && player.TotalScore <= 21)
            {
                Console.WriteLine("\n=== 딜러의 차례 ===");
                dealer.ShowAllCards();

                while (dealer.TotalScore < 17)
                {
                    dealer.Drawcard();
                    dealer.ShowLastCard();
                    dealer.ShowScore();
                }
            }





            Console.WriteLine("\n============================");
            Console.WriteLine("=== 게임 결과 ===");
            dealer.ShowAllCards();
            dealer.ShowScore();
            Console.WriteLine();
            player.ShowAllCards();
            player.ShowScore();
            Console.WriteLine("============================");

            Winner(player.TotalScore, dealer.TotalScore);

            Console.Write("\n새 게임을 하시겠습니까? (Y/N): ");
            gameContinue = Console.ReadLine().ToUpper() == "Y";


            static void Winner(int pScore, int dScore)
            {
                if (pScore > 21)
                {
                    Console.WriteLine("버스트! 21을 초과했습니다. 딜러 승리!");
                }
                else if (dScore > 21)
                {
                    Console.WriteLine("버스트! 21을 초과했습니다. 플레이어 승리!");
                }
                else if (pScore > dScore)
                {
                    Console.WriteLine("플레이어 승리!");
                }
                else if (pScore < dScore)
                {
                    Console.WriteLine("딜러 승리!");
                }
                else
                {
                    Console.WriteLine("무승부(Push)입니다.");
                }
            }
        }
    }
}


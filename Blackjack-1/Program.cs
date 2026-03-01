using System;
using System.Net.Sockets;
class Blackjack
{
    private static string[,] cardDeck = new string[4, 13];
    private static bool[,] isUsed = new bool[4, 13];
    private static bool isDealerStop = false;
    private string name;
    private int cardCount = 0;
    private static Random random = new Random();
    private int[] cardshape = new int[11];
    private int[] cardnumber = new int[11];

    public int TotalScore
    {
        get
        {
            int score = 0;
            int Acount = 0;

            for (int i = 0; i < cardCount; i++)
            {
                int valueIdx = cardnumber[i];

                if (valueIdx == 0)
                {
                    Acount++;
                    score += 11;
                }
                else if (valueIdx >= 9)
                {
                    score += 10;
                }
                else
                {
                    score += (valueIdx + 1);
                }
            }

            while (score > 21 && Acount > 0)
            {
                score -= 10;
                Acount--;
            }
            return score;
        }
    }
    public Blackjack(string name)
    {
        this.name = name;
        string[] shapes = { "♠", "◆", "♥", "♣" };
        string[] numbers = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                cardDeck[i, j] = shapes[i] + numbers[j];
            }
        }
    }

    public void Drawcard()
    {
        while (true)
        {
            int shape = random.Next(0, 4);
            int number = random.Next(0, 13);

            if (!isUsed[shape, number])
            {
                isUsed[shape, number] = true;
                cardshape[cardCount] = shape;
                cardnumber[cardCount] = number;
                cardCount++;
                break;
            }
        }
    }

    public void ShowLastCard()
    {
        int last = cardCount - 1;
        Console.WriteLine($"{name}가 카드를 받았습니다: {GetCardName(cardshape[last], cardnumber[last])}");
    }

    public void ShowAllCards(bool isFirstRound = false)
    {
        Console.Write($"{name}의 패: ");

        if (name == "딜러" && isFirstRound)
        {
            Console.WriteLine("[??], " + GetCardName(cardshape[1], cardnumber[1]));
            Console.WriteLine("딜러의 점수: ?");
        }
        else
        {
            for (int i = 0; i < cardCount; i++)
            {
                Console.Write(GetCardName(cardshape[i], cardnumber[i]) + (i == cardCount - 1 ? "" : ", "));
            }
            Console.WriteLine();
        }
    }

    public void ShowScore(bool isFirstRound = false)
    {
        if (name == "딜러" && isFirstRound)
        {
            Console.WriteLine($"{name}의 현재 점수: ?");
        }
        else
        {
            int score = TotalScore;
            Console.Write($"{name} 점수: {score}");
            if (score == 21) Console.Write(" (블랙잭!)");
            Console.WriteLine();
        }
    }




public static void ResetGame()
    {
        Array.Clear(isUsed, 0, isUsed.Length);
        isDealerStop = false;
    }

    public static string GetCardName(int shapeIdx, int valueIdx)
    {
        return cardDeck[shapeIdx, valueIdx];
    }

    public void Resethand()
    {

    }
    public void ResetHand()
    {
        cardCount = 0;
        Array.Clear(cardshape, 0, cardshape.Length);
        Array.Clear(cardnumber, 0, cardnumber.Length);
    }

}


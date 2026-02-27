using System;
using System.Text;

class Blackjack
{
    static int[,] card = new int[4, 13];
    static bool[,] usedcard = new bool[4, 13];
    static string[] playercard;
    static string[] dealercard;

    public Blackjack()
    {

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
                card[i, j] = j + 1;

        }
    }



    static public void Select()
    {
        int shape = 0;
        int number = 0;
        while (true)
        {
            Random random = new Random();

            shape = random.Next(1, 5);
            number = random.Next(1, 14);


            if (usedcard[shape, number] == false)
                break;

        }
        usedcard[shape, number] = true;


    }
    public string Printcard(int shape, int number)
    {
        StringBuilder sb = new StringBuilder();

        switch (shape)
        {
            case 1:
                sb.Append("♠");
                break;
            case 2:
                sb.Append("♥");
                break;
            case 3:
                sb.Append("♣");
                break;
            case 4:
                sb.Append("♦");
                break;
        }
        if (number > 1 && number < 11) { return sb.Append(number).ToString(); }
        else
        {
            switch (number)
            {
                case 1:
                    return sb.Append("A").ToString();

                case 11:
                    return sb.Append("J").ToString();

                case 12:
                    return sb.Append('Q').ToString();

                case 13:
                    return sb.Append('K').ToString();
                default:
                    return "";

            }
        }
    }

}
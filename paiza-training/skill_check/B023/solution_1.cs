using System;
class Program
{
    const int MTNUM = 7;
    static void Main()
    {
        var line = Console.ReadLine();
        int[] number = new int[line.Length];
        NumberOfMatch[] num = new NumberOfMatch[line.Length];
        for (int i = 0; i < line.Length; i++)
        {
            number[i] = int.Parse(line[i].ToString());
            num[i] = new NumberOfMatch(number[i]);
        }
        Vector Vec0;
        Vector Vec1;
        //Indicate(number);
        int x;
        num[0].ShowNumAsVec();
        num[1].ShowNumAsVec();
        for (int k = 0; k < line.Length; k++)
        {
            for (int l = 1; l < line.Length; l++)
            {
                Vec0 = new Vector(num[k].GetVector());
                Vec1 = new Vector(num[l].GetVector());
                Console.Write(Vec0.GetNumber());
                Console.Write(Vec1.GetNumber());
                Console.WriteLine("");
                Vec0.ShowElements();
                Vec1.ShowElements();
                for (int i = 0; i < MTNUM; i++)
                {
                    for (int j = 0; j < MTNUM; j++)
                    {
                        if (Exchange(Vec0.Elements, Vec1.Elements, i, j) == 1)
                        {
                            if (Vec0.GetNumber() != -1 && Vec1.GetNumber() != -1)
                            {
                                Console.WriteLine(i + "," + j);
                                Console.Write(Vec0.GetNumber() + " " + Vec1.GetNumber());
                                Console.WriteLine("");
                                Vec0.ShowElements();
                                Vec1.ShowElements();
                                x = Exchange(Vec0.Elements, Vec1.Elements, i, j);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    static int Exchange(int[] numA, int[] numB, int i, int j)
    {
        if (numA[i] == 1 && numB[j] == 0)
        {
            numA[i] = 0;
            numB[j] = 1;
            //Console.WriteLine("changed");
            return 1;
        }
        else if (numA[i] == 0 && numB[j] == 1)
        {
            numA[i] = 1;
            numB[j] = 0;
            //Console.WriteLine("changed");
            return 1;
        }
        else
        {
            return 0;
        }
    }

    internal class NumberOfMatch : Matches
    {
        public int Number;

        public NumberOfMatch(int num)
        {
            this.Number = num;
        }

        internal void ShowNumAsVec()
        {
            for (int i = 0; i < MTNUM; i++)
            {
                Console.Write(GetVector()[i]);
            }
            Console.WriteLine("");
        }
        internal int[] GetVector()
        {
            int[] vector = new int[MTNUM];
            for (int i = 0; i < MTNUM; i++)
            {
                vector[i] = MatchList[Number, i];
            }
            return vector;
        }
    }

    internal class Vector : Matches
    {
        public int[] Elements;
        public Vector(int[] input)
        {
            this.Elements = input;
        }

        /*public int ExistNum()
        {
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < MTNUM; i++)
                {
                    if (Elements[i] != MatchList[j, i])
                    {
                        break;
                    }
                }
                if (i == MUNUM)
                {
                    return 1;
                }
            }
            if (j == 10)
            {
                return 0;
            }
        }*/

        public int GetNumber()
        {
            for (int j = 0; j < 10; j++)
            {
                int cnt = 0;
                for (int i = 0; i < MTNUM; i++)
                {
                    if (this.Elements[i] == MatchList[j, i])
                    {
                        cnt += 1;
                    }
                    else
                    {
                        cnt = 0;
                        break;
                    }
                }
                if (cnt == 7)
                {
                    return j;
                }
            }
            return -1;
        }
        public void ShowElements()
        {
            for (int i = 0; i < MTNUM; i++)
            {
                Console.Write(Elements[i]);
            }
            Console.WriteLine("");
        }
    }
    internal class Matches
    {

        protected int[,] MatchList = new int[10, MTNUM]
        {
            { 1, 1, 1, 0, 1, 1, 1 },
            { 0, 0, 1, 0, 0, 1, 0 },
            { 1, 0, 1, 1, 1, 0, 1 },
            { 1, 0, 1, 1, 0, 1, 1 },
            { 0, 1, 1, 1, 0, 1, 0 },
            { 1, 1, 0, 1, 0, 1, 1 },
            { 1, 1, 0, 1, 1, 1, 1 },
            { 1, 0, 1, 0, 0, 1, 0 },
            { 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 0, 1, 1 },
        };
    }

    static void Indicate(int[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            Console.Write(num[i] + " ");
        }
        Console.WriteLine();
    }
}
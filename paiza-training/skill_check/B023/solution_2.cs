using System;
using System.Collections.Generic;

class Program
{

    const int MatchLength = 7;

    static void Main()
    {
        DataClass.GetData();
        //DataClass.PrintData(DataClass.Number);
        DataClass.GetGroup();
        //DataClass.PrintAnswers();
        //int[] vector = {0,1,1,1,0,1,0};
        //Console.Write(Matches.CorrectNumber(vector));
    }

    internal static class DataClass
    {
        public static string TextLine;
        public static int[] Number;
        public static int[][] Answer;

        public static void GetData() 
        { 
            TextLine = Console.ReadLine();
            Number = new int[TextLine.Length];
            for (int i = 0; i < TextLine.Length; i++)
            {
                Number[i] = int.Parse(TextLine[i].ToString());
            }
        }

        public static void GetGroup()
        {
            /*int m = 0;
            int n = 0;
            int o = 0;
            int p = 0;*/
            //List<int[]> Answers = new List<int[]>();
            SortedSet<int> Answers = new SortedSet<int>();
            Answer = new int[TextLine.Length][];
            for (int i = 0; i < TextLine.Length; i++)
            {
                Answer[i] = new int [MatchLength];
                for (int j = 0; j < MatchLength; j++)
                {
                    Answer[i][j] = Matches.DigitPatterns[Number[i]][j];
                }
            }

            for (int i = 0; i < TextLine.Length; i++)
            {   
                for (int j = 0; j < MatchLength; j++)
                {
                    if (Answer[i][j] == 1)
                    {
                        Answer[i][j] = 0;
                        for (int k = 0; k < TextLine.Length; k++)
                        {
                            for (int l = 0; l < MatchLength ; l++)
                            {
                                if (i != k || j != l)
                                {
                                    if (Answer[k][l] == 0)
                                    {
                                        Answer[k][l] = 1;
                                        if (Matches.CorrectNumber(Answer[k]) != -1) {
                                            //Console.Write("i = " + i + ", j = " + j + ", k =" + k + ", l =" + l + " ");
                                            //Console.WriteLine("");
                                            //PrintAnswers();
                                            Answers.Add(Answer[k]);
                                        }
                                        Answer[k][l] = 0; 
                                    }
                                }
                            }
                        }
                        Answer[i][j] = 1;
                    }
                }
            }
            foreach (int[] arr in Answers)
            {
                for (int i = 0; i < MatchLength; i++)
                {
                    Console.Write(arr[i]);
                }
                Console.WriteLine("");
            }
        }

        public static void PrintData(int[] Num)
        {
            for (int i = 0; i < TextLine.Length; i++)
            {
                Console.Write(Num[i]);
            }
            Console.WriteLine("");
        }

        /*public static void PrintAnswers()
        {
            int key=-1;
            for (int i = 0; i < TextLine.Length; i++)
            {
                key = Matches.CorrectNumber();
                if (key == -1) {
                    return;
                }
            }
            for (int i = 0; i < TextLine.Length; i++)
            {
                Console.Write(Matches.CorrectNumber(Answer[i]));
            }
            Console.WriteLine("");
        }*/  
    }

    internal static class Matches
    {
        public static int[][] DigitPatterns = new int[][]
        {
            new int[] { 1, 1, 1, 0, 1, 1, 1 }, // 0
            new int[] { 0, 0, 1, 0, 0, 1, 0 }, // 1
            new int[] { 1, 0, 1, 1, 1, 0, 1 }, // 2
            new int[] { 1, 0, 1, 1, 0, 1, 1 }, // 3
            new int[] { 0, 1, 1, 1, 0, 1, 0 }, // 4
            new int[] { 1, 1, 0, 1, 0, 1, 1 }, // 5
            new int[] { 1, 1, 0, 1, 1, 1, 1 }, // 6
            new int[] { 1, 0, 1, 0, 0, 1, 0 }, // 7
            new int[] { 1, 1, 1, 1, 1, 1, 1 }, // 8
            new int[] { 1, 1, 1, 1, 0, 1, 1 }, // 9
        };

        public static int CorrectNumber(int[] Match)
        {
            for (int i = 0; i < 10; i++)
            {
                bool isValid = true;
                for (int j = 0; j < MatchLength; j++)
                {
                    if (Match[j] != Matches.DigitPatterns[i][j])
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
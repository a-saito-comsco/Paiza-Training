using System;
using System.Collections.Generic;
using System.Linq;

class Program
{

    const int MatchLength = 7;
    static void Main()
    {
        DataClass.GetData();
        //DataClass.GetGroup();
        
    }

    internal static class DataClass
    {
        public static string TextLine;
        public static int[] Number;
        public static int[][] PreAnswers;
        public static List<int[]> Answers;

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
            PreAnswers = new int[TextLine.Length][];

            for (int i = 0; i < TextLine.Length; i++)
            {
                PreAnswers[i] = new int[MatchLength];
                for (int j = 0; j < MatchLength; j++)
                {
                    PreAnswers[i][j] = Matches.DegitPatterns[Number[i]][j];
                }
            }

            // List<T>を使用して動的にサイズを管理
            Answers = new List<int[]>();

            for (int i = 0; i < TextLine.Length; i++)
            {
                for (int j = 0; j < MatchLength; j++)
                {
                    if (PreAnswers[i][j] == 1)
                    {
                        PreAnswers[i][j] = 0;
                        for (int k = 0; k < TextLine.Length; k++)
                        {
                            for (int l = 0; l < MatchLength; l++)
                            {
                                if (i != k || j != l)
                                {
                                    if (PreAnswers[k][l] == 0)
                                    {
                                        PreAnswers[k][l] = 1;
                                        if (Matches.CorrectNumber(PreAnswers[i]) != -1 && Matches.CorrectNumber(PreAnswers[k]) != -1)
                                        {
                                            AddAnswer();
                                        }
                                        PreAnswers[k][l] = 0;
                                    }
                                }
                            }
                        }
                        PreAnswers[i][j] = 1;
                    }
                }
            }
            if (Answers.Count == 0)
            {
                Console.WriteLine("none");
            }
            else
            {
                SortAnswers();
                PrintAnswers();
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

        public static void AddAnswer()
        {
            var newAnswer = new int[TextLine.Length];
            for (int i = 0; i < TextLine.Length; i++)
            {
                newAnswer[i] = Matches.CorrectNumber(PreAnswers[i]);
            }
            Answers.Add(newAnswer);
        }

        public static void SortAnswers()
        {
            Answers.Sort((a, b) => string.Join("", a).CompareTo(string.Join("", b)));
        }
        public static void PrintAnswers()
        {
            foreach (var answer in Answers)
            {
                for (int j = 0; j < TextLine.Length; j++)
                {
                    Console.Write(answer[j]);
                }
                Console.WriteLine("");
            }
        }  
    }

    internal static class Matches
    {
        public static Dictionary<int, int[]> DegitPatterns = new Dictionary<int, int[]>
        {
            { 0, new int[] { 1, 1, 1, 0, 1, 1, 1 } },
            { 1, new int[] { 0, 0, 1, 0, 0, 1, 0 } },
            { 2, new int[] { 1, 0, 1, 1, 1, 0, 1 } },
            { 3, new int[] { 1, 0, 1, 1, 0, 1, 1 } },
            { 4, new int[] { 0, 1, 1, 1, 0, 1, 0 } },
            { 5, new int[] { 1, 1, 0, 1, 0, 1, 1 } },
            { 6, new int[] { 1, 1, 0, 1, 1, 1, 1 } },
            { 7, new int[] { 1, 0, 1, 0, 0, 1, 0 } },
            { 8, new int[] { 1, 1, 1, 1, 1, 1, 1 } },
            { 9, new int[] { 1, 1, 1, 1, 0, 1, 1 } },
        };

        public static Dictionary<String, int> ReversePatterns = new Dictionary<string, int>
        {
            { "1110111" ,0 },
            { "0010010" ,1 },
            { "1011101" ,2 },
            { "1011011" ,3 },
            { "0111010" ,4 },
            { "1101011" ,5 },
            { "1101111" ,6 },
            { "1010010" ,7 },
            { "1111111" ,8 },
            { "1111011" ,9 },
        };
        
        public static int CorrectNumber(int[] Match)
        {
            String keyString = String.Join(",", Match);
            Console.WriteLine(keyString);//改修中途
            /*if (ReversePatterns.Containskey(keyString))
            {
                ReversePatterns.TryGetValue(keyString, out var name);
                return name;
            }
            else
            {
                return -1;
            }*/
        }
    }
}
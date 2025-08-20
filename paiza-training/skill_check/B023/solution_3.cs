using System;
using System.Collections.Generic;
using System.Linq;

class Program
{

    const int MatchLength = 7;
    static void Main()
    {
        DataClass.GetData();
        Matches.MakeTransTable();
        DataClass.GetGroup();
        DataClass.Answers.Sort();
        DataClass.Answers.ForEach(x => Console.WriteLine(x));
        if (DataClass.Answers.Count == 0)
        {
            Console.WriteLine("none");
        }
    }

    internal static class DataClass
    {
        public static string TextLine;
        public static int[] Number;
        public static int[] Answer;

        public static List<string> Answers;
        public static List<(int before, int after)> MinusTable = new List<(int before, int after)>();
        public static List<(int before, int after)> PlusTable = new List<(int before, int after)>();
        public static List<(int before, int after)> BothTable = new List<(int before, int after)>();

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
            Answers = new List<string>();
            Answer = new int[TextLine.Length];
            for (int i = 0; i < DataClass.TextLine.Length; i++)
            {
                Answer[i] = Number[i];
            }

            for (int i = 0; i < DataClass.TextLine.Length; i++)
            {
                for (int j = 0; j < DataClass.TextLine.Length; j++)
                {
                    if (i == j)
                    {
                        var items = BothTable.FindAll(x => x.before == Number[i]);
                        foreach (var item in items)
                        {
                            Answer[i] = item.after;
                            string st = string.Join("", Answer);
                            Answers.Add(st);
                            Answer[i] = Number[i];
                        }
                    }
                    else
                    {
                        var itemIs = MinusTable.FindAll(y => y.before == Number[i] && (y.after != 0 || y.before == 8));
                        var itemJs = PlusTable.FindAll(z => z.before == Number[j] && z.after != 0);
                        foreach (var itemI in itemIs)
                        {
                            foreach (var itemJ in itemJs)
                            {
                                Answer[i] = itemI.after;
                                Answer[j] = itemJ.after;
                                string st = string.Join("", Answer);
                                Answers.Add(st);
                                for (int k = 0; k < DataClass.TextLine.Length; k++)
                                {
                                    Answer[k] = Number[k];
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    internal static class Matches
    {
        public static Dictionary<int, string> DegitPatterns = new Dictionary<int, string>
        {
            {0, "1110111"},
            {1, "0010010"},
            {2, "1011101"},
            {3, "1011011"},
            {4, "0111010"},
            {5, "1101011"},
            {6, "1101111"},
            {7, "1010010"},
            {8, "1111111"},
            {9, "1111011"},
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

        public static void MakeTransTable()
        {
            char[] Stnum;
            int BackValue;
            for (int i = 0; i < DegitPatterns.Count; i++)
            {
                DegitPatterns.TryGetValue(i, out var bpattern);
                for (int j = 0; j < MatchLength; j++)
                {
                    Stnum = bpattern.ToCharArray();
                    if (Stnum[j].Equals('1'))
                    {
                        Stnum[j] = '0';
                        string pattern = new String(Stnum);
                        BackValue = CorrectNumber(pattern);
                        if (BackValue != -1)
                        {
                            DataClass.MinusTable.Add((CorrectNumber(bpattern), BackValue));
                        }
                    }
                }
                for (int j = 0; j < MatchLength; j++)
                {
                    Stnum = bpattern.ToCharArray();
                    if (Stnum[j].Equals('0'))
                    {
                        Stnum[j] = '1';
                        string pattern = new String(Stnum);
                        BackValue = CorrectNumber(pattern);
                        if (BackValue != -1)
                        {
                            DataClass.PlusTable.Add((CorrectNumber(bpattern), BackValue));
                        }
                    }
                }
                for (int j = 0; j < MatchLength; j++)
                {
                    Stnum = bpattern.ToCharArray();
                    if (Stnum[j].Equals('1'))
                    {
                        Stnum[j] = '0';
                        for (int k = 0; k < MatchLength; k++)
                        {
                            if (k != j)
                            {
                                if (Stnum[k] == '0')
                                {
                                    Stnum[k] = '1';
                                    string pattern = new String(Stnum);
                                    BackValue = CorrectNumber(pattern);
                                    if (BackValue != -1)
                                    {
                                        DataClass.BothTable.Add((CorrectNumber(bpattern), BackValue));
                                    }
                                    Stnum[k] = '0';
                                }
                            }
                        }
                    }
                }
            }            
        }
        public static int CorrectNumber(string Match)
        {
            if (ReversePatterns.ContainsKey(Match))
            {
                ReversePatterns.TryGetValue(Match, out var number);
                return number;
            }
            else
            {
                return -1;
            }
        }
    }
}
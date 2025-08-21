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
                        var itemIs = MinusTable.FindAll(x => x.before == Number[i]);
                        var itemJs = PlusTable.FindAll(x => x.before == Number[j]);
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
            char[] stringNum;
            int backValue;
            for (int i = 0; i < DegitPatterns.Count; i++)
            {
                DegitPatterns.TryGetValue(i, out var oldPattern);
                for (int j = 0; j < MatchLength; j++)
                {
                    stringNum = oldPattern.ToCharArray();
                    if (stringNum[j].Equals('1'))
                    {
                        stringNum[j] = '0';
                        string newPattern = new String(stringNum);
                        backValue = CorrectNumber(newPattern);
                        if (backValue != -1)
                        {
                            DataClass.MinusTable.Add((CorrectNumber(oldPattern), backValue));
                        }
                    }
                }
                for (int j = 0; j < MatchLength; j++)
                {
                    stringNum = oldPattern.ToCharArray();
                    if (stringNum[j].Equals('0'))
                    {
                        stringNum[j] = '1';
                        string newPattern = new String(stringNum);
                        backValue = CorrectNumber(newPattern);
                        if (backValue != -1)
                        {
                            DataClass.PlusTable.Add((CorrectNumber(oldPattern), backValue));
                        }
                    }
                }
                for (int j = 0; j < MatchLength; j++)
                {
                    stringNum = oldPattern.ToCharArray();
                    if (stringNum[j].Equals('1'))
                    {
                        stringNum[j] = '0';
                        for (int k = 0; k < MatchLength; k++)
                        {
                            if (k != j)
                            {
                                if (stringNum[k] == '0')
                                {
                                    stringNum[k] = '1'; 
                                    string newPattern = new String(stringNum);
                                    backValue = CorrectNumber(newPattern);
                                    if (backValue != -1)
                                    {
                                        DataClass.BothTable.Add((CorrectNumber(oldPattern), backValue));
                                    }
                                    stringNum[k] = '0';
                                }
                            }
                        }
                    }
                }
            }            
        }
        public static int CorrectNumber(string match)
        {
            if (ReversePatterns.ContainsKey(match))
            {
                ReversePatterns.TryGetValue(match, out var number);
                return number;
            }
            else
            {
                return -1;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        LoopFunction();        
    }
    
    internal static class Config
    {
        internal static int PersonsNumber{ get; private set; }
        internal static int AccessPointsNumber { get; private set; }
        internal static int Start{ get; private set; }
        internal static int Goal{ get; private set; }

        internal static int[] RuletResult { get; private set; }

        internal static List<(int, int)> AllRoads{ get; } = new List<(int, int)>();

        static Config()
        {
            GetInputs();
        }

        internal static void GetInputs()
        {
            var line = Console.ReadLine();
            var text = line.Split(" ");
            PersonsNumber = int.Parse(text[0]);
            AccessPointsNumber = int.Parse(text[1]);
            line = Console.ReadLine();
            text = line.Split(" ");
            Start = int.Parse(text[0]);
            Goal = int.Parse(text[1]);
            RuletResult = new int[PersonsNumber];
            for (int i = 0; i < PersonsNumber; i++)
            {
                line = Console.ReadLine();
                RuletResult[i] = int.Parse(line);
            }
            for (int i = 0; i < AccessPointsNumber; i++)
            {
                line = Console.ReadLine();
                text = line.Split(" ");
                for (int j = 1; j < int.Parse(text[0]) + 1; j++)
                {
                    AllRoads.Add((i + 1, int.Parse(text[j])));
                }
            }
        }
    }

    private static void LoopFunction()
    {
        for (int i = 0; i < Config.PersonsNumber; i++)
        {
            Execution.Answer(Config.AllRoads, Config.RuletResult[i], Config.Start);
        }
    }
    internal class Execution
    {
        internal static void Answer(List<(int from, int to)> remRoads, int ruletRem, int current)
        {
            if (FindPath(remRoads, ruletRem, current))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        private static bool FindPath(List<(int from, int to)> remRoads, int ruletRem, int current)
        {
            if (ruletRem == 1)
            {
                return remRoads.Any(lastPath =>
                    lastPath.from == current && lastPath.to == Config.Goal);

            }
            foreach (var remRoad in remRoads)
            {
                if (remRoad.from == current)
                {
                    var copyRoads = new List<(int, int)>(remRoads);
                    int first = remRoad.from;
                    int end = remRoad.to;
                    copyRoads.Remove(remRoad);
                    copyRoads.Remove((end, first));

                    if (copyRoads.Count == 0 && ruletRem > 0)
                    {
                        continue;
                    }

                    if (FindPath(copyRoads, ruletRem - 1, end))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
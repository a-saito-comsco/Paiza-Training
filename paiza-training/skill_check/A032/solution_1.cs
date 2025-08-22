using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        GetInputs();
        List<(int, int)> Copy = new List<(int, int)>();
        //for (int i = 0; i < PersonsNumber; i++)
        //{
            Copy = Road;
            var roads = new Roads();
            roads.FindPath(Copy, RuletResult[0], Start);
        //}
    }

    public static int PersonsNumber;
    public static int AccessPointsNumber;
    public static int Start;
    public static int Goal;
    public static int[] RuletResult;

    public static List<(int, int)> Road = new List<(int, int)>();

    public static void GetInputs()
    {
        var line = Console.ReadLine();
        var text = line.Split(" ");
        PersonsNumber = int.Parse(text[0]);
        //Console.WriteLine(PersonsNumber);
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
                Road.Add((i + 1, int.Parse(text[j])));
            }
        }
    }

    public class Roads
    {
        public void FindPath(List<(int x, int y)> Copies, int Rem, int Current)
        {
            if (Rem == 1)
            {
                foreach (var item in Copies)
                {
                    if (item.x == Current && item.y == Goal)
                    {
                        Console.WriteLine("yes");
                        return;
                    }
                }
                Console.WriteLine("no");
                return;
            }
            else
            {
                foreach (var one in Copies)
                {
                    if (one.x == Current)
                    {
                        int x = one.x;
                        int y = one.y;
                        //Console.WriteLine(Copies.Remove(one));
                        //Console.WriteLine(Copies.Remove((y, x)));
                        if (Copies.Count == 0)
                        {
                            Console.WriteLine("no");
                            return;
                        }
                        else
                        {
                            //Console.WriteLine(Rem - 1);
                            //Console.WriteLine(y);
                            /*foreach (var z in Copies)
                            {
                                Console.WriteLine(z);
                            }*/
                            FindPath(Copies, Rem - 1, y);
                        }
                    }
                    else
                    {
                        Console.WriteLine("no");
                        return;
                    }
                }
            }
            return;
        }    
    }
}
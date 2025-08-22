using System;
class Program
{
    static void Main()
    {
        Data.Get();
        /*for (int i = 0; i < Data.Schedule.Length; i++)
        {
            Console.Write(Data.Schedule[i]);
        }*/
        Data.Check();
        Console.WriteLine(Data.Count());
    }


    public static class Data
    {
        public static int TotalDays;
        public static int[] Schedule;
        public static int[] OkDay;
        public static void Get()
        {
            string line = Console.ReadLine();
            TotalDays = int.Parse(line);
            line = Console.ReadLine();
            string[] text = line.Split(" ");
            Schedule = new int[text.Length];
            OkDay = new int[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                {
                    Schedule[i] = int.Parse(text[i]);
                    OkDay[i] = 0;
                }
            }
        }
        public static void Check()
        {
            for (int i = 0; i <= (TotalDays - 7); i++)
            {
                Judge(i);
            }
        }
        public static void Judge(int j)
        {
            int restDay = 0;
            for (int i = j; i < (j + 7); i++)
            {
                if (Schedule[i] == 0)
                {
                    restDay++;
                }
            }
            if (restDay >= 2)
            {
                for (int i = j; i < (j + 7); i++)
                {
                    OkDay[i] = 1;
                }
            }
        }
        public static int Count() // REVIEW: 週休2日の最大勤続日数 → 週休2日の最大連続日数へ
        {
            int cnt = 0;
            int max = 0;
            for (int i = 0; i < TotalDays; i++)
            {
                if (OkDay[i] == 1)
                {
                    cnt += 1;
                    if (max < cnt)
                    {
                        max = cnt;
                    }
                }
                else
                {
                    cnt = 0;
                }
            }
            if (max >= 7)
            {
                return max;
            }
            else
            {
                return 0;
            }
        }
    }
}
using System;//正答率が40%をどうしても越えません
class Program
{
    static void Main()
    {
        ScheduleIandO.GetInputs();
        ScheduleIandO.ScheduleCheck();
        ScheduleIandO.WorkableDayCount(); 
    }

    public static class ScheduleIandO
    {
        public static int TotalDays;
        public static bool[] ScheduleWd;
        public static bool[] ScheduleOk;
        public static void GetInputs()
        {
            //string line = Console.ReadLine();
            //TotalDays = int.Parse(line);
            //line = Console.ReadLine();
            TotalDays = 20;
            string line = "1 1 0 1 1 0 0 1 1 1 1 1 0 1 1 1 1 1 0 1";
            string[] text = line.Split(" ");
            ScheduleWd = new bool[TotalDays];
            ScheduleOk = new bool[TotalDays];
            for (int i = 0; i < TotalDays; i++)
            {
                {
                    ScheduleWd[i] = (0 == int.Parse(text[i]));
                    ScheduleOk[i] = false;
                }
            }
        }
        public static void ScheduleCheck()
        {
            for (int i = 0; i < (TotalDays - 6); i++)
            {
                WorkableDayJudge(i);
            }
        }
        public static void WorkableDayJudge(int j)
        {
            int restDay = 0;
            for (int i = j; i < (j + 7); i++)
            {
                if (ScheduleWd[i] == true)
                {
                    restDay++;
                }
            }
            if (restDay >= 2)
            {
                for (int i = j; i < (j + 7); i++)
                {
                    ScheduleOk[i] = true;
                }
            }
        }
        public static void WorkableDayCount()
        {
            int cnt = 0;
            int max = 0;
            for (int i = 0; i < TotalDays; i++)
            {
                if (ScheduleOk[i] == true)
                {
                    cnt += 1;
                    if (max < cnt)
                    {
                        max = cnt;                    
                    }
                }
                if (ScheduleOk[i] == false)
                {
                    cnt = 0;
                }
            }
            Console.WriteLine(max);
        }
    }
}
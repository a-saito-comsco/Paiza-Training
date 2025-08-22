using System;
class Program
{
    static void Main()
    {
        Data.Get();
        Console.WriteLine(Data.Count());
    }


    public static class Data
    {
        public static int TotalDays;
        public static int[] Schedule;
        public static void Get()
        {
            string line = Console.ReadLine();
            TotalDays = int.Parse(line);
            line = Console.ReadLine();
            string[] text = line.Split(" ");
            Schedule = new int[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                {
                    Schedule[i] = int.Parse(text[i]);
                }
            }
        }
        public static int Count()
        {
            int restDays = 0;
            bool isValid = false;
            int SerialDays = 0;
            int maxSerialDays = 0;    
            for (int i = 0; i < TotalDays - 6; i++)
            {
                for (int j = i; j < i + 7; j++)
                {
                    if (Schedule[j] == 0)
                    {
                        restDays++;
                    }
                }
                if (restDays >= 2 && isValid == false)
                {
                    isValid = true;
                    SerialDays = 7;
                    restDays = 0;
                }
                else if (restDays >= 2)
                {
                    SerialDays += 1;
                    restDays = 0;
                }
                else
                {
                    isValid = false;
                    restDays = 0;
                }
                if (SerialDays > maxSerialDays)
                {
                    maxSerialDays = SerialDays;
                }
            }
            if (maxSerialDays >= 7)
            {
                return maxSerialDays;
            }
            else
            {
                return 0;
            }
        }
    }
}
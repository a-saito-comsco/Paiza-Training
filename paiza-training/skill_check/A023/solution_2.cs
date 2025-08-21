using System;
class Program
{
    static void Main()
    {
        WorkSchedule.ReadInput();
        WorkSchedule.AnalyzeSchedule();
        Console.WriteLine(WorkSchedule.GetLongestValidPeriod());
    }

    public static class WorkSchedule
    {
        private static int totalDays;
        private static bool[] isHoliday;
        private static bool[] isValidWeekPart;

        public static void ReadInput()
        {
            totalDays = int.Parse(Console.ReadLine());
            string[] inputs = Console.ReadLine().Split();
            isHoliday = new bool[totalDays];
            isValidWeekPart = new bool[totalDays];

            for (int i = 0; i < totalDays; i++)
            {
                isHoliday[i] = (0 == int.Parse(inputs[i]));
                isValidWeekPart[i] = false;
            }
        }

        public static void AnalyzeSchedule()
        {
            for (int i = 0; i <= totalDays - 7; i++)
            {
                if (HasEnoughHolidays(i))
                {
                    MarkValidPeriod(i);
                }
            }
        }

        private static bool HasEnoughHolidays(int startIndex)
        {
            int holidayCount = 0;
            for (int i = startIndex; i < startIndex + 7; i++)
            {
                if (isHoliday[i]) holidayCount++;
            }
            return holidayCount >= 2;
        }

        private static void MarkValidPeriod(int startIndex)
        {
            for (int i = startIndex; i < startIndex + 7; i++)
            {
                isValidWeekPart[i] = true;
            }
        }

        public static int GetLongestValidPeriod()
        {
            int currentLength = 0;
            int maxLength = 0;

            for (int i = 0; i < totalDays; i++)
            {
                if (isValidWeekPart[i])
                {
                    currentLength++;
                    if (currentLength >= 7 && currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                }
                else
                {
                    currentLength = 0;
                }
            }

            return maxLength;
        }
    }
}
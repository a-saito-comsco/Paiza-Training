using System;
using System.Linq;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string[] split = line.Split(" ");
        int setACount = int.Parse(split[0]);
        int setBCount = int.Parse(split[1]);
        
        // 必要な分だけ配列を作成
        int maxNeeded = Math.Max(setACount, setBCount);
        Datum[] add = new Datum[maxNeeded];
        Datum[] sub = new Datum[maxNeeded];
        
        var random = new Random();
        
        // 足し算の式を生成
        for (int i = 0; i < setACount; i++) {
            int first, second;
            do {
                first = random.Next(0, 100);
                second = random.Next(0, 100);
            } while (first + second >= 100);
            
            add[i] = new Datum();
            add[i].expression = $"{first} + {second} =";
            add[i].firstNumber = first;
            add[i].secondNumber = second;
            add[i].isUsed = false;
        }

        // 引き算の式を生成
        for (int i = 0; i < setBCount; i++) {
            int first, second;
            do {
                first = random.Next(0, 100);
                second = random.Next(0, 100);
            } while (first < second);
            
            sub[i] = new Datum();
            sub[i].expression = $"{first} - {second} =";
            sub[i].firstNumber = first;
            sub[i].secondNumber = second;
            sub[i].isUsed = false;
        }

        // 結果を出力
        for (int i = 0; i < setACount; i++) {
            Console.WriteLine(add[i].expression);
        }
        
        for (int i = 0; i < setBCount; i++) {
            Console.WriteLine(sub[i].expression);
        }
    }

    public class Datum {
        public string expression;
        public int firstNumber;
        public int secondNumber;
        public bool isUsed;
    }
}
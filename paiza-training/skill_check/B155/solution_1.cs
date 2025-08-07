using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        var split = line.Split(' ');
        int h = int.Parse(split[0]);
        int w = int.Parse(split[1]);
        int n = int.Parse(split[2]);
        string[] block = new string[h * n];
        for (int i = 0; i < h*n; i++) {
            block[i] = Console.ReadLine();
            Console.WriteLine(block[i]);
        }
        line = Console.ReadLine();
        split = line.Split(' ');
        int rows = int.Parse(split[0]);
        int cols = int.Parse(split[1]);
        int[] type = new int[cols];
        for (int i = 0; i < rows; i++) {
            line = Console.ReadLine();
            split = line.Split(' ');
            for (int j = 0; j < cols; j++) {
                type[j] = int.Parse(split[j]);
                Console.Write(type[j]);
            }
            Console.WriteLine("");
        }
    }
}
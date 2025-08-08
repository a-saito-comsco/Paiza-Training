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
        Block[,] block = new Block[n, h];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < h; j++)
            {
                block[i, j] = new Block(Console.ReadLine(), i + 1, j);
            }
        }
        line = Console.ReadLine();
        split = line.Split(' ');
        int rows = int.Parse(split[0]);
        int cols = int.Parse(split[1]);
        int[,] type = new int[rows, cols];
        for (int i = 0; i < rows; i++) {
            line = Console.ReadLine();
            split = line.Split(' ');
            for (int k = 0; k < h; k++)
            {
                for (int j = 0; j < cols; j++)
                {
                    type[i, j] = int.Parse(split[j]);
                    Console.Write(block[type[i, j] - 1, k].characters);
                }
                Console.WriteLine("");
            }
        }
    }
    internal class Block
    {
        public string characters;
        public int kind;
        public int rowNum;
        internal Block(string characters, int kind, int rowNum)
        {
            this.characters = characters;
            this.kind = kind;
            this.rowNum = rowNum;
        }
    }
}
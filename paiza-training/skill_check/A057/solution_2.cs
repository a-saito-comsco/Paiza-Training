using System;
class Program
{
    static void Main()
    {
        var bd = new GameBoard();
        bd.GetInfo();
        Console.Write(bd.Board[0][0]);
    }

    public class GameBoard
    {
        public int Length;
        public int[][] Board;
        public void GetInfo()
        {
            var line = Console.ReadLine();
            this.Length = int.Parse(line);
            this.Board = new int[this.Length][];
            for (int i = 0; i < this.Length; i++)
            {
                line = Console.ReadLine();
                this.Board[i] = new int[this.Length];
                for (int j = 0; j < this.Length; j++)
                {
                    this.Board[i][j] = int.Parse(line[j].ToString());
                }
            }
        }
    }
}
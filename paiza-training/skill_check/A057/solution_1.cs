using System;
class Program
{
    static void Main()
    {
        var bd = new GameBoard();
        bd.Board[0][0] = 1;
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
            for (int i = 0; i < this.Length; i++)
            {
                line = Console.ReadLine();
                for (int j = 0; j < this.Length; j++)
                {
                   // this.Board[i][j] = int.Parse(line[j].ToString());
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    delegate int Process(int x, int y);

    static void Main()
    {
        var bd = new GameBoard();
        bd.GetInfo();
        //bd.Show();
        bd.PrintMaxMatch();
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

        public void Show()
        {
            Console.WriteLine(this.Length);
            for (int i = 0; i < this.Length; i++)
            {
                for (int j = 0; j < this.Length; j++)
                {
                    Console.Write(this.Board[i][j]);
                }
                Console.WriteLine("");
            }
        }
        public void PrintMaxMatch()
        {
            var dgV = new Process(SearchVerticalSequence);
            var dgH = new Process(SearchHorizontalSequence);
            var dgD = new Process(SearchDiagonalSequence);
            var Values = new List<int>();
            for (int i = 0; i < this.Length; i++)
            {
                Values.Add(dgV(0, i));
                Values.Add(dgH(i, 0));
                Values.Add(dgD(0, i));
                Values.Add(dgD(i, 0));
                Values.Add(dgD(i, this.Length - 1));
            }
            Console.WriteLine(Values.Max());
        }
        public int SearchVerticalSequence(int x, int y)
        {
            int cnt = 1;
            int max = 1;
            for (int l = -1; l < 2; l += 2)
            {
                for (int i = 0; i < this.Length - 1; i++)
                {
                    if ((this.Board[x + i][y] + l) == this.Board[x + i + 1][y])
                    {
                        cnt += 1;
                        if (max < cnt)
                        {
                            max = cnt;
                        }
                    }
                    else
                    {
                        cnt = 1;
                    }
                }
            }
            return max;
        }
        public int SearchHorizontalSequence(int x, int y)
        {
            int cnt = 1;
            int max = 1;
            for (int l = -1; l < 2; l += 2)
            {
                for (int j = 0; j < this.Length - 1; j++)
                {
                    if ((this.Board[x][y + j] + l) == this.Board[x][y + j + 1])
                    {
                        cnt += 1;
                        if (max < cnt)
                        {
                            max = cnt;
                        }
                    }
                    else
                    {
                        cnt = 1;
                    }
                }
            }
            return max;
        }
        public int SearchDiagonalSequence(int x, int y)
        {
            int cnt = 1;
            int max = 1;
            int m;
            int n;
            for (int l = -1; l < 2; l += 2)
            {
                cnt = 1;
                for (int k = -1; k < 2; k += 2)
                {
                    m = 0;
                    n = 0;
                    while (((x + n + 1) < this.Length) && ((y + m + k) < this.Length) && (x + n + 1) >= 0 && (y + m + k) >= 0)
                    {
                        if (this.Board[x + n + 1][y + m + k] == (this.Board[x + n][y + m] + l))
                        {
                            cnt += 1;
                            if (max < cnt)
                            {
                                max = cnt;
                            }
                        }
                        else
                        {
                            cnt = 1;
                        }
                        m += k;
                        n += 1;
                    }
                }
            }   
            return max;
        }   
    }
}
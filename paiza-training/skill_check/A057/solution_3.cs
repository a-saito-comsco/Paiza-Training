using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    delegate int Process(int x, int y);
    delegate (int x, int y) Direction(int step, int x, int y);

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

        // 共通のシーケンス検索ロジック
        private int SearchSequence(int x, int y, Direction direction, int maxSteps)
        {
            int cnt = 1;
            int max = 1;

            for (int l = -1; l < 2; l += 2)
            {
                cnt = 1;
                for (int step = 0; step < maxSteps; step++)
                {
                    var (nextX, nextY) = direction(step + 1, x, y);

                    // 境界チェック
                    if (nextX < 0 || nextX >= this.Length || nextY < 0 || nextY >= this.Length)
                        break;

                    var (currentX, currentY) = direction(step, x, y);
                    if (this.Board[nextX][nextY] == (this.Board[currentX][currentY] + l))
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

        // 垂直方向のデリゲート
        private (int x, int y) VerticalDirection(int step, int x, int y)
        {
            return (x + step, y);
        }

        // 水平方向のデリゲート
        private (int x, int y) HorizontalDirection(int step, int x, int y)
        {
            return (x, y + step);
        }

        // 対角線方向のデリゲート
        private (int x, int y) DiagonalDirection(int step, int x, int y)
        {
            return (x + step, y + step);
        }

        public int SearchVerticalSequence(int x, int y)
        {
            return SearchSequence(x, y, VerticalDirection, this.Length - 1);
        }

        public int SearchHorizontalSequence(int x, int y)
        {
            return SearchSequence(x, y, HorizontalDirection, this.Length - 1);
        }

        public int SearchDiagonalSequence(int x, int y)
        {
            return SearchSequence(x, y, DiagonalDirection, this.Length - 1);
        }
    }
}
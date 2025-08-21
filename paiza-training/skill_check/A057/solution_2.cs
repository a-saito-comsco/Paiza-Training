using System;
class Program
{
    delegate int Process(int number);

    internal class DelegateClass
    {
        static void Main()
        {
            var bd = new GameBoard();
            bd.GetInfo();
            bd.Show();
            Console.WriteLine(bd.SearchDiagonalSequence(0));
        }
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
        
        public int SearchVerticalSequence(int j)
        {
            int cnt = 1;
            int max = 1;
            for (l = -1; l < 2; l += 2)
            {
                for (int i = 0; i < this.Length - 1; i++)
                {
                    if ((this.Board[i][j] + l) == this.Board[i + 1][j])
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
        public int SearchHorizontalSequence(int i)
        {
            int cnt = 1;
            int max = 1;
            for (l = -1; l < 2; l += 2)
            {
                for (int j = 0; j < this.Length - 1; j++)
                {
                    if ((this.Board[i][j] + l) == this.Board[i][j + 1])
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
        public int SearchDiagonalSequence(int i)
        {
            int cnt = 1;
            int max = 1;
            for (int l = -1; l < 2; l += 2)
            {
                for (int k = 0; k < this.Length - 1; k++)
                {
                    if ((this.Board[i + k][k] + l) == this.Board[i + k + 1][k + 1])
                    {
                        cnt += 1;
                    }
                    else
                    {
                        cnt = 0;
                    }
                }
                if (max < cnt)
                {
                    max = cnt;
                }
                for (int k = 0; k < this.Length - 1; k++)
                {
                    if ((this.Board[k][i + k] + l) == this.Board[i + 1][i + k + 1])
                    {
                        cnt += 1;
                    }
                    else
                    {
                        cnt = 1;
                    }
                }
                if (max < cnt)
                {
                    max = cnt;
                }
            }
            for (int l = -1; l < 2; l += 2)
            {
                for (int k = 0; k < this.Length - 1; k++)
                {
                    if ((this.Board[i + k][k] + l) == this.Board[i + k - 1][k - 1])
                    {
                        cnt += 1;
                    }
                    else
                    {
                        cnt = 0;
                    }
                }
                if (max < cnt)
                {
                    max = cnt;
                }
                for (int k = 0; k < this.Length - 1; k++)
                {
                    if ((this.Board[k][i + k] + l) == this.Board[i - 1][i + k - 1])
                    {
                        cnt += 1;
                    }
                    else
                    {
                        cnt = 1;
                    }
                }
                if (max < cnt)
                {
                    max = cnt;
                }
            }
             return max;
        }   
    }
}
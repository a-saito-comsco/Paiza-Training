using System;
using System.Linq;

class Program
{
    private const int WIDTH = 5;
    
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        var game = new PuzzleGame(height, WIDTH);
        
        // 初期状態の読み込み
        for (int i = 0; i < height; i++)
        {
            var line = Console.ReadLine();
            for (int j = 0; j < WIDTH; j++)
            {
                game.SetCell(i, j, line[j]);
            }
        }
        
        // ゲーム実行
        while (game.FindAndMarkMatches())
        {
            game.RemoveMarkedCells();
            game.DropBlocks();
        }
        
        game.Display();
    }
}

public class PuzzleGame
{
    private readonly char[,] board;
    private readonly bool[,] marked;
    private readonly int height;
    private readonly int width;
    
    public PuzzleGame(int height, int width)
    {
        this.height = height;
        this.width = width;
        this.board = new char[height, width];
        this.marked = new bool[height, width];
    }
    
    public void SetCell(int row, int col, char value)
    {
        board[row, col] = value;
    }
    
    public bool FindAndMarkMatches()
    {
        bool foundMatch = false;
        
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (board[i, j] != '.' && HasMatch(i, j))
                {
                    MarkMatch(i, j);
                    foundMatch = true;
                }
            }
        }
        
        return foundMatch;
    }
    
    private bool HasMatch(int row, int col)
    {
        char target = board[row, col];
        int matchCount = 1;
        
        // 上下左右の隣接セルをチェック
        var directions = new[] { (0, 1), (0, -1), (1, 0), (-1, 0) };
        
        foreach (var (dr, dc) in directions)
        {
            int newRow = row + dr;
            int newCol = col + dc;
            
            if (IsValidPosition(newRow, newCol) && board[newRow, newCol] == target)
            {
                matchCount++;
            }
        }
        
        return matchCount >= 3;
    }
    
    private void MarkMatch(int row, int col)
    {
        char target = board[row, col];
        marked[row, col] = true;
        
        // 上下左右の隣接セルもマーク
        var directions = new[] { (0, 1), (0, -1), (1, 0), (-1, 0) };
        
        foreach (var (dr, dc) in directions)
        {
            int newRow = row + dr;
            int newCol = col + dc;
            
            if (IsValidPosition(newRow, newCol) && board[newRow, newCol] == target)
            {
                marked[newRow, newCol] = true;
            }
        }
    }
    
    private bool IsValidPosition(int row, int col)
    {
        return row >= 0 && row < height && col >= 0 && col < width;
    }
    
    public void RemoveMarkedCells()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (marked[i, j])
                {
                    board[i, j] = '.';
                    marked[i, j] = false;
                }
            }
        }
    }
    
    public void DropBlocks()
    {
        for (int col = 0; col < width; col++)
        {
            DropColumn(col);
        }
    }
    
    private void DropColumn(int col)
    {
        int writeRow = height - 1;
        
        // 下から上に向かって、空でないセルを下に詰める
        for (int readRow = height - 1; readRow >= 0; readRow--)
        {
            if (board[readRow, col] != '.')
            {
                if (writeRow != readRow)
                {
                    board[writeRow, col] = board[readRow, col];
                    board[readRow, col] = '.';
                }
                writeRow--;
            }
        }
    }
    
    public void Display()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write(board[i, j]);
            }
            Console.WriteLine();
        }
    }
}
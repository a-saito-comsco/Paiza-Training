using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    const int MaxMatchstickSegments = 7;
    
    static void Main()
    {
        MatchstickProcessor.GetInput();
        Matches.MakeTransTable();
        MatchstickProcessor.ProcessMatches();
        OutputResults();
    }

    private static void OutputResults()
    {
        if (MatchstickProcessor.Answers.Count == 0)
        {
            Console.WriteLine("none");
        }
        else
        {
            MatchstickProcessor.Answers.Sort();
            MatchstickProcessor.Answers.ForEach(Console.WriteLine);
        }
    }

    internal static class MatchstickProcessor
    {
        // 入力データ
        public static string InputText;
        public static int[] InputDigits;
        public static int[] CurrentDigits;

        // 結果
        public static List<string> Answers;

        // 変換テーブル
        public static List<(int before, int after)> MinusTable = new List<(int before, int after)>();
        public static List<(int before, int after)> PlusTable = new List<(int before, int after)>();
        public static List<(int before, int after)> BothTable = new List<(int before, int after)>();

        public static void GetInput()
        {
            InputText = Console.ReadLine();
            InputDigits = new int[InputText.Length];
            for (int i = 0; i < InputText.Length; i++)
            {
                InputDigits[i] = int.Parse(InputText[i].ToString());
            }
        }

        public static void ProcessMatches()
        {
            Answers = new List<string>();
            CurrentDigits = new int[InputText.Length];
            Array.Copy(InputDigits, CurrentDigits, InputText.Length);

            for (int i = 0; i < InputText.Length; i++)
            {
                for (int j = 0; j < InputText.Length; j++)
                {
                    if (i == j)
                    {
                        // 同一桁内での変換
                        var sameDigitTransforms = BothTable.FindAll(x => x.before == InputDigits[i]);
                        foreach (var transform in sameDigitTransforms)
                        {
                            CurrentDigits[i] = transform.after;
                            string result = string.Join("", CurrentDigits);
                            Answers.Add(result);
                            CurrentDigits[i] = InputDigits[i]; // 元に戻す
                        }
                    }
                    else
                    {
                        // 異なる桁間での変換
                        var minusTransforms = MinusTable.FindAll(y => y.before == InputDigits[i] && (y.after != 0 || y.before == 8));
                        var plusTransforms = PlusTable.FindAll(z => z.before == InputDigits[j] && z.after != 0);

                        foreach (var minusTransform in minusTransforms)
                        {
                            foreach (var plusTransform in plusTransforms)
                            {
                                CurrentDigits[i] = minusTransform.after;
                                CurrentDigits[j] = plusTransform.after;
                                string answer = string.Join("", CurrentDigits);
                                Answers.Add(answer);

                                // 元に戻す
                                Array.Copy(InputDigits, CurrentDigits, InputText.Length);
                            }
                        }
                    }
                }
            }
        }
    }

    internal static class Matches
    {
        public static Dictionary<int, string> DigitPatterns = new Dictionary<int, string>
        {
            {0, "1110111"},
            {1, "0010010"},
            {2, "1011101"},
            {3, "1011011"},
            {4, "0111010"},
            {5, "1101011"},
            {6, "1101111"},
            {7, "1010010"},
            {8, "1111111"},
            {9, "1111011"},
        };

        // DigitPatternsから自動生成される逆引き辞書
        public static Dictionary<string, int> ReversePatterns = DigitPatterns.ToDictionary(x => x.Value, x => x.Key);

        public static void MakeTransTable()
        {
            for (int i = 0; i < DigitPatterns.Count; i++)
            {
                DigitPatterns.TryGetValue(i, out var bpattern);
                var originalDigit = CorrectNumber(bpattern);
                
                // マッチ棒削除変換
                BuildMinusTransforms(bpattern, originalDigit);
                
                // マッチ棒追加変換
                BuildPlusTransforms(bpattern, originalDigit);
                
                // マッチ棒移動変換
                BuildMoveTransforms(bpattern, originalDigit);
            }            
        }

        private static void BuildMinusTransforms(string bpattern, int originalDigit)
        {
            BuildTransforms(bpattern, originalDigit, 
                (pattern, j) => pattern[j] == '1',  // 条件：マッチ棒が存在
                (pattern, j) => pattern[j] = '0',   // 操作：マッチ棒を削除
                (pattern, j) => pattern[j] = '1',   // 復元：マッチ棒を戻す
                MatchstickProcessor.MinusTable);
        }

        private static void BuildPlusTransforms(string bpattern, int originalDigit)
        {
            BuildTransforms(bpattern, originalDigit, 
                (pattern, j) => pattern[j] == '0',  // 条件：マッチ棒が存在しない
                (pattern, j) => pattern[j] = '1',   // 操作：マッチ棒を追加
                (pattern, j) => pattern[j] = '0',   // 復元：マッチ棒を削除
                MatchstickProcessor.PlusTable);
        }

        // 共通の変換処理メソッド
        private static void BuildTransforms(
            string bpattern, 
            int originalDigit,
            Func<char[], int, bool> condition,      // 条件判定
            Action<char[], int> operation,          // 操作実行
            Action<char[], int> restore,            // 状態復元
            List<(int before, int after)> targetTable)
        {
            var pattern = bpattern.ToCharArray();
            for (int j = 0; j < MaxMatchstickSegments; j++)
            {
                if (condition(pattern, j))
                {
                    operation(pattern, j);
                    var newPattern = new string(pattern);
                    var newDigit = CorrectNumber(newPattern);
                    if (newDigit != -1)
                    {
                        targetTable.Add((originalDigit, newDigit));
                    }
                    restore(pattern, j); // 元に戻す
                }
            }
        }

        private static void BuildMoveTransforms(string bpattern, int originalDigit)
        {
            var pattern = bpattern.ToCharArray();
            for (int j = 0; j < MaxMatchstickSegments; j++)
            {
                if (pattern[j] == '1')
                {
                    pattern[j] = '0';
                    for (int k = 0; k < MaxMatchstickSegments; k++)
                    {
                        if (k != j && pattern[k] == '0')
                        {
                            pattern[k] = '1';
                            var newPattern = new string(pattern);
                            var newDigit = CorrectNumber(newPattern);
                            if (newDigit != -1)
                            {
                                MatchstickProcessor.BothTable.Add((originalDigit, newDigit));
                            }
                            pattern[k] = '0'; // 元に戻す
                        }
                    }
                    pattern[j] = '1'; // 元に戻す
                }
            }
        }

        public static int CorrectNumber(string Match)
        {
            if (ReversePatterns.ContainsKey(Match))
            {
                ReversePatterns.TryGetValue(Match, out var number);
                return number;
            }
            else
            {
                return -1;
            }
        }
    }
}
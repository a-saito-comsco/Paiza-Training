    using System;
    using System.Linq;
    class Program
    {
        public const int W = 5;
        static void Main()
        {
            var line = Console.ReadLine();
            int height = int.Parse(line);
            Datum[, ] data = new Datum[height, W]; 
            for (int i = 0; i < height; i++) {
                line = Console.ReadLine();
                for(int j = 0; j < W; j++) {
                    data[i, j] = new Datum(i, j, line[j], 0);
                }
            }
            while(SearchBlock(data) != 0) {
                DelData(data);
                DropBlock(data);
            }
            ShowData(data);
        }

        static int SearchBlock(Datum[, ] data) {
            int response = 0;
            for (int i = 0; i < data.GetLength(0); i++) {
                for (int j = 0; j < data.GetLength(1); j++) {
                    if (data[i, j].val != '.') {
                        if (i == 0) {
                            if (j == 0) {
                                if (data[i, j].val == data[i, j + 1].val && data[i, j].val == data[i + 1, j].val) {
                                    data[i, j].del = 1;
                                    data[i, j + 1].del = 1;
                                    data[i + 1, j].del = 1;
                                    response = 1;   
                                }
                            } else if (j == (W - 1)) {
                                if (data[i, j].val == data[i, j - 1].val && data[i, j].val == data[i + 1, j].val) {
                                    data[i, j].del = 1;
                                    data[i, j - 1].del = 1;
                                    data[i + 1, j].del = 1;
                                    response = 1;   
                                }
                            } else {
                                if (data[i, j].val == data[i, j - 1].val && data[i, j].val == data[i, j + 1].val && data[i, j].val == data[i + 1, j].val) {
                                    data[i, j].del = 1;
                                    data[i, j - 1].del = 1;
                                    data[i, j + 1].del = 1;
                                    data[i + 1, j].del = 1;
                                    response = 1;
                                }
                            }
                        } else if (i == (data.GetLength(0) - 1)) {
                            if (j == 0) {
                                if (data[i, j].val == data[i, j + 1].val && data[i, j].val == data[i - 1, j].val) {
                                    data[i, j].del = 1;
                                    data[i, j + 1].del = 1;
                                    data[i - 1, j].del = 1;
                                    response = 1;   
                                }
                            } else if (j == (W - 1)) {
                                if (data[i, j].val == data[i, j - 1].val && data[i, j].val == data[i - 1, j].val) {
                                    data[i, j].del = 1;
                                    data[i, j - 1].del = 1;
                                    data[i - 1, j].del = 1;
                                    response = 1;   
                                }
                            } else {
                                if (data[i, j].val == data[i, j - 1].val && data[i, j].val == data[i, j + 1].val && data[i, j].val == data[i - 1, j].val) {
                                    data[i, j].del = 1;
                                    data[i, j - 1].del = 1;
                                    data[i, j + 1].del = 1;
                                    data[i - 1, j].del = 1;
                                    response = 1;
                                }
                            }
                        } else {
                            if (j == 0) {
                                if (data[i, j].val == data[i, j + 1].val && data[i, j].val == data[i - 1, j].val && data[i, j].val == data[i + 1, j].val) {
                                    data[i, j].del = 1;
                                    data[i, j + 1].del = 1;
                                    data[i - 1, j].del = 1;
                                    data[i + 1, j].del = 1;
                                    response = 1;
                                }
                            } else if (j == (W - 1)) {
                                if (data[i, j].val == data[i, j - 1].val && data[i, j].val == data[i - 1, j].val && data[i, j].val == data[i + 1, j].val) {
                                    data[i, j].del = 1;
                                    data[i, j - 1].del = 1;
                                    data[i - 1, j].del = 1;
                                    data[i + 1, j].del = 1;
                                    response = 1;
                                }
                            } else {
                                if (data[i, j].val == data[i, j - 1].val && data[i, j].val == data[i, j + 1].val && data[i, j].val == data[i - 1, j].val && data[i, j].val == data[i + 1, j].val) {
                                    data[i, j].del = 1;
                                    data[i, j - 1].del = 1;
                                    data[i, j + 1].del = 1;
                                    data[i - 1, j].del = 1;
                                    data[i + 1, j].del = 1;
                                    response = 1;
                                }
                            }
                        }
                    }
                }
            }
            return response;
        }

        static void DropBlock(Datum[, ] data) {
            for (int j = 0; j < data.GetLength(1); j++) {
                for (int i = data.GetLength(0) - 1; i >= 0; i--) {  
                    if (data[i, j].val == '.' && i > 0) {
                        for (int k = i - 1; k >= 0; k--) {
                            data[i, j].val = data[k, j].val;
                            data[k, j].val = '.';
                            if (data[i, j].val != '.') {
                                data[i, j].del = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void ShowData(Datum[, ] data) {
            for (int i = 0; i < data.GetLength(0); i++) {
                for (int j = 0; j < data.GetLength(1); j++) {
                    Console.Write(data[i, j].val);
                }
                Console.WriteLine();
            }
        }

        static void DelData(Datum[, ] data) {
            for (int i = 0; i < data.GetLength(0); i++) {
                for (int j = 0; j < data.GetLength(1); j++) {
                    if(data[i, j].del == 1){
                        data[i, j].val = '.';
                        data[i, j].del = 0;
                    }
                }
            }
        }

        public class Datum {
            public int row;
            public int col;
            public char val;
            public int del;
            public Datum(int r, int c, char v, int d)
            {
                row = r;
                col = c;
                val = v;
                del = d;
            }
        }
    }
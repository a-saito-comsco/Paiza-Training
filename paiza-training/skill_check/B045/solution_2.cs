    using System;
    using Linq;
    class Program
    {
        static void Main()
        {
            var line = Console.ReadLine();
            string[] split = line.Split(" ");
            int setA_amt = int.Parse(split[0]);
            int setB_amt = int.Parse(split[1]);
            string[] setA = new string[setA_amt];
            string[] setB = new string[setB_amt];
            
            int i = 0;
            int cnt = 0;
            var random = new Random();
            
            //a1 + a2 =
            while (StCount(setA) < setA_amt){
                int a1 = 50;
                int a2 = 50;
                while(a1 + a2 >= 100){
                    a1 = random.Next(0,100);
                    a2 = random.Next(0,100);
                }
                for (i = 0; i < StCount(setA); i++) {
                    if ((a1.ToString() + " + " + a2.ToString() + " =") == setA[i]) {
                        break;
                    }
                }
                if (i == StCount(setA)){
                    setA[i] = (a1.ToString() + " + " + a2.ToString() + " =");
                }
            }
            for (i = 0; i < setA_amt ; i++) {
                Console.WriteLine(setA[i]);
            }

            //b1 - b2 =
            while (StCount(setB) < setB_amt) {
                int b1 = 0;
                int b2 = 1;
                while (b1 < b2){
                    b1 = random.Next(0,100);
                    b2 = random.Next(0,100);
                }
                for (i=0; i < StCount(setB); i++){
                    if ((b1.ToString() + " - " + b2.ToString() + " =") == setB[i]) {
                        break;
                    }
                }
                if (i == StCount(setB)) {
                    setB[i] = (b1.ToString() + " - " + b2.ToString() + " =");
                }
            }
            for (i = 0; i < setB_amt ; i++) {
                Console.WriteLine(setB[i]);
            }
            Console.WriteLine("");
        }
        
        static int StCount(string[] st) {
            return (st != null) => cnt;
        }
    }
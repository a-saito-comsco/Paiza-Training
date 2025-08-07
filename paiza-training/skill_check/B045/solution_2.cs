using System;
using System.Linq;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string[] split = line.Split(" ");
        int setA_amt = int.Parse(split[0]);
        int setB_amt = int.Parse(split[1]);
        Datum[] add = new Datum[10000];
        Datum[] sub = new Datum[10000];
        
        int i = 0;
        int j = 0;
        int k = 0;
        for(i = 0; i < 100; i++) {
            for (j = 0; j < 100; j++) {
                add[k] = new Datum();
                add[k].st = i.ToString() + " + " + j.ToString() + " =";
                add[k].pre_cnt = i;
                add[k].post_cnt = j;
                add[k].done = 0;
                sub[k] = new Datum();
                sub[k].st = i.ToString() + " - " + j.ToString() + " =";
                sub[k].pre_cnt = i;
                sub[k].post_cnt = j;
                sub[k].done = 0;
                k = k + 1;
            }
        }   
        var random = new Random();
        
        //a1 + a2 =
        int r = random.Next(0, 10000);
        for (i = 0; i < setA_amt ; i++) {                  
            while (add[r].done == 1 || (add[r].pre_cnt + add[r].post_cnt >= 100)) {
                r = random.Next(0, 10000);
            }
            add[r].done = 1;
            Console.WriteLine(add[r].st);
        }

        //b1 - b2 =
        r = random.Next(0, 10000);
        for (i = 0; i < setB_amt ; i++) {                  
            while (sub[r].done == 1 || (sub[r].pre_cnt < sub[r].post_cnt)) {
                r = random.Next(0, 10000);
            }
            sub[r].done = 1;
            Console.WriteLine(sub[r].st);
        }
    }

    public class Datum {
        public string st;
        public int pre_cnt;
        public int post_cnt;
        public int done;
    }   
    
    /*static int StCount(string[] st) {
        //return st.Count(s => s != null);
        int i=0;
        int cnt=0;
        while(i < st.Length){
            if(st[i]!=null){
                cnt += 1;
            }
            i+=1;
        }
        return cnt;
    }*/
}
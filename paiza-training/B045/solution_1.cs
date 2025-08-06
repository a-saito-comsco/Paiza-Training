using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string[] split = line.Split(" ");
        int M=int.Parse(split[0]);
        int N=int.Parse(split[1]);
        string[] setA= new string[M];
        string[] setB= new string[N];
        
        int i=0;
        int cnt=0;
        var random = new Random();
        //Console.WriteLine(stcount(set));
        while(stcount(setA)<M){
            var a1=random.Next(0,100);
            var a2=random.Next(0,100);
            for(i=0; i < stcount(setA); i++){
                if((a1.ToString() + " + " + a2.ToString() + " =")==setA[i]){
                    break;
                }
            }
            if(i==stcount(setA)){
                setA[i]=(a1.ToString() + " + " + a2.ToString() + " =");
            }
        }
        for(i=0;i<M;i++){
            Console.WriteLine(setA[i]);
        }
        while(stcount(setB)<N){
            var b1=random.Next(0,100);
            var b2=random.Next(0,100);
            for(i=0; i < stcount(setB); i++){
                if((b1.ToString() + " - " + b2.ToString() + " =")==setB[i]){
                    break;
                }
            }
            if(i==stcount(setB)){
                setB[i]=(b1.ToString() + " - " + b2.ToString() + " =");
            }
        }
        for(i=0;i<N;i++){
            Console.WriteLine(setB[i]);
        }
    }
    
    static int stcount(string[] st){
        int i=0;
        int cnt=0;
        while(i<st.Length){
            if(st[i]!=null){
                cnt=cnt+1;
            }
            i+=1;
        }
        return cnt;
    }
}
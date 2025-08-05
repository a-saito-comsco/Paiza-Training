using System;
class Program
{
    static void Main()
    {
        // 自分の得意な言語で
        // Let's チャレンジ！！
        var line1 = int.Parse(Console.ReadLine());
        int[] LiveA = new int[31];
        int[] LiveB = new int[31];
        int i=0;
        for(i=0;i<line1;i++){
            LiveA[i] = int.Parse(Console.ReadLine());
        }
        var line2 = int.Parse(Console.ReadLine());
        for(i=0;i<line2;i++){
            LiveB[i] = int.Parse(Console.ReadLine());
        }
        int sw=1;
        i=1;
        int j=0;
        int k=0;
        string bl="A";
        while(i<=31){
            while(i>LiveA[j] && LiveA[j]!=0){
                j++;
            }
            while(i>LiveB[k] && LiveB[k]!=0){
                k++;
            }
            if(i==LiveA[j] && i==LiveB[k]){
                if(sw==1){
                    bl="A";
                    sw=0;
                }
                else{
                    bl="B";
                    sw=1;
                }
            }
            else if(i==LiveA[j]){
                bl="A";
            }
            else if(i==LiveB[k]){
                bl="B";
            }
            else{
                bl="x";
            }
            Console.WriteLine(bl);
            i+=1;
        }
    }
}
// вариант 9 №30
using _2;


Time t = new Time(23, 59, 30);
Console.WriteLine(t.ToString());             


Time t1 = new Time("22:10:07");
Console.WriteLine(t1.ToString());             


t.AddSecond(35);                              
Console.WriteLine(t.ToString());              
       

int dif = t.CompareTime(23, 59, 20);   
Console.WriteLine(dif);

int dif2 = t.CompareTime(1, 30, 25);           
Console.WriteLine(dif);                   

Console.WriteLine($"Минуты: {t1.GetMinut()}");


Console.ReadKey();
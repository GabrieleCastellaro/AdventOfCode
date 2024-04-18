using System.IO;
public static class Day1a
{
    /*enum Numeri
    {
        one=1, two=2, three=3, four=4, five=5, six=6, seven=7, eight=8, nine=9
    }*/
    public static int conversione(char c1){
        return (int)c1-(int)'0';

    }
    public static int solInterna(string[] s)
    {
        int i, num = 0, somma = 0, cnt = 1;
        char c;
        bool found = false;
        foreach (string riga in s)
        {
            for (i = 0; i < riga.Length && found == false; i++)
            {
                c = riga[i];
                if (Char.IsDigit(c))
                {
                    num = 10 * conversione(c);
                    found = true;
                }
            }
            found = false;
            for (i = riga.Length - 1; i >= 0 && found == false; i--)
            {
                c = riga[i];
                if (Char.IsDigit(c))
                {
                    num += conversione(c);
                    found = true;
                    //Console.WriteLine($"riga {cnt} ho trovato {num}");
                    cnt++;
                    somma += num;
                }

            }
            num = 0;
            found = false;
        }
        return somma;

    }
    

    public static void sol()
    {
        string[] s = File.ReadAllLines("input.txt");
        Console.WriteLine(s.Length);
        //string[] numeri = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        int somma=solInterna(s);
        Console.WriteLine(somma);
        //Console.ReadLine();   
    }
} 

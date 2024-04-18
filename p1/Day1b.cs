using System.IO;
public static class Day1b
{
    /*enum Numeri
    {
        one=1, two=2, three=3, four=4, five=5, six=6, seven=7, eight=8, nine=9
    }*/
    public static int conversione(char c1)
    {
        return (int)c1 - (int)'0';

    }

    public static int check(string s, int pos)
    {
        int i,j=1,cnt=0;
        string[] numeri = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        
        foreach(string numero in numeri)
        {
            for (i = 0; i < numero.Length && pos<s.Length; i++,pos++)
            {
                if (numero[i] == s[pos])
                {
                    cnt++;
                }
            }
            if (cnt == numero.Length)
            {
                return j;
            }
            j++;
            cnt = 0;
            pos -= i; //riaggiorno pos
        }
        
        return 0;
    }

    public static void sol1b()
    {
        string[] s = File.ReadAllLines("input.txt");
        Console.WriteLine(s.Length);
        
        int i, num = 0, somma = 0, cnt = 1, cifra;
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
                else
                {
                    cifra = check(riga.Substring(i), i);
                    if (cifra != 0)
                    {
                        num = 10 * cifra;
                        found = true;
                    }
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
                    Console.WriteLine($"riga {cnt} ho trovato {num}");
                    cnt++;
                    somma += num;
                }
                else
                {
                    cifra = check(riga, i);
                    if (cifra != 0)
                    {
                        num += cifra;
                        found = true;
                        Console.WriteLine($"riga {cnt} ho trovato {num}");
                        cnt++;
                        somma += num;
                    }
                }

            }
            num = 0;
            found = false;
        }
        Console.WriteLine(somma);
        //Console.ReadLine();   
    }
}

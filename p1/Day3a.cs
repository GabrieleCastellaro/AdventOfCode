using System.Diagnostics.Contracts;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
public static class Day3a
{
    public static void Day3asol()
    {
        string[] s = File.ReadAllLines("inputs/inputTest.txt");
        int somma = Day3aSol(s);
        Console.WriteLine(somma);
    }

    public static int Conversione(char c)
    {
        return (int)c - '0';
    }

    public static bool checkRiga(string s, int pos, int dim)
    {
        for(int i = pos; i < pos + dim; i++)
        {
            //if (Char.IsSymbol(s[i]) == true) return true;
            if (Char.IsDigit(s[i]) == false && s[i] != '.') return true;
        }
        return false;
    }

    public static bool checkColonna(string[] s,int pos, int row)
    {
        if (row > 0)
        {
            string s0 = s[row - 1];
            if (Char.IsDigit(s0[pos]) == false && s0[pos] != '.') return true;
            //if (Char.IsSymbol(s0[pos]) == true) return true;
        }

        string s1 = s[row];
        if (Char.IsDigit(s1[pos]) == false && s1[pos] != '.') return true;
        //if (Char.IsSymbol(s1[pos]) == true) return true;

        if (row < s.Length - 1)
        {
            string s2 = s[row + 1];
            if (Char.IsDigit(s2[pos]) == false && s2[pos] != '.') return true;
            //if (Char.IsSymbol(s2[pos]) == true) return true;
        }
        
        return false;
    }

    public static (int,int) CalcoloNumEDim(string riga, int pos)
    {
        int dim=1,num=0,i,j,potenza=0;
        for (i = pos+1; i < riga.Length; i++)
        {
            if (Char.IsDigit(riga[i]) == true) {  
                dim++;  //calcolo dimensione numero
            }
            else
            {
                //non ho piu cifre, mi ricavo il numero
                for (j = i - 1; j >= pos; j--,potenza++)
                {
                    num += Convert.ToInt32(Math.Pow(10, potenza) * Conversione(riga[j]));
                }
                return (dim, num);
            }
        }

        return (0, 0); //ritorno dimensione e numero
    }
    public static bool RicercaSimbolo(string[] s, int pos, int dim, int row)
    {
        if(row > 0)
        {
            if (checkRiga(s[row - 1], pos, dim)) return true; //controllo che nella riga sopra ci sia un simbolo
        }
        if (row < s.GetLength(0)-1)
        {
            if (checkRiga(s[row + 1], pos, dim)) return true; //controllo che nella riga sotto ci sia un simbolo
        }
        if (pos > 0)
        {
            if(checkColonna(s,pos-1,row)) return true; //controllo che nella colonna di sx ci sia un simbolo
        }
        if (pos+dim < s[0].Length - 1)
        {
            if(checkColonna(s,pos+dim+1,row)) return true; //controllo che nella colonna di dx ci sia un simbolo
        }
         
        return false;    //ritorno false se non trovo neanche un simbolo attorno al numero
    }


    public static int Day3aSol(string[] s)
    {
        int somma = 0, num, pos, dim, row = 0; ;
        int larghezza = s[0].Length;
        int altezza = s.GetLength(0);
        
        //Console.WriteLine(s.Rank);    //un array di stringhe per lui ha una sola dimensione
        //Console.WriteLine(larghezza);
        //Console.WriteLine(altezza);
        
        //trovo una cifra
        foreach(string riga in s)
        {
            for(pos=0;pos<riga.Length;pos++)
            {
                
                if (Char.IsDigit(riga[pos]) == true) {
                    (dim, num) = CalcoloNumEDim(riga, pos);
                    //Console.WriteLine($"ho trovato il numero {num} di dimensione {dim} nella riga {row} e colonna {pos}");

                    if (RicercaSimbolo(s, pos, dim, row)==true)
                    {
                        Console.WriteLine($"{num} è un numero con un simbolo vicino");
                        somma += num;
                    }
                    pos += dim;
                }
            }
            row++;
        }
                   
        return somma; //devo ritornare la somma dei numeri
    }

   
    






   

}

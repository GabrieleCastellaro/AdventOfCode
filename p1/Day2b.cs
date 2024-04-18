using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
public static class Day2b
{
    public static void Day2bSol()
    {
        string[] s = File.ReadAllLines("inputs/input2.txt");
        int somma = Day2bSol(s);
        Console.WriteLine(somma);
    }
    public static int Day2bSol(string[] s)
    {
        var somma = s.Select(GetPowerSet)
                   .Sum();
                   
        return somma; //devo ritornare la somma degli ID Games
    }

    public static int GetPowerSet(string s)
    {
        int[] minCubes = [0, 0, 0];
        string[] mani = s.Split(':', StringSplitOptions.TrimEntries)[1]     //divido ID da mani
         .Split(';', StringSplitOptions.TrimEntries);        //divido le varie mani
         foreach (string mano in mani) 
         {
             string[] pick = mano.Split(',', StringSplitOptions.TrimEntries);
             foreach( string set in pick)
             {
                 var Cubes=set.Split(" ");
                 var num = Convert.ToInt32(Cubes[0]);
                 var colour = Cubes[1];

                 /*if (colour.Equals("red") == true && num > minCubes[0]) minCubes[0] = num;
                 if (colour.Equals("green") == true && num > minCubes[1]) minCubes[1] = num;
                 if (colour.Equals("blue") == true && num > minCubes[2]) minCubes[2] = num;
                 */
                var index = colour switch
                {
                    "green" => 1,
                    "red" => 0,
                    "blue" => 2,

                    _ => throw new NotImplementedException()
                };

                if (minCubes[index] < num) minCubes[index] = num;

                 /*colour switch
                 {
                     
                     _ => throw new NotImplementedException()
                 }*/

              }

         }


        return minCubes[0]* minCubes[1]* minCubes[2]; // ritorno il power del game
    }
    






    /*
    public static void query(int[] numbers)
    {
        Console.Write(numbers.Where(numEven).Select(num => num));
    }

    public static bool numEven(int num)
    {
        if ((num % 2) == 0) return true;

        return false;
    }
    */

    /*
    public static void query(int[] scores){
        Console.WriteLine(scores.Where((int score) => score > 80).OrderByDescending(score => score).Select(score => score));
    }
    */  
     
      
   

}

using System.IO;
using System.Linq;
public static class Day2aRetry
{
    public static void Day2aRetrySol()
    {
        string[] s = File.ReadAllLines("inputs/input2.txt");
        int somma = Day2aRetrySol(s);
        Console.WriteLine(somma);
    }
    public static int Day2aRetrySol(string[] s)
    {
        var somma = s.Where(IsAGameValid)
                   .Select(GetIDsGames)
                   .Sum();
                   
        return somma; //devo ritornare la somma degli ID Games
    }

    public static bool IsAGameValid(string game)
    {
        //devo ritornare se il game è valido
        return game.Split(':', StringSplitOptions.TrimEntries)[1] //divido mani da ID del game
                   .Split(';', StringSplitOptions.TrimEntries) //divido le varie mani tra loro
                   .All((string mano) =>                     //lambda in cui controllo le varie mani 
                    {
                        return mano.Split(',', StringSplitOptions.TrimEntries) //divido ogni mano secondo i vari colori
                                   .All((string pick) =>
                                    {
                                        //ho numero colore, devo memorizzarli
                                        var Cubes = pick.Split(" "); // array con numero e colore
                                        var num = Convert.ToInt32(Cubes[0]);
                                        var colour = Cubes[1];

                                        return colour switch
                                        {
                                            "green" => num <= 13,
                                            "red" => num <=12,
                                            "blue" => num <=14,

                                            _ => throw new NotImplementedException()
                                        };
                                    });
                    });

    }

    public static int GetIDsGames(string game)
    {
        //devo ritornare l'ID del game
        return Convert.ToInt32(game.Split(":", StringSplitOptions.TrimEntries)[0].Split(" ")[1]); 
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

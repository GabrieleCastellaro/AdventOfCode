using System.IO;
using System.Linq;
public static class Day2a
{
    public static int sol2a(string[] s)
    {
       return s.Where(isGameValid)
               .Select(getIdGame)
               .Sum();
        
    }

    public static bool isGameValid(string s)
    {
        return  s.Split(":", StringSplitOptions.TrimEntries)[1]
                 .Split(";", StringSplitOptions.TrimEntries)
                 .All( (string mano) =>
        {
            var isManoValida = mano.Split(',', StringSplitOptions.TrimEntries).All(pick =>
            {
                var value = pick.Split(' ');
                var quantita = Convert.ToInt32(value[0]);
                var colore = value[1];

                return colore switch
                {
                    "red" => quantita <= 12,
                    "green" => quantita <= 13,
                    "blue" => quantita <= 14,
                    _ => throw new NotImplementedException(),
                };
            });

            return isManoValida;
        });
        
        
    }

    public static int getIdGame(string s)
    {
        return Convert.ToInt32(s.Split(':')[0].Split(' ')[1]);
    }
    
    public static void day2a()
    {
      
   
    }



}


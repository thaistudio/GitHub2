using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GitHubNew2
{
    public delegate void thaiDel(string message);
    public delegate bool IsSuperstar(ManUnited player);

    public class Program
    {
        static void Main(string[] args)
        {
        
            IsSuperstar isSuperstar = new IsSuperstar(isSuperStar);

            List<ManUnited> squad = GenerateList();

            ManUnited.SuperStar(squad, x => x.Attribute > 84);
            Console.ReadLine();
        }

        public static List<ManUnited> GenerateList()
        {
            List<ManUnited> squad = new List<ManUnited>();

            squad.Add(new ManUnited() { Name = "vanPersie", Number = 20, Attribute = 95 });
            squad.Add(new ManUnited() { Name = "Lingard", Number = 14, Attribute = 82 });
            squad.Add(new ManUnited() { Name = "Carrick", Number = 16, Attribute = 92 });
            squad.Add(new ManUnited() { Name = "Herrera", Number = 21, Attribute = 85 });
            //squad.Add(new ManUnited() { Name = "Rashford", Number = 10, Attribute = 83 });

            return squad;

        }


        public static bool isSuperStar(ManUnited player)
        {
            if (player.Attribute > 90)
            {
                return true; 
            }
            else
            {
                return false;
            }
        }
      
    }

    public class ManUnited
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int Attribute { get; set; }

        public static void SuperStar(List<ManUnited> muPlayers, IsSuperstar isSuperstar)
        {
            foreach (ManUnited muPlayer in muPlayers)
            {
                if (isSuperstar(muPlayer))
                {
                    Console.WriteLine(muPlayer.Name + " is a superstar");
                }
            }
        }

    }
}

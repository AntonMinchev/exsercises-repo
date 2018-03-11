using System;
using System.Collections.Generic;
using System.Linq;
namespace Dragon_Army11
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<double>>> draconTypesInfo = new Dictionary<string, Dictionary<string, List<double>>>();
            
            double numbersOfInput = double.Parse(Console.ReadLine());
            string typeOfDragon = "";
            string nameOfDragon = "";
            double averageDamage = 0;
            double averageHealth = 0;
            double averageArmor = 0;
            for (double i = 0; i < numbersOfInput; i++)
            {
                List<string> infoDragons = Console.ReadLine().Split(' ').ToList();
                typeOfDragon = infoDragons[0];
                nameOfDragon = infoDragons[1];

                infoDragons.RemoveRange(0, 2);
                
                if (infoDragons[0] == "null")
                {
                    infoDragons[0] = "45";
                }
                if (infoDragons[1] == "null")
                {
                    infoDragons[1] = "250";
                }
                if (infoDragons[2] == "null")
                {
                    infoDragons[2] = "10";
                }
                if (!draconTypesInfo.ContainsKey(typeOfDragon))
                {
                    

                    Dictionary<string, List<double>> helper = new Dictionary<string, List<double>>();                        //[2],[3],[4]; damage}/{health}/{armor})
                    List<double> dragonsSkils = new List<double>();
                    dragonsSkils.Add(double.Parse(infoDragons[0]));
                    dragonsSkils.Add(double.Parse(infoDragons[1]));
                    dragonsSkils.Add(double.Parse(infoDragons[2]));
                    helper.Add(nameOfDragon, dragonsSkils);
                    draconTypesInfo.Add(typeOfDragon, helper);

                }
                else
                {
                    if (!draconTypesInfo[typeOfDragon].ContainsKey(nameOfDragon))
                    {
                        List<double> dragonsSkils = new List<double>();
                        dragonsSkils.Add(double.Parse(infoDragons[0]));
                        dragonsSkils.Add(double.Parse(infoDragons[1]));
                        dragonsSkils.Add(double.Parse(infoDragons[2]));
                        draconTypesInfo[typeOfDragon].Add(nameOfDragon, dragonsSkils);

                    }
                    else
                    {
                        List<double> dragonsSkils = new List<double>();
                        dragonsSkils.Add(double.Parse(infoDragons[0]));
                        dragonsSkils.Add(double.Parse(infoDragons[1]));
                        dragonsSkils.Add(double.Parse(infoDragons[2]));
                        draconTypesInfo[typeOfDragon][nameOfDragon] = dragonsSkils;
                    }
                    

                }

            }

                       
            foreach (var type in draconTypesInfo)
            {

                double br =0;
                
               
                foreach (var name  in type.Value.OrderBy(x=>x.Key))
                {
                    br++;
                    averageDamage += Convert.ToDouble(name.Value[0]);
                    averageHealth += Convert.ToDouble(name.Value[1]);
                    averageArmor += Convert.ToDouble(name.Value[2]);
                }

                Console.WriteLine($"{type.Key}::({averageDamage/br:f2}/{averageHealth/br:f2}/{averageArmor/br:f2})");
                foreach (var name in type.Value.OrderBy(x => x.Key))
                {
                    
                    Console.WriteLine($"-{name.Key} -> damage: {name.Value[0]}, health: {name.Value[1]}, armor: {name.Value[2]}");
                }
                averageDamage = 0;
                averageHealth = 0;
                averageArmor= 0;
                br = 0;
            }
        }
    }
}

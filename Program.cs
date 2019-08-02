using System;
using System.Globalization;
using Teste.Entities;
using Teste.Entities.Enums;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter departament's name: ");
            string departament = Console.ReadLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("DATA OF WORKER: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level: Junior/MidLevel/Senior: ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); //Ler com ponto .

            Departament dept = new Departament(departament);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Enter #{i + 1} contract data: "); //$ interpolação
                Console.Write("Date contract: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration, in hours: ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract); //add o contrato na lista dentro do metodo pertecente ao worker
            }

            Console.WriteLine();
            Console.WriteLine("Enter with mounth and year to calculate income (MM/YYYY)");
            string dateContract = Console.ReadLine();
            int mount = int.Parse(dateContract.Substring(0, 2)); //leu a data, posição zero, com dois tamanhos (mês)
            int year = int.Parse(dateContract.Substring(3, 4));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Departament: " + worker.Departament.Name);
            Console.WriteLine("Incame for " + mount + "/" + year + ":" + worker.Incame(year, mount).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}

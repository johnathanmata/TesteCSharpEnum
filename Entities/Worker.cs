using System;
using System.Collections.Generic;
using System.Text;
using Teste.Entities.Enums;

namespace Teste.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; } //associação de classes diferentes 
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); //instancia de list do tipo HourContract

        public Worker() { }

        public Worker(string name, WorkerLevel level, double baseSalary, Departament departament)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);  //Como CONTRACTS é uma lista, add nesta lista, componentes do tipo HourContract
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Incame(int year, int mounth)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts) //percorre a lista contract
            {
                if (contract.Date.Year == year && contract.Date.Month == mounth)
                    sum += contract.TotalValue();
            }
            return sum;
        }

        public override string ToString()
        {
            return "Name: "+ Name + "\nDepartament: " + Departament;
        }
    }
}

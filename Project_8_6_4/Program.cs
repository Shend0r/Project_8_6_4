using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_8_6_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Binaries.Data.Write("StudentsData", "Лёня,Группа1,12.04.2000;Максим,Группа1,30.08.2000;Антон,Группа2,07.02.2001");
            Console.WriteLine(Binaries.Data.Read("StudentsData"));
            Student.Add("StudentsData");

            Console.ReadKey();
        }
    }
}

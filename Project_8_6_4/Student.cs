using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project_8_6_4
{
    internal class Student : Binaries.Data
    {
        private static string Name { get; set; }
        private static string Group { get; set; }
        private static DateTime BirthDate { get; set; }
        private static string output_directory { get; set; }

        public Student() { }

        public static void Add(string ResourceFilePath)
        {
            output_directory = $"C:\\Users\\{Environment.UserName}\\Desktop\\Students";
            System.IO.Directory.CreateDirectory(output_directory);

            string Data = Read(ResourceFilePath).ToString();

            var students = Data.Split(';');
            var student = new string[] { };

            foreach (string get_student in students)
            {
                student = get_student.Split(',');

                Name = student[0];
                Group = student[1];
                BirthDate = DateTime.Parse(student[2]);

                Console.WriteLine("{0} {1} {2}", Name, Group, BirthDate);            

                if (!System.IO.File.Exists($"{output_directory}\\{Group}.txt"))
                {
                    System.IO.File.AppendAllText($"{output_directory}\\{Group}.txt", "");
                }
              
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter($"{output_directory}\\{Group}.txt", true, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"{Name},{BirthDate}");
                }

                // Изначально StreamWriter перезаписывал файл, решил использовать XML.Linq, но я решил проблему с перезаписью, XML.Linq Оставлю как дополнительный вариант решения задачи

                if (!System.IO.File.Exists($"{output_directory}\\{Group}.xml"))
                {
                    System.IO.File.AppendAllText($"{output_directory}\\{Group}.xml", "<students></students>");
                }

                XDocument xDocument = XDocument.Load($"{ output_directory}\\{Group}.xml");
                XElement xElement = xDocument.Element("students");
                XElement newXElement = new XElement("student", new XAttribute("Name", Name), new XAttribute("BirthDate", BirthDate)); // Это с Аттрибутами
                XElement newXElement2 = new XElement("student", $"{Name},{BirthDate}"); // Это через запятую
                xElement.Add(newXElement);
                xElement.Add(newXElement2);
                xDocument.Save($"{ output_directory}\\{Group}.xml");
            }

        }
    }
}

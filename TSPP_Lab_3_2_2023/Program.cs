//TSPP_Lab_3_2_2023 Підрахунок середнього балу групи по середнім балам успішності студентів.
using System;
using System.Text;
using System.IO;

namespace TSPP_Lab_3_2_2023
{
    struct Person //Структура ФІО, сер. бал
    {
        public string NameStud { get; set; }
        public uint SerBalStud { get; set; }
        public Person(string name, uint ball)
        {
            NameStud = name;
            SerBalStud = ball;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("\n Программа створить файл з iнформацiєю про студентiв, \n" +
                " їх середнiй бал та обрахує середнiй бал групи студентiв.");
            //Кількість студентів в групі
            uint N;
            do
            {
                Console.Write("\n Введiть кількість студентів в групі: ");
                string TN = Console.ReadLine();
                N = uint.Parse(TN);
                if (N <= 0) Console.WriteLine("\n Ви не коректно задали кiльiсть студентiв в групi!");
            }
            while (N <= 0);

            //Масив студентів і їх середній бал внесення
            Person[] stud = new Person[N];
            uint Sum = 0;
            for (int i = 0; i < N; i++)
            {
                Console.Write("\n Введiть прізвище студента: ");
                stud[i].NameStud = Console.ReadLine();
                Console.Write(" i його середнiй бал: ");
                stud[i].SerBalStud = uint.Parse(Console.ReadLine());
                Sum = Sum + stud[i].SerBalStud;
            }
            float Ser = ((float)Sum / (float) N);

            Console.Write("\n Введiть назву файлу для створення: ");
            string fileName = Console.ReadLine();
            string pathFile = String.Format("E:\\BUK_UNIVER\\II_kurs(II sem)\\ТСПП\\Laboratorni\\Lab3\\TSPP_Lab_3_2_2023\\" + fileName + ".dat");
            StreamWriter f = new StreamWriter(File.Open(pathFile, FileMode.OpenOrCreate));
          
                // записуємо в файл значеня 
                foreach (Person S in stud)
                {
                    f.Write(S.NameStud + " - ");
                    f.WriteLine(S.SerBalStud + ";");
                }
                f.Write("\n Середнiй бал групи становить - ");
                f.WriteLine($"{Ser:f2}");
                f.Close();
            
            Console.Clear();
            // Перевірка створення файла 
            if (!File.Exists(pathFile))
            {
                Console.WriteLine("Файл(" + pathFile + "не можливо відкрити");
                return;
            }
            else
            Console.WriteLine("Файл:\n" + pathFile + "\n створено і в нього запистано таку інформацію:\n");
            // Перевірка вмісту створеного файла виведенням даних в консоль
            StreamReader fr = new StreamReader(File.Open(pathFile, FileMode.Open));
            
                string Line;
                while ((Line = fr.ReadLine()) != null)
                {
                    Console.WriteLine(" " + Line + " ");
                }
                fr.Close();
            
        Console.ReadLine();
        }
    }
}


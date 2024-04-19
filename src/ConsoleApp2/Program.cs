using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            SubjectControl subjectControl = new SubjectControl();
            subjectControl.SubjectControlCreator();
            subjectControl.Sort();
            subjectControl.PrintToFile();
        }
    }


    class Subject
    {
        public string title;
        public int semestr;
        public string sertification_form;

        public Subject (string title, int semestr, string sertification_form)
        {
            this.title = title;
            this.semestr = semestr;
            this.sertification_form = sertification_form;
        }
    }

    class SubjectControl
    {

        Subject[] arr;


        public void SubjectControlCreator()
        {
            Console.Write("Введите количество учебных дисциплин >> ");
            int countSubject = int.Parse(Console.ReadLine());
            arr = new Subject[countSubject];
            for (int i = 0; i < countSubject; i++)
            {

                Console.Write("Введите наименование учебной дисциплины >> ");
                string title = Console.ReadLine();
                Console.Write("Введите семестр >> ");
                int semestr = int.Parse(Console.ReadLine());
                Console.Write("Введите форму аттестации >> ");
                string sertification_form = Console.ReadLine();
                Subject subject = new Subject(title, semestr, sertification_form);
                arr[i] = subject;

            }
        }

        public void Sort()
        {

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j].semestr > arr[j + 1].semestr)
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                    else if (arr[j].semestr == arr[j + 1].semestr)
                    {
                        int compare = string.Compare(arr[j].title, arr[j + 1].title, false);
                        if (compare > 0)
                        {
                            (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        }
                    }
                    
                }
            }

        }

        public void PrintToFile()
        {

            using (StreamWriter writer = new StreamWriter("output.txt", false))
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    writer.Write($"Наименование: {arr[i].title}, Семестр: {arr[i].semestr}, Форма аттестации: {arr[i].sertification_form}\n");
                }
            }
        }
    }
}

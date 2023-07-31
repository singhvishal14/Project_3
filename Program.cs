using System;
using System.Collections.Generic;
using System.IO;

namespace PracticeProject3
{
    internal class Program
    {
        public static void InsertionSort(string[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                string temp = arr[i];
                int j = i - 1;
                while (j >= 0 && string.Compare(arr[j], temp) > 0)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = temp;
            }
        }


        public static void Display(string[] Array, List<string> Names, List<string> Class)
        {
            foreach (string name in Array)
            {
                int index = Names.IndexOf(name);
                string grade = Class[index];
                Console.WriteLine($"{name}, class: {grade}");
            }
        }
        public static void Search(string[] Array, List<string> studentNames, List<string> Class)
        {
            Console.WriteLine("Enter the name of the student you want to search:");
            string searchName = Console.ReadLine();

            int index = studentNames.IndexOf(searchName);
            if (index >= 0)
            {
                string grade = Class[index];
                Console.WriteLine($"Student Present in the list: {searchName}, class: {grade}");
            }
            else
            {
                Console.WriteLine("Student not found in the list.");
            }
        }
        static void Main(string[] args)
        {
            string filepath = "C:\\Users\\Administrator\\Desktop\\Student.txt";
            try
            {
                string[] lines = File.ReadAllLines(filepath);
                List<string> Names = new List<string>();
                List<string> Class = new List<string>();

                foreach (string line in lines)
                {
                    String[] studentdata = line.Split(',');
                    string name = studentdata[0];
                    string grade = studentdata[1];

                    Names.Add(name);
                    Class.Add(grade);
                }

                string[] namesArray = Names.ToArray();

                InsertionSort(namesArray);

                Console.WriteLine("Sorted Names are Here:");
                Display(namesArray,Names,Class);

           
            result:
                Search(namesArray, Names, Class);
                Console.WriteLine("Press 'y' if you want to  Search REcord ");
                string choice = Console.ReadLine();
                if (choice == "y")
                {


                    goto result;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
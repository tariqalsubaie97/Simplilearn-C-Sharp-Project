using System;

class Project
{
    //Some Global Variables
    public static int linecount;
    public static int ID;
    public static string Name;
    public static string Class;
    public static string Section;
    static void Main(string[] args)
    {
        //An introduction to the program
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Welcome to Rainbow School Storing System!");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Add New Data or Update By Inserting ID:");
        //Readings of user
        ID = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Name:");
        Name = Console.ReadLine();
        Console.WriteLine("Class:");
        Class = Console.ReadLine();
        Console.WriteLine("Section:");
        Section = Console.ReadLine();
        //Start file editing
        RunFile();
    }
    public static void RunFile()
    {
        //Add the file to directory and choosing it
        string dir = Directory.GetCurrentDirectory();
        string filename = "Data.txt";
        if (File.Exists(filename))
        {
            //Read the file for checking
            string[] check = File.ReadAllLines(filename);
            if (check.Contains("ID: " + ID))
            {
                for (int i = 0; i < check.Length; i++)
                {
                    //Check if ID is listed
                    if (check[i].Contains("ID: " + ID))
                    {
                        //Replacing old data with new ones
                        check[i + 1] = "Name: " + Name;
                        check[i + 2] = "Class: " + Class;
                        check[i + 3] = "Section: " + Section;

                        using (StreamWriter sw = File.CreateText(filename))
                        {
                            //Writing each line again with edited data
                            foreach (string line in check)
                            {
                                sw.WriteLine(line);
                            }
                        }
                        Console.WriteLine("Data Edited!");

                    }
                }
            }



            else
            {
                //If ID doesn't exists, this will write a new form
                using (StreamWriter sw = File.AppendText(filename))
                {
                    sw.WriteLine("ID: " + ID);
                    sw.WriteLine("Name: " + Name);
                    sw.WriteLine("Class: " + Class);
                    sw.WriteLine("Section: " + Section);
                    sw.WriteLine("----------------------");
                }
                Console.WriteLine("Data Added!");
            }
        }

        else
        {
            File.CreateText(filename);
        }


    }
}
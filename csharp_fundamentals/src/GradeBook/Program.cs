using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new DiskBook("Daniel's Grade Book");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);
            var stats = book.GetStatistics();
            System.Console.WriteLine($"The name is {book.Name}");
            System.Console.WriteLine($"The lowest grade is {stats.Low}");
            System.Console.WriteLine($"The high grade is {stats.High}");
            System.Console.WriteLine($"The average grade is {stats.Average:N1}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            var input = string.Empty;
            do
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                input = Console.ReadLine();

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (System.ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

            } while (input.ToLower() != "q");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}

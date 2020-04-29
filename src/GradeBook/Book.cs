using System.Collections.Generic;
using System;
namespace GradeBook
{
    public class Book
    {
        public string Name { get; set; }
        private List<double> grades { get; set; }
        
        public Book(string name)
        {
            Name = name;
            grades = new List<double>();
        }
        
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics() { High = double.MinValue, Low = double.MaxValue, Average = 0 };
            foreach (double grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            return result;
        }
    }
}
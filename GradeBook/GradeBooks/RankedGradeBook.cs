using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name) 
        {
            Type = GradeBookType.Ranked;
        }


        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");
            }

            return CalculateLetterGrade(averageGrade);
        }

        private char CalculateLetterGrade(double averageGrade)
        {
            SortedDictionary<int, double> Grades = new SortedDictionary<int, double>();
            foreach (var student in Students)
            {
                student.Grades.ForEach(s => Grades.Add(int.Parse(s.ToString()), s));
            }

            int TotalNumberofGrades = Grades.Values.Count;

            int splitter = TotalNumberofGrades / 5; //This returns value at 20%

            if (averageGrade >= Grades.Values.ElementAt(splitter))
            {
                return 'A';
            }

            splitter += TotalNumberofGrades / 5; //This returns value at 40%

            if (averageGrade >= Grades.Values.ElementAt(splitter))
            {
                return 'B';
            }

            splitter += TotalNumberofGrades / 5; //This returns value at 60%

            if (averageGrade >= Grades.Values.ElementAt(splitter))
            {
                return 'C';
            }

            splitter += TotalNumberofGrades / 5; //This returns value at 80%

            if (averageGrade >= Grades.Values.ElementAt(splitter))
            {
                return 'D';
            }

            return 'F';
        }
    }
}

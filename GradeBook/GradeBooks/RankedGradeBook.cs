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
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToArray();

            int gradesCount = grades.Count();

            int threshold = (int)Math.Ceiling(gradesCount * 0.2); //This returns value at 20%


            if (averageGrade >= grades[threshold - 1]) return 'A';

            threshold += gradesCount / 5; //This returns value at 40%
            if (averageGrade >= grades[(threshold * 2) - 1]) return 'B';

            threshold += gradesCount / 5; //This returns value at 60%
            if (averageGrade >= grades[(threshold * 3) - 1])  return 'C';

            threshold += gradesCount / 5; //This returns value at 80%
            if (averageGrade >= grades[(threshold * 4) - 1]) return 'D';

            return 'F';
        }
    }
}

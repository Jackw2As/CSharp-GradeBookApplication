using GradeBook.Enums;
using System;
using System.Linq;

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

            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            int threshold = (int)Math.Ceiling(Students.Count * 0.2);

            if (averageGrade >= grades[threshold - 1]) 
                return 'A';
            
            if (averageGrade >= grades[(threshold * 2) - 1]) 
                return 'B';
           
            if (averageGrade >= grades[(threshold * 3) - 1])  
                return 'C';
            
            if (averageGrade >= grades[(threshold * 4) - 1]) 
                return 'D';

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name) {
            
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }

    }
}

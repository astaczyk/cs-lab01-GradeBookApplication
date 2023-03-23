using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name)  : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5) {
                throw new InvalidOperationException(); }

            int betterStudent = 0;
            for(int i = 0; i< Students.Count; i++)
            {
                if (Students[i].AverageGrade > averageGrade)
                    betterStudent++;
            }

            double topStudent = ((double)betterStudent/ (double)Students.Count) * 100;

            if (topStudent < 20)
                return 'A';
            else if (topStudent < 40)
                return 'B';
            else if (topStudent < 60)
                return 'C';
            else if (topStudent < 80)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading require at least 5 students");
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading require at least 5 students");
            else
                base.CalculateStudentStatistics(name);
        }
    }
}

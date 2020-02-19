using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_Calculator
{
    class Student
    {
        private int[,][] _grades;
        //This jagged array's outer array represents the 
        public string _name
        {
            get;set;
        }
        //This string represents the student's name.
        public double _finalGrade
        {
            get;set;
        }
        //This double represents the student's final grade.
        public Student(int numGradingAreas)
        {
            _grades = new int[numGradingAreas,2][];
        }
        //This method creates the Student object and establishes its name and the number of grading areas.
        public void SetNumGrades(int gradingArea, int numGrades)
        {
            _grades[gradingArea,0] = new int[numGrades];
        }
        //This method sets the number of grades for each grading area
        public void SetGrade(int gradingArea, int numGrade, int grade)
        {
            _grades[gradingArea,0][numGrade] = grade;
        }
        //Sets grade to _grades array when given gradingArea, numGrade and grade
        public int GetNumGrades(int gradingArea)
        {
            return _grades[gradingArea,0].Length;
        }
        //Returns the number of grades the student has credit for in a given grading area
        public double GetFinalGrade()
        {
            double _finalGrade = 0;
            double[] _gradeAreaScore = new double[_grades.GetLength(0)];
            for(int i = 0; i < _grades.GetLength(0); i++)
            {
                int _numNa = 0;
                for(int j = 0; j < _grades[i,0].Length; j++)
                {
                    int grade = _grades[i,0][j];
                    if (grade == -1) _numNa++;
                    else _gradeAreaScore[i] += grade;
                }
                _finalGrade += (_gradeAreaScore[i] / (_grades[i,0].Length - _numNa)) * (_grades[i,1][0] * 0.01);
            }
            return _finalGrade;
        }
        //Returns the final grade of the student
        public Student CompareGrade(Student other)
        {
            if (other.GetFinalGrade() > GetFinalGrade()) return other;
            return this;
        }
        //Returns the student with the higher final grade.
        public void SetGradeAreaPercents(int gradeAreaPercent)
        {
            
            for(int i = 0; i < _grades.GetLength(0); i++)
            {
                _grades[i, 1] = new int[1];
                _grades[i, 1][0] = gradeAreaPercent;
            }
        }
        //Sets the perecent each grade area affect the final grade in _grades[x, 1][0], with x changing for each different grade area.
    }
}

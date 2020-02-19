using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_Calculator
{
    class ClassGrades
    {
        private string _subject;
        private double _classAvg;
        Student[] _students;
        public int[] _gradePercent;
        string[] _gradePercentNames;
        double[] _finalGrades;
        public string SetUpClass()
        {
            SetSubject(Console.ReadLine());
            Console.WriteLine("How many students are in this class?");
            SetNumStudents(UserInputVeri(1, 1000, false));
            SetGradePercents();
            SetStudentGrades();
            return _subject;
        }
        //Uses the other ClassGrades methods to create a class of students
        public void SetSubject(string subject)
        {
            _subject = subject;
        }
        //Sets the subject of the class.
        public void SetNumStudents(int size)
        {
            _students = new Student[size];
            _finalGrades = new double[size];
        }
        //Sets number of students in the class
        public void SetGradePercents()
        {
            int percentInputed = 0;
            bool flaggy = false;
            Console.WriteLine("How many grading areas are there?");
            int _numAreas = UserInputVeri(1, 10, false);
            _gradePercent = new int[_numAreas];
            _gradePercentNames = new string[_numAreas];
            do
            {
                for (int i = 0; i < _numAreas; i++)
                {
                    Console.WriteLine($"What is the name of grading area {i + 1}?");
                    _gradePercentNames[i] = Console.ReadLine();
                    Console.WriteLine($"What percent of the final grade do {_gradePercentNames[i]} make up?");
                    _gradePercent[i] = UserInputVeri(0, 100 - percentInputed, false);
                    percentInputed += _gradePercent[i];
                    if (percentInputed > 100) flaggy = true;
                }
                if (percentInputed != 100) flaggy = true;
                if (flaggy) { Console.WriteLine("There was an error in the percentages you inputed. Let's try again."); percentInputed = 0; }
            } while (flaggy);
        }
        //Sets the percentages each grading area effects the final grade.
        public void SetStudentGrades()
        {
            for(int i = 0; i < _students.Length; i++)
            {
                _students[i] = new Student(_gradePercent.Length);
                Console.WriteLine($"What is student {i + 1}'s name?");
                _students[i]._name = Console.ReadLine();
                for(int j = 0; j < _gradePercentNames.Length; j++)
                {
                    Console.WriteLine($"How many grades did {_students[i]._name} complete in grading area {_gradePercentNames[j]}?");
                    _students[i].SetNumGrades(j, UserInputVeri(0, 100, false));
                    for(int z = 0; z < _students[i].GetNumGrades(j); z++)
                    {
                        Console.WriteLine($"What grade did {_students[i]._name} earn on {_gradePercentNames[j]} {z + 1}?");
                        _students[i].SetGrade(j, z, UserInputVeri(-1, 100, false));
                    }
                }
                for(int j = 0; j < _gradePercent.Length; j++)
                {
                    _students[i].SetGradeAreaPercents(_gradePercent[j]);
                }
                _finalGrades[i] = _students[i].GetFinalGrade();
            }
        }
        //Allows the input of all student's grades.
        public string ShowAllGrades()
        {
            string temp = $"{_subject}|";
            for(int i = 0; i < _students.Length; i++)
            {
                temp += $"{_students[i]._name}: {_finalGrades[i]}; ";
            }
            return temp;
        }
        //Displays the final grades of all students.
        public double GetClassAvg()
        {
            _classAvg = 0;
            for(int i = 0; i < _finalGrades.Length; i++)
            {
                _classAvg += _finalGrades[i];
            }
            _classAvg = _classAvg / _finalGrades.Length;
            return _classAvg;
        }
        //Returns the avg grade for the class.
        public int GetNumStudents()
        {
            return _students.Length;
        }
        //Returns the number of students in class.
        public Student GetHighestScorer()
        {
            Student _highestScorer = _students[0];
            for (int i = 1; i < _finalGrades.Length; i++)
            {
                _highestScorer = _students[i - 1].CompareGrade(_students[i]);
            }
            return _highestScorer;
        }
        //Returns the student with the highest score in the class.
        static int UserInputVeri(int lowerBound, int upperBound, bool letter)
        {
            bool flag = false;
            bool realLet = false;
            int output = 0;
            char charput;
            if (letter)
            {
                while (!flag)
                {
                    string input = Console.ReadLine();
                    realLet = char.TryParse(input, out charput);
                    if (realLet)
                    {
                        int place = (int)charput;
                        if (place >= 65 && place <= 90) return output = place - 65;
                        else if (place >= 97 && place <= 122) return output = place - 97;
                        else flag = int.TryParse(input, out output);
                    }
                    else flag = int.TryParse(input, out output);

                    if (!flag || output < lowerBound || output > upperBound) Console.WriteLine("Please enter a valid value");
                }
            }
            else
            {
                while (!flag || output < lowerBound || output > upperBound)
                {
                    flag = int.TryParse(Console.ReadLine(), out output);
                    if (!flag || output < lowerBound || output > upperBound) Console.WriteLine("Please enter a valid value");
                }
            }
            return output;
        }
        //This method does user input verification for allowed int values and certain char values based upon the parameters.
    }
}

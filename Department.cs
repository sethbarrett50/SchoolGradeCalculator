using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_Calculator
{
    class Department
    {
        public string _name
        {
            get;set;
        }
        Teacher[] _teachers;
        string[] _teacherNames;
        double[] _teacherAvgs;
        double _deptAvg;
        public string SetUpDepartment()
        {
            _name = Console.ReadLine();
            Console.WriteLine($"How many teachers are in the {_name} department?");
            _teachers = new Teacher[UserInputVeri(1, 20000, false)];
            _teacherNames = new string[_teachers.Length];
            _teacherAvgs = new double[_teachers.Length];
            for (int i = 0; i < _teachers.Length; i++)
            {
                _teachers[i] = new Teacher();
                Console.WriteLine($"What is teacher {i + 1}'s name?");
                _teacherNames[i] = _teachers[i].SetUpTeacher();
                _teacherAvgs[i] = _teachers[i].GetAvgAll();
                _deptAvg += _teacherAvgs[i];
            }
            _deptAvg = _deptAvg / _teachers.Length;
            return _name;
        }
        //Sets up the Department Object
        public int GetNumStudents()
        {
            int temp = 0;
            for(int i = 0; i < _teachers.Length; i++)
            {
                temp += _teachers[i].GetNumStudents();
            }
            return temp;
        }
        //Returns number of students in the department.
        public double GetDeptAvg()
        {
            return _deptAvg;
        }
        //Returns the avg grade of all teachers in the department.
        public Student GetHighestScorer()
        {
            Student _highestScorer = _teachers[0].GetHighestScorer();
            for(int i = 1; i < _teachers.Length; i++)
            {
                _highestScorer = _teachers[i - 1].GetHighestScorer().CompareGrade(_teachers[i].GetHighestScorer());
            }
            return _highestScorer;
        }
        //Returns student with the highest score in the department.
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

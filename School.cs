using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_Calculator
{
    class School
    {
        Department[] _depts;
        string[] _deptNames;
        double[] _deptAvgs;
        double _avg;
        public string _name
        {
            get;set;
        }
        public void SetUpSchool()
        {
            Console.WriteLine("What is the name of this school?");
            _name = Console.ReadLine();
            Console.WriteLine($"How many teaching departments does {_name} have?");
            _depts = new Department[UserInputVeri(0, 20000, false)];
            _deptNames = new string[_depts.Length];
            _deptAvgs = new double[_depts.Length];
            for(int i = 0; i < _depts.Length; i++)
            {
                _depts[i] = new Department();
                Console.WriteLine($"What is the name of department {i+1}");
                _deptNames[i] = _depts[i].SetUpDepartment();
                _deptAvgs[i] = _depts[i].GetDeptAvg();
                _avg += _deptAvgs[i];
            }
            _avg = _avg / _depts.Length;
        }
        //Sets up the School object
        public double GetAvg() { return _avg; }
        //Returns the grade average of all student's final grades at the school.
        public int GetNumStudents()
        {
            int temp = 0;
            for(int i = 0; i<_depts.Length; i++)
            {
                temp += _depts[i].GetNumStudents();
            }
            return temp;
        }
        //Returns the number of students at the school
        public Student GetHighestScorer()
        {
            Student _highestScorer = _depts[0].GetHighestScorer();
            for(int i = 1; i < _depts.Length; i++)
            {
                _highestScorer = _depts[i - 1].GetHighestScorer().CompareGrade(_depts[i].GetHighestScorer());
            }
            return _highestScorer;
        }
        //Returns the student with the highest grades in the school.
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

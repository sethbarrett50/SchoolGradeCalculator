using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_Calculator
{
    class Teacher
    {
        ClassGrades[] _classes;
        string[] _classnames;
        double[] _classAvgs;
        double _avgAllClasses;
        public string _name
        {
            get;set;
        }
        public string SetUpTeacher()
        {
            _name = Console.ReadLine();
            Console.WriteLine($"How many classes does {_name} teach?");
            _classes = new ClassGrades[UserInputVeri(1, 20000, false)];
            _classnames = new string[_classes.Length];
            _classAvgs = new double[_classes.Length];
            //Creates three new arrays, one of ClassGrade objects, one of their averages and lastly one for their names.
            for (int i = 0; i < _classes.Length; i++)
            {
                _classes[i] = new ClassGrades();
                Console.WriteLine($"What is the name of class {i+1}?");
                _classnames[i] = _classes[i].SetUpClass();
                _classAvgs[i] = _classes[i].GetClassAvg();
                _avgAllClasses += _classes[i].GetClassAvg();
            }
            _avgAllClasses = _avgAllClasses / _classes.Length;
            //Runs the SetUpClass method which creates all the students, grade areas and final grade percentages.
            return _name;
        }
        //Sets up one teacher object.
        public string ShowTeacherClasses()
        {
            string temp = $"{_name}|";
            for(int i = 0; i < _classes.Length; i++)
            {
                temp += $"\n{_classnames[i]} Avg: {_classes[i].GetClassAvg()}";
            }
            return temp;
        }
        //Displays each class followed by its class avg.
        public double GetAvgAll()
        {
            return _avgAllClasses;
        }
        //Returns the avg grade of all a teacher's classes.
        public int GetNumStudents()
        {
            int temp = 0;
            for(int i = 0; i < _classes.Length; i++)
            {
                temp += _classes[i].GetNumStudents();
            }
            return temp;
        }
        //Returns the number of students in all of the teacher's classes.
        public Student GetHighestScorer()
        {
            Student _highestScorer = _classes[0].GetHighestScorer();
            for(int i = 1; i<_classes.Length; i++)
            {
                _highestScorer = _classes[i - 1].GetHighestScorer().CompareGrade(_classes[i].GetHighestScorer());
            }
            return _highestScorer;
        }
        //Returns the student with the highest final grade that the teacher teaches.
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            School _school = new School();
            _school.SetUpSchool();
            //Creates the data for the grades of the entire school

            Console.WriteLine($"The avg of the whole school is {_school.GetAvg()}");

            Student _highestScorer = _school.GetHighestScorer();
            Console.WriteLine($"The student with the highest final grade in the school is {_highestScorer._name} with a final grade of {_highestScorer.GetFinalGrade()}");

            Console.WriteLine($"There are {_school.GetNumStudents()} students at {_school._name}.");
            //Examples of potential applications
        }
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

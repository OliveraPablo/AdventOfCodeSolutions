
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        

        static void Main(string[] args)
        {
            DayOne dayOne = new DayOne();
          //  dayOne.ExerciseOneSolution();
            dayOne.ExerciseTwoSolution();
        }
       
        
    }

    class DayOne
    {
       string path = AppDomain.CurrentDomain.BaseDirectory;
        //Exercise One.
       public void ExerciseOneSolution()
        {
            int result = IncreasedCounter(Lines());
            Console.WriteLine(result);
            Console.ReadKey();
        }
        public void ExerciseTwoSolution()
        {
            List<int> testList = new List<int>();
            testList.Add(9);
            testList.Add(5);
            testList.Add(2);
            testList.Add(3);
            testList.Add(2);
            testList.Add(1);
            testList.Add(0);
            AddWindowValues(Lines());
            int result  = IncreasedCounter(windows);
            Console.WriteLine(result);
            
            Console.ReadKey();
        }
       List<int> Lines()
        {

            List<int> lines = new List<int>();
            
            using (StreamReader reader = new StreamReader(Path.Combine(path, "day1.txt")))
            {
                while (!reader.EndOfStream)
                {
                    lines.Add(Convert.ToInt32(reader.ReadLine()));

                }
            }

            return lines;
        }
       int IncreasedCounter(List<int> values)
        {
            int counter = 0;
            for (int i = 1; i < values.Count; i++)
            {
                if (values[i] > values[i - 1])
                {
                    counter++;
                }
            }


            return counter;
        }
       List<int> windows = new List<int>();
       
        void AddWindowValues(List<int> values)
        {

            
            for(int i = 0; i < values.Count; i++)
            {
                bool keepAdding = true;
                int sum = 0;
               
                
                    for (int interval = i; interval <= i + 2; interval++)
                    {
                        if (interval < values.Count)
                        {
                             keepAdding = true;
                            sum += values[interval];

                        }
                    else
                    {
                        keepAdding = false;
                    }

                    }
                    if(keepAdding) windows.Add(sum);
                    
               

                

            }
        }


        //Exercise Two.
    }
}

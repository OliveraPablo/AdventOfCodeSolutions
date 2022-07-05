
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
            //  dayOne.ExerciseTwoSolution();
            DayTwo dayTwo = new DayTwo();
            dayTwo.PartOneSolution();
            
        }
      
    }

    class DayOne
    {
        #region Problem url(Input file at base folder)
        /* https://adventofcode.com/2021/day/1#part2 */
        #endregion


        FileManager<int> fm = new FileManager<int>();
        //Exercise One.
       public void ExerciseOneSolution()
        {
            int result = IncreasedCounter(fm.Lines("day1.txt"));
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
            AddWindowValues(fm.Lines("day1.txt"));
            int result  = IncreasedCounter(windows);
            Console.WriteLine(result);
            
            Console.ReadKey();
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


     
    }
  

    class DayTwo
    {
        
       public void PartOneSolution()
        {
            SplitItems();
            MoveSubmarine();
            Console.WriteLine($"Horizontal:{horizontalTotal}");
            Console.WriteLine($"Depth: {depthTotal}");
            result = depthTotal * horizontalTotal;
            Console.WriteLine(result);
        }
        static string fileName = "day2.txt";
        FileManager<string> fm = new FileManager<string>();
        char separator = ' ';
        List<string> direction = new List<string>();
        List<int> amount = new List<int>();
        int horizontalTotal = 0;
        int depthTotal= 0;
        int result;
        
        
        void SplitItems()
        {
            List<string> values = fm.Lines(fileName); 
            foreach(string v in values)
            {
                string[] rawText = v.Split(separator);
                direction.Add(rawText[0]);
                amount.Add(Convert.ToInt32(rawText[1]));
            }
        }

        void MoveSubmarine()
        {
            for(int i = 0; i<direction.Count; i++)
            {
                switch (direction[i])
                {
                    case "forward":
                        horizontalTotal += amount[i];
                        break;
                    case "down":
                        depthTotal += amount[i];
                        break;
                    case "up":
                        depthTotal -= amount[i];
                        break;

                }
            }
        }

        

    }
    public class FileManager <T> 
    {
        static string path = AppDomain.CurrentDomain.BaseDirectory;
        public List<T> Lines(string dayText)
        {

            List<T> lines = new List<T>();

            using (StreamReader reader = new StreamReader(Path.Combine(path, dayText)))
            {
                while (!reader.EndOfStream)
                {
                    T value = (T)Convert.ChangeType(reader.ReadLine(), typeof(T));
                    
                    lines.Add((T)value);

                }
            }

            return lines;
        }
    }
}

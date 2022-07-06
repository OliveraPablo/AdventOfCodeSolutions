
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
            //  dayTwo.PartOneSolution();
            // dayTwo.PartTwoSolution();
            DayThree dayThree = new DayThree();
            dayThree.PartOneSolution();
            dayThree.PartTwoSolution();
            

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
            MoveSubmarine(false);
            Console.WriteLine($"Horizontal:{horizontalTotal}");
            Console.WriteLine($"Depth: {depthTotal}");
            result = depthTotal * horizontalTotal;
            Console.WriteLine(result);
        }
        public void PartTwoSolution()
        {
            SplitItems();
            MoveSubmarine(true);
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
        int aim = 0;
        
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

        void MoveSubmarine(bool partTwo)
        {
            for(int i = 0; i<direction.Count; i++)
            {
                switch (direction[i])
                {
                    case "forward":
                        horizontalTotal += amount[i];
                        if (partTwo)
                        {
                            depthTotal = depthTotal + (aim * amount[i]);
                        }
                        
                        break;
                    case "down":
                        
                        if (partTwo)
                        {
                            aim += amount[i];
                        }
                        else
                        {
                            depthTotal += amount[i];
                        }
                        break;
                    case "up":
                      
                        if (partTwo)
                        {
                            aim -= amount[i];
                        }
                        else
                        {
                            depthTotal -= amount[i];
                        }
                        break;

                }
            }
        }

        

    }
    class DayThree
    {
        public void PartOneSolution()
        {
          long gamma = ToDecimal(Gamma());
          long epsilon = ToDecimal(Epsilon());
          long result = gamma * epsilon;
            Console.WriteLine(result);
        }
        public void PartTwoSolution()
        {
            Console.WriteLine($"OX B:{OxigenGeneratorRating()}");
            long oxigenDecimal = ToDecimal(OxigenGeneratorRating());
            Console.WriteLine($"OX D:{oxigenDecimal}");
            Console.WriteLine($"CO2 B:{CO2ScrubbingRating()}");
            long CO2Decimal = ToDecimal(CO2ScrubbingRating());
            Console.WriteLine($"OX D:{CO2Decimal}");

          long result = oxigenDecimal * CO2Decimal;
           Console.WriteLine($"Result: {result}");

        }
       static string path = "day3.txt";
        FileManager<string> fm = new AdventOfCode.FileManager<string>();
        char findCommonBit(string row, int function)
        {

            
            char commonBit = ' ';
            int zeroes = 0;
            int ones = 0;

            for (int i = 0; i < row.Length; i++)
            {
                char digit = row[i];
                if (digit == '1')
                {
                    ones++;
                }
                else
                {
                    zeroes++;
                }
                
            }
            switch(function) {
                //gamma-epsilon
                case 0:
                    if (ones > zeroes)
                    {
                        commonBit = '1';
                    }
                    else
                    {
                        commonBit = '0';
                    }
                    break;
                //oxigenRate
                case 1:
                    if (ones >= zeroes)
                    {
                        commonBit = '1';
                    }
                    else
                    {
                        commonBit = '0';
                    }
                    break;
                    //CO2Rate
                case 2:
                    if (ones >= zeroes)
                    {
                        commonBit = '1';
                    }
                    else
                    {
                        commonBit = '0';
                    }
                    break;

            }
            
                

           
            return commonBit;
        }

       public string OxigenGeneratorRating()
        {
            List<string> values = fm.Lines(path);
            
            int index = 0;
            int indexMax = values[0].Length;
            string result = "";
            
            for (int a = index; a < indexMax ; a++)
            {
               
                char commonBit = ' ';
                string row = "";
                for (int i = 0; i < values.Count ; i++)
                {

                    row += (values[i])[a];

                }
                
                commonBit = findCommonBit(row, 1);
                if(values.Count > 1)
                {
                    for (int f = values.Count - 1; f >= 0; f--)
                    {

                        if ((values[f])[a] == commonBit)
                        {

                            values.RemoveAt(f);

                        }
                    }
                }
                
               
            }
            foreach(string c in values)
            {
                Console.WriteLine(c);
            }
            return values[0];


            
            




            
        }


        public string CO2ScrubbingRating()
        {
            List<string> values = fm.Lines(path);
            List<string> filteredValues = new List<string>();
            int index = 0;
            int indexMax = values[0].Length;
            string result = "";

            for (int a = index; a < indexMax; a++)
            {

                char commonBit = ' ';
                string row = "";
                for (int i = 0; i < values.Count; i++)
                {

                    row += (values[i])[a];

                }

                commonBit = findCommonBit(row, 2);
                if(values.Count > 1)
                {

                for (int f = values.Count - 1; f >= 0; f--)
                {

                    if ((values[f])[a] != commonBit)
                    {
                      
                        values.RemoveAt(f);

                    }
                }
                }

            }
           
            return values[0];





        }

        string Gamma()
        {
            string result = "";
            List<string> values = fm.Lines("day3.txt");

            int index = 0;
            int indexMax = values[0].Length;


            for (int a = 0; a < indexMax; a++)
            {
                string row = "";
                for (int i = 0; i < values.Count; i++)
                {
                    
                    row += (values[i])[a];
                   
                }
                if(findCommonBit(row, 0) == '1')
                {
                    result += '1';
                }
                else
                {
                    result += '0';
                }
                
            }


            Console.WriteLine("Gamma: " + result);
            return result;
        }
     

        string Epsilon()
        {
            string result = "";
            List<string> values = fm.Lines("day3.txt");

            int index = 0;
            int indexMax = values[0].Length;


            for (int a = 0; a < indexMax; a++)
            {
                string row = "";
                for (int i = 0; i < values.Count; i++)
                {

                    row += (values[i])[a];

                }
                if (findCommonBit(row, 0) == '1')
                {
                    result += '0';
                }
                else
                {
                    result += '1';
                }

            }


            Console.WriteLine("Epsilon " + result);
            return result;
        }
        long ToDecimal(string input)
        {
           
            long power = 1;
            long result = 0;
            for(int i = input.Length -1 ; i>= 0; i--)
            {
                if(input[i] == '1')
                {
                    result += power;
                }
                power *= 2;
            }

            return result;
        }
    }

    class DayFour
    {

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

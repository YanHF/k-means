using DataStructure;
using System;

namespace ClusterNumeric
{
    class ClusterNumProgram
    {
        public static int dataNumber = 0;
        public static int keyNumber = 0;
        static void Main(string[] args)
        {
            start:
            string[] inputArray = null;
            {
                Console.WriteLine("\nEnter the total number of data you want to divide and The number of divisions\nFor example: 100,3");
                string input = Console.ReadLine();
                inputArray = input.Split(new char[] { ',' });
            } while (!int.TryParse(inputArray[0], out dataNumber) || !int.TryParse(inputArray[1], out keyNumber) || keyNumber >= dataNumber) ;

            Random random = new Random();
            double[] _data = new double[dataNumber];
            Console.WriteLine("\nShow the total number of  random generated  data");
            Console.WriteLine("-------------------------------------------------------------------------");
            int M = 1;
            for (int i = 0; i < _data.Length; i++)
            {
                _data[i] = Math.Round(random.NextDouble() * (100 < dataNumber ? dataNumber : 100), 2);
                Console.Write(_data[i].ToString("F2").PadLeft(7));
                if (M++ % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
            int[] _index = new int[dataNumber];
            int[] keyData = new int[keyNumber];
            for (int i = 0; i < keyNumber; i++)
            {
                keyData[i] = random.Next(0, dataNumber);
            }
            K_Means._K_Means(_data, ref _index, keyData);
            Console.WriteLine("\n*************************************************************************");
            Console.WriteLine("\nShow the Result");
            Console.WriteLine("-------------------------------------------------------------------------");
            for (int i = 0; i < keyData.Length; i++)
            {
                M = 1;
                Console.WriteLine("Value values of the " + (i + 1) + " group:key " + _data[keyData[i]].ToString().PadRight(7));
                Console.WriteLine();
                for (int j = 0; j < _index.Length; j++)
                {
                    if (_index[j] == i + 1)
                    {
                        Console.Write(_data[j].ToString("F2").PadLeft(7));
                        if (M++ % 10 == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------------------");
            }
            Console.WriteLine("*************************************************************************");
            goto start;
        }
    }
}
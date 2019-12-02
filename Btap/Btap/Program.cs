using System;
using System.IO;

namespace Btap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Processing file...");

                File.WriteAllText("output1.txt", B1(Convert.ToInt32(File.ReadAllText("input1.txt"))));
                Console.WriteLine("Finished 1!");

                File.WriteAllText("output2.txt", B2(Convert.ToInt32(File.ReadAllText("input2.txt"))));
                Console.WriteLine("Finished 2!");

                File.WriteAllText("output3.txt", B3(File.ReadAllText("input3.txt")));
                Console.WriteLine("Finished 3!");

                File.WriteAllText("output4.txt", B4(File.ReadAllLines("input4.txt")).ToString());
                Console.WriteLine("Finished 4!");

                File.WriteAllText("output5.txt", B5(File.ReadAllText("input5.txt")));
                Console.WriteLine("Finished 5!");

                File.WriteAllText("output6.txt", B6(File.ReadAllLines("input6.txt")).ToString());
                Console.WriteLine("Finished 6!");
            
            
        }

        static string B1(int input)
        {
            string res = "";
            while (input > 0)
            {
                res = (input % 2).ToString() + res;
                input /= 2;
            }
            return res;
        }
        
        static string B2(int count)
        {
            string res = "";
            for (int i = 1; i<=count; i++)
            {
                res += i.ToString();
            }
            int oddEven = 0;
            while (res.Length > 1)
            {
                
                if (oddEven % 2 == 0)
                {
                    for (int i = 1; i < res.Length; i++)
                    {
                        res=  res.Remove(i, 1);
                    }
                }
                else
                {
                    for (int i = 0; i < res.Length; i++)
                    {
                        res=res.Remove(i, 1);
                    }
                }
                oddEven++;
            }
            return res;
        }

        static string B3(string scoreBoard)
        {
            string res = "";
            double[] scores = new double[6];
            int i = 0;
            foreach (var item in scoreBoard.Split(" "))
            {
                scores[i] = Convert.ToDouble(item);
                i++;
            }
            double totalScore = (scores[1] + scores[2])*2 + scores[3] + +scores[4] + scores[5];
            if (totalScore >= scores[0] && scores[1] > 0 && scores[2] > 0 & scores[3] > 0)
            {
                res = "D";
            }
            else
            {
                res = "H";
            }
            
            return res;
        }

        static int B4(string[] input)
        {
            int i = 0;
            int length = 0; // the length of input array
            int ts = 0; // count of contestant
            foreach (var item in input[0].Split(" "))
            {
                if (i == 0)
                {
                    ts = Convert.ToInt32(item);
                }
                if (i == 1)
                {
                    length = Convert.ToInt32(item);
                }
                i++;
            }
            int[] data = new int[length];
            i = 0;
            int[] count = new int[++ts];
            int max = 0;
            foreach (var item in input[1].Split(" "))
            {
                data[i] = Convert.ToInt32(item);
                ++count[data[i]];
                if (max < count[data[i]])
                {
                    max = data[i];
                }
                i++;
            }
            return max;
        }

        static string B5(string input)
        {
            string res = "Lỗi";
            int i = 0;
            int[] data = new int[5];
            foreach (var item in input.Split(" "))
            {
                data[i] = Convert.ToInt32(item);
                i++;
            }

            if (data[2] < 18 && data[2] > 6)
            {
                res = "T";
            }
            else
            {
                int checkNum = data[3] * 60 + data[4];
                if (data[2] <= 6 && data[2] > 0)
                {
                    checkNum += data[2] * 3600;
                }
                if (data[2] >= 18 && data[2] <= 23)
                {
                    checkNum += (data[2] - 18) * 3600;
                }
                checkNum %= (data[0] + data[1] );
                if (checkNum >= 0 && checkNum < data[0])
                {
                    res = "S";
                }
                else
                {
                    res = "T";
                }
            }

            return res;
        }

        static int B6(string[] input)
        {
            int i = 0;
            int length = 0; // the length of input array
            int houses = 0; // count of houses

            foreach (var item in input[0].Split(" "))
            {
                if (i == 0)
                {
                    length = Convert.ToInt32(item);
                }
                if (i == 1)
                {
                    houses = Convert.ToInt32(item);
                }
                i++;
            }

            i = 0;

            int[] data = new int[houses];
            foreach (var item in input[1].Split(" "))
            {
                data[i] = Convert.ToInt32(item);
                i++;
            }
            int max;
            i = 0; int res = 0; max = res;
            for (int a = 0; a < houses; a++)
            {
                int j = a;
                int d = 0;
                while (d < length && j < houses)
                {
                    d += data[j];
                    res++;
                    if (d > length)
                    {
                        d -= data[j];
                        --res;
                    }
                    j++;
                }
                if (max < res && d <= length)
                {
                    max = res;
                }
                res = 0;
            }
            return max;
        }
    }
}

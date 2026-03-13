// See https://aka.ms/new-console-template for more information



//Console.WriteLine("Hello, World!");
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SE1_work1
{


    public class Program
    {
        public static void Main(string[] args)
        {
         

            StringCalculator calc = new StringCalculator();

            //Console.WriteLine(calc.Calculate("1\n2,3"));
            //Console.WriteLine(calc.Calculate("//[###]\n2###3"));
            Console.WriteLine(calc.Calculate("-3"));

        }
    }




    public class StringCalculator
    {
        public int Calculate(string arg)
        {
            if (string.IsNullOrEmpty(arg))
            {
                return 0;
            }

            //int i = 2;

            if (!arg.Contains("//"))
            {



                if (int.TryParse(arg, out int number))
                {
                    if(number > 1000)
                    {
                        return 0;
                    }
                    else if (number < 0)
                    {
                        throw new ArgumentException("Negative numbers are not allowed: " + number);
                    }
                    return number;
                }

                var nums = arg.Replace('\n', ',');




                var numbers = nums.Split(',').Select(int.Parse);

                /*if (numbers.Count() == 2 || numbers.Count() == 3)
                {
                    return numbers.Sum();
                }*/

                int sum = 0;

                foreach (var num in numbers)
                {
                    if (num < 0)
                    {
                        throw new ArgumentException("Negative numbers are not allowed: " + num);
                    }
                    else if (num > 1000)
                    {
                        continue;
                    }
                    sum += num;
                }

                return sum;

            }
            else
            {

                //StringBuilder str = new StringBuilder();

                List<StringBuilder> strList = new List<StringBuilder>();

                /*foreach (char c in arg)
                {
                    if (c == '/') continue;
                    //if (IsNum(c)) continue;

                    str.Append(c);

                    if (IsNum(arg[arg.IndexOf(c) + 1]))
                    {
                        //
                    }
                }*/

                int i = 2;

                while (true)
                {

                    if (arg[i] == '[')
                    {
                        i++;
                        StringBuilder str = Delimiter(arg, ref i);
                        strList.Add(str);
                        i++;
                        if (arg[i] == '\n')
                        {
                            i++;
                            break;
                        }
                    }
                    else
                    {
                        StringBuilder str = new StringBuilder();
                        str.Append(arg[i]);
                        strList.Add(str);
                        i += 2;

                        break;
                    }


                }


               

                String sequense_without_first_line = arg.Substring(i);

                StringBuilder str1 = new StringBuilder(sequense_without_first_line);

                foreach (var str in strList)
                {
                    Console.WriteLine(str);

                    str1.Replace(str.ToString(), ",");

                }



                

                var numbers = str1.ToString().Split(',').Select(int.Parse);

                int sum = 0;

                foreach (var num in numbers)
                {
                    //Console.WriteLine(num);

                    if(num > 1000)
                    {
                        continue;
                    }
                    else if (num < 0)
                    {
                        throw new ArgumentException("Negative numbers are not allowed: " + num);
                    }

                    sum += num;
                }


                return sum;

            }
            return -1;
        }


        public bool IsNum(char c)
        {
            return c >= '0' && c <= '9';
        }


        StringBuilder Delimiter(string arg, ref int index)
        {
            StringBuilder str = new StringBuilder();
            //for (int i = index; i < arg.Length; i++)
            //{
            int i = index;
                    while (arg[i] != ']')
                    {
                        str.Append(arg[i]);
                        i++;
                    }

                index = i;


            //}
            
            return str;
        }

    }
}
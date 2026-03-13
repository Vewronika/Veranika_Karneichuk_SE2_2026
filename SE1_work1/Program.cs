// See https://aka.ms/new-console-template for more information



//Console.WriteLine("Hello, World!");
using System.Text;

namespace SE1_work1
{


    public class Program
    {
        public static void Main(string[] args)
        {
         
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

            if (!arg.Contains("//"))
            {



                if (int.TryParse(arg, out int number))
                {
                    return number;
                }

                var nums = arg.Replace('\n', ',');




                var numbers = nums.Split(',').Select(int.Parse);

                if (numbers.Count() == 2 || numbers.Count() == 3)
                {
                    return numbers.Sum();
                }

            }
            else
            {

                StringBuilder str = new StringBuilder();

                foreach (char c in arg)
                {
                    if (IsNum(c)) continue;

                    str.Append(c);



                    if (IsNum(arg[arg.IndexOf(c) + 1]))
                    {

                    }
                }




            }

            return -1;
        }


        public bool IsNum(char c)
        {
            return c >= '0' && c <= '9';
        }
    }


}
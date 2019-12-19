using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp
{
    class ExtraClass
    {
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        public virtual void PrintInput(params object[] input)
        {
            int i = 0;
            foreach (object element in input)
            {
                Console.WriteLine("the input at index:{0} is: {1}",i, element);
                i++;
            }
        }
    }

    class Extender : ExtraClass
    {
        public override void PrintInput(params object[] input)
        {
            int sum = 0;
            foreach(object element in input)
            {
                
                if (element.GetType() == typeof(int))
                    {
                    sum += (int)element;
                    }
                else
                {
                    Console.WriteLine("Not an int");
                }
            }
            Console.WriteLine("The total value of the ints passed is:{0}", sum);
            
        }
    }
}

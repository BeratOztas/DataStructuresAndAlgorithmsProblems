using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges
{
    public class PlusOne
    {
        public int[] PlusOneMethod(int[] digits)
        {
            int n= digits.Length;
            //1 2 0 
            for(int i=n-1; i>=0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }
                digits[i] = 0;
            }
            int[] newNumber = new int[n + 1];
            newNumber[0] = 1;

            return newNumber;


           
        }
    }
}

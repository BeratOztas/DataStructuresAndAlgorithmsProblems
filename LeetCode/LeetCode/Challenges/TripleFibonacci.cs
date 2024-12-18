using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges.TripleFibonaccis
{
    public class TripleFibonacci
    {
        public int[] TripleFibonac(int n)
        {
            if (n <=1)
                return new int[0];
            // 0 0 1 1 2 4
            else if (n == 2)
                return new int[] { 0, 0 };
            int first = 0;
            int second = 0;
            int third = 1;
            List<int> list = new List<int>();   
            if(n == 3)
            {
                return new int[] {0,0,1};
            }

            if(n >3)
                list.AddRange(new int[] {0,0});

            for (int i = 3; i < n; i++)
            {
                int curr = first + second + third;
                list.Add(curr);
                first = second;
                second = third;
                third = curr;
            }

            return list.ToArray();
        }
        public int[] Tripple(int n) // Time O(n) Space O(n)
         {
            if(n<=1)
                return new int[0];
            int[]array =new int[n+1];
            array[0] = 0;
            array[1] = 0;
            array[2] = 1;

            for(int i = 3; i <= n; i++)
            {
                array[i] = array[i - 3] + array[i - 2] + array[i-1];
            }
            return array;

        }
    }
}

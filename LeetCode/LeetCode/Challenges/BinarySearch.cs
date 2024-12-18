using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges.BinarySearch
{
    public class BinarySearch
    {
         public int Search(int[] nums,int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                //(left + right) / 2;    // WRONG because lo + hi might result in an int overflow
                //lo + (hi - lo) / 2;    // RIGHT, also best performance in .NET
                int mid= left+(right -left)/2; 
                 
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;

            }
            return -1;
        }
    }
}

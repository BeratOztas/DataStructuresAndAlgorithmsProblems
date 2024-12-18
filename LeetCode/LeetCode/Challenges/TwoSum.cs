using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges.TwoSum
{
    public class TwoSums
    {
        // 2,7,11,15   target = 9
        // 3,2,4   target = 6 
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            // 2,7,11,15
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dict.ContainsKey(complement))
                {
                    return new int[] { dict[complement],i };
                }

                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);  
                }
            }
            return new int[0];
        }
        public int[] TwoSumBinarySearch(int[] nums, int target) {
            // IF ARRAY IS SORTED WE CAN USE BINARY SEARCH 
            // NO EXTRA SPACE LIKE HASHTABLE(DICTIONARY) TWO POINTER APPROACH
            int left = 0;
            int right =nums.Length - 1;

            while(left <= right) {
                int sum = nums[left] + nums[right];
                if (sum == target)
                    return new int[] { left + 1, right + 1 };
                else if(sum<target)
                    left++;
                else
                    right--;
            }
            return new int[] { };
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges
{
    public class RotateArray
    {
        public int[] RotateLeft(int[] nums, int k)
        {
            //1 2 3 4 5 6 7 k=3
            //7 6 5 4 3 2 1 
            //4 5 6 7 3 2 1 
            //4 5 6 7 1 2 3 //Reverse last k numbers
            k %= nums.Length;  // k=6 nums.Length=4  2 yani 2 kere dön demek

            rotate(nums, 0, nums.Length - 1);//Reverse all numbers

            rotate(nums, 0, nums.Length - k - 1);//Reverse first nums.Length-k numbers

            rotate(nums, nums.Length - k, nums.Length - 1);

            return nums;

        }
        public int[] RotateRight(int[] nums, int k)
        {
            //Input: nums = [1, 2, 3, 4, 5, 6, 7], k = 3
            //Output: [5,6,7,1,2,3,4]
            //Explanation:
            //rotate 1 steps to the right: [7,1,2,3,4,5,6]
            //rotate 2 steps to the right: [6,7,1,2,3,4,5]
            //rotate 3 steps to the right: [5,6,7,1,2,3,4]
            //1 2 3 4 5 6 7
            //7 6 5 4 3 2 1
            //7 6 5 1 2 3 4
            //5 6 7 1 2 3 4

            rotate(nums, 0, nums.Length - 1);

            rotate(nums, k, nums.Length - 1);

            rotate(nums, 0, k - 1);

            return nums;
        }
        private void rotate(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }
    }
}

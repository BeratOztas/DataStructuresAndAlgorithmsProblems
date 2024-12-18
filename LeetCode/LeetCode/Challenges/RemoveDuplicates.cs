using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges.RemoveDuplicates
{
    public class RemoveDuplicates
    {
        public int RemoveDuplicate(int[] nums)
        {
            // 0,0,1,1,2,2,3,3,4
            int k = 1;
            int prev = nums[0];

            for(int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != prev)
                {
                    nums[k]= nums[i];
                    k++;
                }
                prev= nums[i];
            }
            return k;
        }
    }
}

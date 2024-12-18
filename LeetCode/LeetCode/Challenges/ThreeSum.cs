using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges.ThreeSums;

public class ThreeSum
{
    public IList<IList<int>> threeSum(int[] nums)
    {
        //Input: nums = [-1,0,1,2,-1,-4]
        //Output: [[-1,-1,2],[-1,0,1]]
        //nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        //nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        //nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0
        // Notice that the solution set must not contain duplicate triplets.
        //-1 0 1 2 -1 -4
        //-4 -1 -1 0 1 2
        //-4[-1 -1 0 1 2] 
        IList<IList<int>> result = new List<IList<int>>();
        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            int sum = 0 - nums[i]; //0--4=4 (nums[left]+nums[right])==must be 4 to add up 0
            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right)
            {
                int complement = nums[left] + nums[right];
                if (sum == complement)
                {
                    result.Add(new List<int>() { nums[i], nums[left], nums[right] });
                    while (left < right && nums[left] == nums[left + 1]) left++;
                    while (left < right && nums[right] == nums[right - 1]) right--;
                    left++;
                    right--;
                }
                else if (sum < complement)
                    right--;
                else
                    left++;
            }
        }

        return result;


    }

}

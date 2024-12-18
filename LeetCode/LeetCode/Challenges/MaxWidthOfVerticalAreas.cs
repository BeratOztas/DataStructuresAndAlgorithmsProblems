using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges.MaxWidthOfVerticalAreas
{
    public class MaxWidthOfVerticalAreas
    {
        public int MaxWidthOfVerticalArea(int[][] points)
        {
            List<int> xPoints = new List<int>();

            foreach (int[] item in points)
            {
                xPoints.Add(item[0]);
            }
            xPoints.Sort();


            int max = 0;

            for (int i = 1; i < xPoints.Count; i++)
            {
                max = Math.Max(max, xPoints[i] - xPoints[i - 1]);
            }

            return max;

        }
        public int MaximumWealth(int[][] accounts)
        {
            int max = 0;
            foreach (int[] i in accounts)
            {
                max = Math.Max(i.Sum(), max);
            }
            return max;
        }
        public int returnMax(int[] candies)
        {
            int greatestCandie = candies[0];
            for (int i = 1; i < candies.Length; i++)
            {
                if (candies[i] >= greatestCandie)
                    greatestCandie = candies[i];
            }
            return greatestCandie;
        }
        
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges.TopKFrequents

{
    public class TopKFrequentSol
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            List<int>[] bucket = new List<int>[nums.Length + 1];
            // 1 1 2 2 3
            // freq (1,2) (2,2) (3,1)
            // Bucket =
            foreach (int i in nums)
            {
                if (dict.ContainsKey(i))
                    dict[i]++;
                else
                    dict.Add(i, 1);
            }

            foreach (var item in dict)
            {
                int freq = item.Value;
                if (bucket[freq] == null)
                {
                    bucket[freq] = new List<int>();
                }
                bucket[freq].Add(item.Key);
            }

            List<int> result = new List<int>();

            for (int i = bucket.Length - 1; i >= 0 && result.Count < k; i--)
            {
                if (bucket[i] != null)
                    result.AddRange(bucket[i]);
            }
            return result.ToArray();

        }
    }
}

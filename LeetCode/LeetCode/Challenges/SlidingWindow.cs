using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges.SlidingWindow
{
    public class SlidingWindow
    {
        public double MaximumAverageSubArray(int[] nums, int k)
        {
            // Input :{1,12,-5,-6,50,3} k=4  
            // Output = 12.75   ,   (12-5-6+50) / 4 =12.75
            int sum = 0;
            for (int i = 0; i < k; i++)
                sum += nums[i];
            int startIndex = 0;
            int endIndex = k;
            int maxSum = sum;

            while (endIndex < nums.Length)
            {
                sum -= nums[startIndex];
                startIndex++;

                sum += nums[endIndex];
                endIndex++;

                maxSum = Math.Max(maxSum, sum);
            }
            return (double)maxSum / k;

        }
        public int SubArrayDivision(int[] nums, int d, int m)
        {
            //[2,2,1,3,2]                            [1,4,4]
            // d=4 m =2                              d=4 m =1
            //Output : 2   [2,2],[1,3]               Output =1
            int low = 0;
            int high = m;
            int bar = 0;
            int sum = 0;

            for (int i = 0; i < high; i++)
            {
                sum += nums[i];
            }
            if (sum == d)
                bar++;

            while (high < nums.Length)
            {
                sum -= nums[low];
                low++;
                sum += nums[high];
                high++;
                if (sum == d)
                    bar++;
            }
            return bar;
        }
        public bool ContainsNearByDuplicate(int[] nums, int k)
        {
            //Input :[1,2,3,1] k =3           Input:[1,2,3,1,2,3] k =2   Input : [1,0,1,1]   k=1
            //Output : true                   Output : false             Output : true
            HashSet<int> set = new HashSet<int>();
            int left = 0;

            for (int r = 0; r < nums.Length; r++)
            {
                if ((r - left) > k)
                {
                    set.Remove(nums[left]);
                    left++;
                }
                if (!set.Contains(nums[r]))
                {
                    set.Add(nums[r]);
                }
                else
                {
                    return true;
                }
            }
            return false;

        }
        public int LongestSubstringWithoutRepatingCharacter(string s)
        {
            // Input s="abcabcbb"         Input s ="bbbbbbb"
            // Output =3 , abc              Output = 1  , b
            if (s == null)
                return 0;
            HashSet<char> set = new HashSet<char>();
            int startIndex = 0;
            int endIndex = 0;
            int max = 0;

            while (endIndex < s.Length)
            {
                if (!set.Contains(s[endIndex]))
                {
                    set.Add(s[endIndex]);
                    endIndex++;
                    int currentWindowSize = (endIndex - startIndex);
                    max = Math.Max(max, currentWindowSize);
                }
                else
                {
                    set.Remove(s[startIndex]);
                    startIndex++;
                }
            }
            return max;
        }

        public int MinSubArrayLen(int target, int[] nums)
        {
            int minLenWindow = int.MaxValue;
            int currentSum = 0;

            //SLIDING WINDOW TWO POINTERS
            int low = 0;
            int high = 0;

            while (high < nums.Length)
            {
                currentSum += nums[high];
                high++;

                while (currentSum >= target)
                {
                    int currentWindowSize = high - low;
                    minLenWindow = Math.Min(minLenWindow, currentWindowSize);
                    currentSum -= nums[low];
                    low++;
                }
            }
            return minLenWindow == int.MaxValue ? 0 : minLenWindow;
        }

        public string MinWindowSubstring(string s, string t)
        {
            //Input: s = "ADOBECODEBANC", t = "ABC"
            //Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.
            //Output: "BANC"

            //Input: s = "a", t = "aa"
            //Output: ""
            //Explanation: Both 'a's from t must be included in the window.
            //Since the largest window of s only has one 'a', return empty string.

            if (s.Length == 0 || t.Length == 0)
                return "";

            Dictionary<char, int> countT = new Dictionary<char, int>();
            Dictionary<char, int> window = new Dictionary<char, int>();

            foreach (char c in t)
            {
                countT[c] = countT.GetValueOrDefault(c, 0) + 1; //Get t Frequence
            }

            int low = 0;
            int high = 0;
            int minWindowLen = int.MaxValue;

            int have = 0;
            int need = countT.Count;
            int start = 0;

            while (high < s.Length)
            {
                char c = s[high];
                window[c] = window.GetValueOrDefault(c, 0) + 1;
                if (countT.ContainsKey(c) && window[c] == countT[c])
                {
                    have++;
                }
                while (have == need)
                {
                    if((high -low +1) < minWindowLen)
                    {
                        minWindowLen = (high - low + 1);
                        start = low;
                    }
                    char leftChar = s[low];
                    window[leftChar]--;

                    if (countT.ContainsKey(leftChar) && window[leftChar] < countT[leftChar])
                    {
                        have--;
                    }
                    low++;
                }
                high++;
            }

            return minWindowLen == int.MaxValue ? "" : s.Substring(start, minWindowLen);

        }


    }
}

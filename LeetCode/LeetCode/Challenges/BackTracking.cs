using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges.BackTrack
{
    public class BackTracking
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> resultList = new List<IList<int>>();

            backTrack(resultList, new List<int>(), nums, 0);
            return resultList;
        }
        //Yes, backtracking is DFS, it will first go deep on one node then will backtrack when all options are over and continue to next branch
        private void backTrack(IList<IList<int>> resultSets, List<int> tempSet, int[] nums, int start)
        {
            //Add the set to result set 1,2
            Console.Write("Subset : ");
            foreach (int i in tempSet)
                Console.Write(i);
            Console.WriteLine();
            resultSets.Add(new List<int>(tempSet));
            for (int i = start; i < nums.Length; i++)
            {
                //Case of including the number
                tempSet.Add(nums[i]);

                //Backtrack the new subset
                backTrack(resultSets, tempSet, nums, i + 1);

                //Case of not-including the number
                tempSet.RemoveAt(tempSet.Count - 1);
            }
        }
        public IList<IList<int>> Subsets2(int[] nums)
        {
            IList<IList<int>> resultList = new List<IList<int>>();
            Array.Sort(nums);
            backTrackWithoutDuplicate(resultList, new List<int>(), nums, 0);
            return resultList;
        }
        private void backTrackWithoutDuplicate(IList<IList<int>> resultsSets, List<int> tempSet, int[] nums, int start)
        {

            resultsSets.Add(new List<int>(tempSet));

            for (int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1])
                    continue;
                tempSet.Add(nums[i]);

                backTrackWithoutDuplicate(resultsSets, tempSet, nums, i + 1);

                tempSet.RemoveAt(tempSet.Count - 1);
            }
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> resultList = new List<IList<int>>();
            backTrackPermutation(resultList, new List<int>(), nums);
            return resultList;
        }

        private void backTrackPermutation(IList<IList<int>> resultList, List<int> tempList, int[] nums)
        {
            //If we match the length , it is a permutation
            if (tempList.Count == nums.Length)
            {
                resultList.Add(new List<int>(tempList));
                return;
            }
            foreach (int number in nums)
            {
                //Skip if we get same element
                if (tempList.Contains(number))
                    continue;

                //Add the new element
                tempList.Add(number);

                //Go back to try other element
                backTrackPermutation(resultList, tempList, nums);
                //Remove the element
                tempList.RemoveAt(tempList.Count - 1);
            }
        }

        public IList<string> GenerateParentheses(int n)
        {
            //Input n = 3
            // Output list[
            // "((()))"
            // "(())()"
            // "()(())"
            // "(()())" 
            // "()()()"
            List<string> list = new List<string>();
            backTrackParenteheses(list, "", 0, 0, n);
            return list;
        }

        private void backTrackParenteheses(List<string> list, string currentStr, int open, int close, int max)
        {
            if (currentStr.Length == max * 2)
            {
                list.Add(currentStr);
                return;
            }
            if (open < max) backTrackParenteheses(list, currentStr + "(", open + 1, close, max);
            if (close < open) backTrackParenteheses(list, currentStr + ")", open, close + 1, max);
        }

        public IList<string> LetterCombinations(string digits)
        {
            //Input: digits = "23"                                              Input: digits = ""               Input: digits = "2"
            //Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]            Output: []                       Output: ["a","b","c"]
            List<string> result = new List<string>();
            Dictionary<char,string> digitsToChar = new Dictionary<char,string>()
            {
                {'2',"abc"},
                {'3',"def"},
                {'4',"ghi"},
                {'5',"jkl"},
                {'6',"mno"},
                {'7',"pqrs"},
                {'8',"tuv"},
                {'9',"wxyz"},
            };

            if(!string.IsNullOrEmpty(digits))
            backTrackLetter(result,"",digitsToChar,digits,0);
            return result;
        }

        private void backTrackLetter(List<string> result,string currentStr,Dictionary<char,string> dict,string digits,int index)
        {
            if (currentStr.Length==digits.Length)
            {
                result.Add(currentStr);
                return;
            }
            string current = dict[digits[index]];
            foreach(char c in current)
            {
                backTrackLetter(result, currentStr + c, dict, digits, index+1);
            }
        }
    }
}

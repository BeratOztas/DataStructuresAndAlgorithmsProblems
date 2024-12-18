using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges.Maximumnumberofwords
{
    public class Maximum_number_of_words
    {
    public int MostWordsFound(string[] sentences)
    {
        string[][] sentencesList = new string[sentences.Length][];
        int max = 0;
        for (int i = 0; i < sentences.Length; i++)
        {
            sentencesList[i] = sentences[i].Split(" ");
        }

        
        for (int i = 0; i < sentencesList.Length; i++)
        {
            max = Math.Max(max, sentencesList[i].Length);
        }
        return max;
    }
}
}

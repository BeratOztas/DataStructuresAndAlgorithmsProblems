using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challanges.IsValid;

public class IsValidSolution
{
    public bool IsValid(string s)
    {
        Stack<char> stackBrackets = new Stack<char>();
        foreach (char c in s)
        {
            if (c == '(')
                stackBrackets.Push(')');
            else if (c == '{')
                stackBrackets.Push('}');
            else if (c == '[')
                stackBrackets.Push(']');
            else if (stackBrackets.Count == 0 || stackBrackets.Pop() != c) //otherwise char is close bracket so we pop from the stack
                return false;
        }
        return stackBrackets.Count == 0;
    }

    public string FirstReverse(string str)
    {
        if (str == null)
            return null;

        string empty = "";
        int ptr = str.Length - 1;

        while (ptr > -1)
        {
            empty += str[ptr];
            ptr--;
        }
        return empty;
    }
    public bool IsSubsequence(string s, string t)
    {
        //Input: s = "abc", t = "ahbgdc"             Input: s = "axc", t = "ahbgdc"
        //Output: true                               Output: false
        int i = 0;
        int j = 0;

        while (i < s.Length && j < t.Length)
        {
            if (s[i] == t[j])
            {
                i++;
                j++;
            }
            else
                j++;
        }
        return i == s.Length ? true : false;
    }

    public bool ValidPalindrome2(string s)
    {
        //Input: s = "aba"           Input: s = "abca" Explanation: You could delete the character 'c'.       Input: s = "abc"
        //Output: true               Output: true                                                             Output: false
        int left = 0;
        int right = s.Length - 1;
        //rotatxor
        //x == t   eithor true    roatxor || rotator then return true    atx   || tat 
        while (left < right)
        {
            if (s[left] == s[right])
            {
                left++;
                right--;
            }
            else
            {
                return HelperPalindrome(s, left + 1, right) || HelperPalindrome(s, left, right - 1);
            }
        }
        return true;

    }

    public bool HelperPalindrome(string s, int left, int right)
    {
        while (left < right)
        {
            if (s[left] == s[right])
            {
                left++;
                right--;
            }
            else
                return false;
        }
        return true;
    }


    public bool IsPalindrome(string s)
    {
        string str = "";
        foreach (char c in s)
        {
            if (Char.IsLetter(c) || Char.IsNumber(c))
                str += c;
        }
        str = str.ToLower();
        //ana
        int left = 0;
        int right = str.Length - 1;
        while (left < right)
        {
            if (str[left] != str[right])
                return false;
            left++;
            right--;
        }
        return true;
    }
}


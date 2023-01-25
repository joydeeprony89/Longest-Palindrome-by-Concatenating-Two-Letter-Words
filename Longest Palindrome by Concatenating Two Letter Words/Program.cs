// See https://aka.ms/new-console-template for more information



// https://www.youtube.com/watch?v=Q9EhdRmisVU&t=1492s
var words = new string[] { "ab", "ty", "yt", "lc", "cl", "ab" };
Solution s = new Solution();
var answer = s.LongestPalindrome(words);  
Console.WriteLine(answer);

public class Solution
{
  public int LongestPalindrome(string[] words)
  {
    // "lc","cl","gg", "lc" , "bb"
    // step 1 create a frequency map using words array - [lc:2, cl:1, gg:1, bb:1]
    // Step 2 - loop throught the words array 
    //  a. for each word, reverse it, and of word and reversed word are not same 
    // e.g - lc ~ cl, if both have frequency gt 0, we can use one one each word, "lc cl", after use reduce frequncy by one
    // also add +4 to result.
    // [lc:1, cl:0, gg:1, bb:1]
    // for next word "cl" ~ "lc", we check the frequncy of both, lc > 0 but cl == 0, so we can not use "cl" 
    //  b. when word ~ rev are same , e.g - "gg" ~ "gg", we check if the count >= 2, reduce -2 from map frequency and also add +4 in result
    // c. when count is one we can only use one at the middle and it is only allowed one time ,so will be keeping a bool flag, isCentreUsed as false, when we find a word with same char with frequncey 1, this word will be used at the centre and no more similar kind of word with same frequency will be allowed

    // step 1
    Dictionary<string, int> freq = new Dictionary<string, int>();
    foreach (string word in words)
    {
      if (!freq.ContainsKey(word)) freq.Add(word, 0);
      freq[word]++;
    }

    bool isCentreUsed = false;
    int result = 0;
    // step 2
    foreach (string word in words)
    {
      var rev = new string(word.Reverse().ToArray());
      // b.
      if (word.Equals(rev))
      {
        if (freq[word] >= 2)
        {
          freq[word] -= 2; result += 4;
        }
        else if (freq[word] == 1 && !isCentreUsed)
        {
          // c.
          isCentreUsed = true;
          result += 2; freq[word] -= 1;
        }
      }
      else
      {
        // a.
        if (freq.ContainsKey(rev) && freq[word] > 0 && freq[rev] > 0)
        {
          freq[word] -= 1;
          freq[rev] -= 1;
          result += 4;
        }
      }
    }

    return result;
  }
}

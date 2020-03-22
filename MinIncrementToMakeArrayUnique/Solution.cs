// Question 945. Minimum Increment to Make Array Unique (https://leetcode-cn.com/problems/minimum-increment-to-make-array-unique/)
// Difficulty: Medium

public class Solution
{
    public int MinIncrementForUnique(int[] A)
    {
        if (A.Count() == 0) { return 0; }

        Dictionary<string, int> intCount = new Dictionary<string, int>();

        // Count frequency of int in the array.
        foreach (int a in A)
        {
            string aString = a.ToString();
            if (intCount.ContainsKey(aString))
            {
                intCount[aString] += 1;
            }
            else
            {
                intCount[aString] = 1;
            }
        }

        int totalIncremental = 0;

        while (intCount.Values.Distinct().Count() != 1 || intCount.Values.Distinct().ToArray()[0] != 1)
        {

            int numToIncrement = int.Parse(intCount.Where(d => d.Value > 1).Select(d => d.Key).First());

            intCount[numToIncrement.ToString()] -= 1;

            string incrementedNum = (numToIncrement + 1).ToString();
            if (intCount.ContainsKey(incrementedNum))
            {
                intCount[incrementedNum] += 1;
            }
            else
            {
                intCount[incrementedNum] = 1;
            }

            totalIncremental++;
        }

        return totalIncremental;
    }
}
// Question 228. Summary Ranges (https://leetcode-cn.com/problems/summary-ranges/)

/// <summary>
/// 执行用时：288 ms, 在所有 C# 提交中击败了 63.16% 的用户
/// 内存消耗：29.8 MB, 在所有 C# 提交中击败了 85.96% 的用户
/// </summary>
public class Solution
{
    public IList<string> SummaryRanges(int[] nums)
    {
        IList<string> ranges = new List<string>();

        int N = nums.Count();

        if (N == 0) { return ranges; }

        int startOfRange = nums[0];
        int lastOfRange = nums[0];
        int num = nums[0];
        for (var i = 1; i < N; i++)
        {
            num = nums[i];
            if (num == lastOfRange + 1)
            {
                lastOfRange = num;
            }
            else
            {
                string range = "";
                if (startOfRange == lastOfRange)
                {
                    range = startOfRange.ToString();
                }
                else
                {
                    range = $"{startOfRange}->{lastOfRange}";
                }

                ranges.Add(range);
                startOfRange = num;
                lastOfRange = num;
            }
        }

        if (num == lastOfRange + 1)
        {
            lastOfRange = num;
        }
        else
        {
            string range = "";
            if (startOfRange == lastOfRange)
            {
                range = startOfRange.ToString();
            }
            else
            {
                range = $"{startOfRange}->{lastOfRange}";
            }

            ranges.Add(range);
            startOfRange = num;
            lastOfRange = num;
        }

        return ranges;
    }
}
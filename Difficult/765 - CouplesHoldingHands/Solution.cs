// Question 765. Couples Holding Hands (https://leetcode-cn.com/problems/couples-holding-hands/)

/// <summary>
/// 执行用时：104 ms, 在所有 C# 提交中击败了 77.14% 的用户
/// 内存消耗：24.4 MB, 在所有 C# 提交中击败了 5.72% 的用户
/// 
/// Acknowledgement: This solution borrows idea from 
/// [this explanation](https://leetcode-cn.com/problems/couples-holding-hands/solution/liang-chong-100-de-jie-fa-bing-cha-ji-ta-26a6/)
/// </summary>
public class Solution 
{
    private int[] _row;
    
    public int MinSwapsCouples(int[] row) 
    {
        this._row = row;
        int N = row.Count();

        Dictionary<int, int> personIndexMap = new Dictionary<int, int>();
        for (int i = 0; i < N; i++) { personIndexMap[row[i]] = i; }

        int answer = 0;
        for (int i = 0; i < N - 1; i += 2)
        {
            int personAValue = this._row[i];
            int personBValue = personAValue ^ 1;

            if (this._row[i + 1] != personBValue) 
            {
                int source = i + 1;
                int target = personIndexMap[personBValue];

                personIndexMap[this._row[target]] = source;
                personIndexMap[this._row[source]] = target;

                this.Swap(target, source);
                answer++;
            }
        }

        return answer;
    }

    private void Swap(int sourceIndex, int targetIndex)
    {
        var temp = this._row[sourceIndex];
        this._row[sourceIndex] = this._row[targetIndex];
        this._row[targetIndex] = temp;
    }
}
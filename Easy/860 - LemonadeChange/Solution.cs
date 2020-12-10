// Question 860. Lemonade Change (https://leetcode-cn.com/problems/lemonade-change/)

/// <summary>
/// 执行用时：144 ms, 在所有 C# 提交中击败了 9.43% 的用户
/// 内存消耗：28.6 MB, 在所有 C# 提交中击败了 26.92% 的用户
/// </summary>
public class Solution 
{
    private readonly int LEMONADE_PRICE = 5;

    private Dictionary<int, int> changeCount;
    
    public bool LemonadeChange(int[] bills) 
    {
        this.changeCount = new Dictionary<int, int>();

        if (bills[0] != LEMONADE_PRICE) { return false; }

        int BILL_COUNT = bills.Count();
        for (int i = 0; i < BILL_COUNT; i++)
        {
            int bill = bills[i];

            if (bill == 20)
            {
                if (this.GetOrDefault(10) > 0 && this.GetOrDefault(5) > 0)
                {
                    this.changeCount[10]--;
                    this.changeCount[5]--;
                    this.changeCount[20] = this.GetOrDefault(20) + 1;
                }
                else if (this.GetOrDefault(5) >= 3)
                {
                    this.changeCount[5] -= 3;
                    this.changeCount[20] = this.GetOrDefault(20) + 1;
                }
                else 
                {
                    return false;
                }
            }
            else if (bill == 10)
            {
                if (this.GetOrDefault(5) > 0)
                {
                    this.changeCount[5]--;
                    this.changeCount[10] = this.GetOrDefault(10) + 1;
                }
                else
                {
                    return false;
                }
            } 
            else
            {
                this.changeCount[5] = this.GetOrDefault(5) + 1;
            }
        }

        return true;
    }

    private int GetOrDefault(int price, int defaultValue = 0)
    {
        if (this.changeCount.ContainsKey(price)) { return this.changeCount[price]; }

        return defaultValue;
    }
}
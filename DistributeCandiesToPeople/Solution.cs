
/// Question 1103. Distribute Candies to People
/// Difficulty: Easy
/// 执行用时: 340 ms, 在所有 C# 提交中击败了 60.00% 的用户
/// 内存消耗: 24 MB, 在所有 C# 提交中击败了 100.00% 的用户

public class Solution {
    public int[] DistributeCandies(int candies, int num_people) {
        int[] candiesDistribution = new int[num_people];
        int currentIndex = 0;
        
        while (candies != 0) {
            int currentIteration = currentIndex / num_people;
            int relativeIndex = currentIndex % num_people;
                        
            int expectedCandiesToDistribute = currentIteration * num_people + relativeIndex + 1;
            int candiesToDistribute = candies > expectedCandiesToDistribute ? expectedCandiesToDistribute : candies;
            candiesDistribution[relativeIndex] += candiesToDistribute;
            
            candies -= candiesToDistribute;
            currentIndex++;
        }

        return candiesDistribution;
    }
}

/// Question 1103. Distribute Candies to People
/// Difficulty: Easy

public class Solution {
    public int[] DistributeCandies(int candies, int num_people) {
        return DistributeCandiesFirstTry(candies, num_people);
    }

    public int[] DistributeCandiesFirstTry(int candies, int num_people) {
        /// 执行用时: 240 ms, 在所有 C# 提交中击败了 66.67% 的用户
        /// 内存消耗: 25.7 MB, 在所有 C# 提交中击败了 25.00% 的用户

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

    public int[] DistributeCandiesSecondTry(int candies, int num_people) {
        /// 执行用时: 332 ms
        /// 内存消耗: 25.7 MB
        int remainingCandies = candies;
        int[] distributedCandies = new int[num_people];
        int iterationCount = 0;

        while (remainingCandies > 0) {
            for (int i = 0; i < num_people; i++) {
                int expectedCandies = iterationCount * num_people + i + 1;
                int candiesToDistribute = expectedCandies > remainingCandies ? remainingCandies : expectedCandies;

                remainingCandies -= candiesToDistribute;
                
                distributedCandies[i] += candiesToDistribute;
            }
            iterationCount++;
        }

        return distributedCandies;
    }

    public int[] DistributeCandiesThirdTry(int candies, int num_people) {
        /// 执行用时: 244 ms, 在所有 C# 提交中击败了 53.33% 的用户
        /// 内存消耗: 25.6 MB, 在所有 C# 提交中击败了 25.00% 的用户
        int[] distributedCandies = new int[num_people];
        int iterationCount = 0;

        while (candies > 0) {
            for (int i = 0; i < num_people; i++) {
                int expectedCandies = iterationCount * num_people + i + 1;
                int candiesToDistribute = expectedCandies > candies ? candies : expectedCandies;

                candies -= candiesToDistribute;
                
                distributedCandies[i] += candiesToDistribute;
            }
            iterationCount++;
        }

        return distributedCandies;
    }
}
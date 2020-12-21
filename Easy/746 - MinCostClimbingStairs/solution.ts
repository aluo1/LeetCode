// Question 746. Min Cost Climbing Stairs (https://leetcode-cn.com/problems/min-cost-climbing-stairs/)

/**
 * 执行用时：92 ms, 在所有 TypeScript 提交中击败了 88.89% 的用户
 * 内存消耗：40.7 MB, 在所有 TypeScript 提交中击败了 44.44% 的用户
 *
 * @param {number[]} cost
 * @returns {number}
 */
function minCostClimbingStairs(cost: number[]): number {
  const N: number = cost.length;
  const dp: number[] = [0, 0];

  for (let i = 2; i <= N; i++) {
    dp[i] = Math.min(dp[i - 2] + cost[i - 2], dp[i - 1] + cost[i - 1]);
  }

  return dp[N];
}

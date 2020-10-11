// Question 416. Partition Equal Subset Sum (https://leetcode-cn.com/problems/partition-equal-subset-sum/)

/**
 * 执行用时：480 ms, 在所有 typescript 提交中击败了 11.11% 的用户
 * 内存消耗：64.7 MB, 在所有 typescript 提交中击败了 16.67% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/partition-equal-subset-sum/solution/fen-ge-deng-he-zi-ji-by-leetcode-solution/)
 *
 * Todo: Work through the 2nd solution again, and work through the solution independently without refering to the official solution.
 * 
 * @param {number[]} nums
 * @returns {boolean}
 */
function canPartition(nums: number[]): boolean {
  const N: number = nums.length;
  if (N < 2) {
    return false;
  }

  let sum: number = 0;
  let maxNum: number = -1;
  for (let num of nums) {
    sum += num;
    maxNum = Math.max(num, maxNum);
  }

  // Sum is odd number, and therefore cannot be partitioned to get equal number.
  if (sum % 2) {
    return false;
  }

  const TARGET: number = Math.floor(sum / 2);
  if (maxNum > TARGET) {
    return false;
  }

  const dp: boolean[][] = [];
  for (let i = 0; i < N; i++) {
    dp.push([true]);
  }

  dp[0][nums[0]] = true;
  for (let i = 1; i < N; i++) {
    const num = nums[i];

    for (let j = 1; j <= TARGET; j++) {
      if (j >= num) {
        dp[i].push((dp[i - 1][j] ?? false) || (dp[i - 1][j - num] ?? false));
      } else {
        dp[i].push(dp[i - 1][j] ?? false);
      }
    }
  }

  return dp[N - 1][TARGET];
}

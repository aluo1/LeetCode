// Question 561. Array Partition I (https://leetcode-cn.com/problems/array-partition-i/)

/**
 * 执行用时：148 ms, 在所有 TypeScript 提交中击败了 92.86% 的用户
 * 内存消耗：46 MB, 在所有 TypeScript 提交中击败了 21.43% 的用户
 *
 * @param {number[]} nums
 * @returns {number}
 */
function arrayPairSum(nums: number[]): number {
  return nums
    .sort((a, b) => a - b)
    .filter((_, index) => index % 2 === 0)
    .reduce((prev, current) => prev + current, 0);
}

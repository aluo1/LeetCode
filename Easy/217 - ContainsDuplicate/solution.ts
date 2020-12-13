// Question 217. Contains Duplicate (https://leetcode-cn.com/problems/contains-duplicate/)

/**
 * 执行用时：96 ms, 在所有 TypeScript 提交中击败了 68.22% 的用户
 * 内存消耗：44.4 MB, 在所有 TypeScript 提交中击败了 39.51% 的用户
 *
 * @param {number[]} nums
 * @returns {boolean}
 */
function containsDuplicate(nums: number[]): boolean {
  return nums.length !== [...new Set(nums)].length;
  // return nums.length !== new Set(nums).size; // We do not need to convert set to array in this case.
}

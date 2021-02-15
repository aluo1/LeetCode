// Question 485. Max Consecutive Ones (https://leetcode-cn.com/problems/max-consecutive-ones/)

/**
 * 执行用时：92 ms, 在所有 TypeScript 提交中击败了 88.89% 的用户
 * 内存消耗：41.6 MB, 在所有 TypeScript 提交中击败了 55.56% 的用户
 *
 * @param {number[]} nums
 * @returns {number}
 */
function findMaxConsecutiveOnes(nums: number[]): number {
  let maxLength: number = 0;
  let currentLength: number = 0;
  let N: number = nums.length;

  for (let index = 0; index < N; index++) {
    if (nums[index] === 1) {
      currentLength++;
    } else {
      maxLength = Math.max(currentLength, maxLength);
      currentLength = 0;
    }
  }

  maxLength = Math.max(currentLength, maxLength);

  return maxLength;
}

/// Question 724. Find Pivot Index

/**
 * 执行用时：100 ms, 在所有 TypeScript 提交中击败了 94.12% 的用户
 * 内存消耗：41.1 MB, 在所有 TypeScript 提交中击败了 88.24% 的用户
 *
 * @param {number[]} nums
 * @returns {number}
 */
function pivotIndex(nums: number[]): number {
  const sum: number = nums.reduce((prev, current) => prev + current, 0);
  let leftSum: number = 0;

  for (let index = 0; index < nums.length; index++) {
    const num: number = nums[index];

    if (leftSum === sum - leftSum - num) {
      return index;
    }

    leftSum += num;
  }

  return -1;
}

// Question 665. Non-decreasing Array (https://leetcode-cn.com/problems/non-decreasing-array/)

/**
 * 执行用时：120 ms, 在所有 TypeScript 提交中击败了 8.00% 的用户
 * 内存消耗：40.5 MB, 在所有 TypeScript 提交中击败了 100.00% 的用户
 *
 * @param {number[]} nums
 * @returns {boolean}
 */
function checkPossibility(nums: number[]): boolean {
  let elementModified: boolean = false;

  for (let index = 0; index < nums.length - 1; index++) {
    const x = nums[index];
    const y = nums[index + 1];

    if (x > y) {
      if (elementModified) {
        return false;
      }
      elementModified = true;
      if (index > 0 && nums[index - 1] > y) {
        nums[index + 1] = x;
      }
    }
  }

  return true;
}

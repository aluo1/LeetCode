// Question 283. Move Zeroes (https://leetcode-cn.com/problems/move-zeroes/)

/**
 * Do not return anything, modify nums in-place instead.
 *
 * 执行用时：100 ms, 在所有 typescript 提交中击败了 35.00% 的用户
 * 内存消耗：41 MB, 在所有 typescript 提交中击败了 5.11% 的用户
 */
function moveZeroes(nums: number[]): void {
  const N: number = nums.length;
  let left: number = 0;
  let right: number = 0;

  while (right < N) {
    if (nums[right]) {
      [nums[left], nums[right]] = [nums[right], nums[left]];
      left++;
    }

    right++;
  }
}

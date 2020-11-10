// Question 31. Next Permutation (https://leetcode-cn.com/problems/next-permutation/)

/**
 * Do not return anything, modify nums in-place instead.
 *
 * 执行用时：108 ms, 在所有 typescript 提交中击败了 15.38% 的用户
 * 内存消耗：40 MB, 在所有 typescript 提交中击败了 26.92% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/next-permutation/solution/xia-yi-ge-pai-lie-by-leetcode-solution/).
 */
function nextPermutation(nums: number[]): void {
  const N: number = nums.length;
  if (N === 1) {
    return;
  }

  let left: number = N - 2;
  let right: number = N - 1;
  while (left >= 0 && nums[left] >= nums[right]) {
    left--;
    right--;
  }

  if (left >= 0) {
    for (right = N - 1; right >= 0; right--) {
      if (nums[right] > nums[left]) {
        [nums[left], nums[right]] = [nums[right], nums[left]];
        break;
      }
    }
  }

  left++;
  right = N - 1;
  while (left < right) {
    [nums[left], nums[right]] = [nums[right], nums[left]];
    left++;
    right--;
  }
}

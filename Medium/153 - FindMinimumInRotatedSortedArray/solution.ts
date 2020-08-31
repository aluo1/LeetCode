/**
 * Question 153. Find Minimum in Rotated Sorted Array (https://leetcode-cn.com/problems/find-minimum-in-rotated-sorted-array/)
 *
 * 执行用时：88 ms, 在所有 typescript 提交中击败了 24.24% 的用户
 * 内存消耗：37.8 MB, 在所有 typescript 提交中击败了 40.00% 的用户
 *
 * @param {number[]} nums
 * @returns {number}
 */
function findMin(nums: number[]): number {
  if (nums.length === 1) {
    return nums[0];
  }

  let left: number = 0;
  let right: number = nums.length - 1;

  // no rotation.
  if (nums[left] < nums[right]) {
    return nums[left];
  }

  while (left <= right) {
    let mid: number = Math.round(left + (right - left) / 2);

    if (nums[mid] > nums[mid + 1]) {
      return nums[mid + 1];
    }

    if (nums[mid - 1] > nums[mid]) {
      return nums[mid];
    }

    if (nums[mid] > nums[left]) {
      left = mid;
    } else {
      right = mid - 1;
    }
  }

  return -1;
}

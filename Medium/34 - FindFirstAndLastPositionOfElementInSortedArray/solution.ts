// Question 34. Find First and Last Position of Element in Sorted Array (https://leetcode-cn.com/problems/find-first-and-last-position-of-element-in-sorted-array/)

/**
 * 执行用时：76 ms, 在所有 typescript 提交中击败了 94.64% 的用户
 * 内存消耗：41.4 MB, 在所有 typescript 提交中击败了 41.07% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/find-first-and-last-position-of-element-in-sorted-array/solution/zai-pai-xu-shu-zu-zhong-cha-zhao-yuan-su-de-di-3-4/)
 *
 * @param {number[]} nums
 * @param {number} target
 * @returns {number[]}
 */
function searchRange(nums: number[], target: number): number[] {
  const startIndex: number = binarySearchIndex(nums, target, true);
  const endIndex: number = binarySearchIndex(nums, target, false) - 1;

  if (
    startIndex <= endIndex &&
    endIndex < nums.length &&
    nums[startIndex] === target &&
    nums[endIndex] === target
  ) {
    return [startIndex, endIndex];
  }

  return [-1, -1];
}

function binarySearchIndex(
  nums: number[],
  target: number,
  lower: boolean
): number {
  const N: number = nums.length;

  let left: number = 0;
  let right = N - 1;
  let answer = N;

  while (left <= right) {
    let mid: number = Math.floor((left + right) / 2);

    if (nums[mid] > target || (lower && nums[mid] >= target)) {
      right = mid - 1;
      answer = mid;
    } else {
      left = mid + 1;
    }
  }

  return answer;
}

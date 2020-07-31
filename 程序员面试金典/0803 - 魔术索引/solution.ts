/// 面试题 08.03. 魔术索引 (https://leetcode-cn.com/problems/magic-index-lcci/)

/**
 * 执行用时：72 ms, 在所有 typescript 提交中击败了 66.66% 的用户
 * 内存消耗：38.8 MB, 在所有 typescript 提交中击败了 100.00% 的用户
 *
 * @param {number[]} nums
 * @returns {number}
 */
function findMagicIndex(nums: number[]): number {
  for (let i = 0; i < nums.length; i++) {
    if (i === nums[i]) {
      return i;
    }
  }

  return -1;
}

/**
 * 执行用时： 84 ms, 在所有 typescript 提交中击败了 33.33% 的用户
 * 内存消耗： 38.8 MB, 在所有 typescript 提交中击败了 100.00% 的用户
 *
 * @param {number[]} nums
 * @returns {number}
 */
function findMagicIndexRecursion(nums: number[]): number {
  return getAnswer(nums, 0, nums.length - 1);
}

function getAnswer(nums: number[], left: number, right: number): number {
  if (left > right) {
    return -1;
  }

  const mid = Math.floor((right - left) / 2) + left;
  const leftValue = getAnswer(nums, left, mid - 1);

  if (leftValue !== -1) {
    return leftValue;
  } else if (mid === nums[mid]) {
    return mid;
  } else {
    return getAnswer(nums, mid + 1, right);
  }
}

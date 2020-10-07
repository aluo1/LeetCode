/**
 * Question 75. Sort Colors (https://leetcode-cn.com/problems/sort-colors/)
 *
 * Do not return anything, modify nums in-place instead.
 *
 * Acknowledgement: This solution borrows idea froms the [official solution](https://leetcode-cn.com/problems/sort-colors/solution/yan-se-fen-lei-by-leetcode-solution/).
 */

/**
 * 执行用时：96 ms, 在所有 typescript 提交中击败了 12.20% 的用户
 * 内存消耗：39.4 MB, 在所有 typescript 提交中击败了 11.54% 的用户
 *
 * @param {number[]} nums
 */
function sortColorsUsingBuildinFunction(nums: number[]): void {
  nums.sort((a, b) => a - b);
}

/**
 * 执行用时：108 ms, 在所有 typescript 提交中击败了 12.20% 的用户
 * 内存消耗：38.7 MB, 在所有 typescript 提交中击败了 11.54% 的用户
 *
 * @param {number[]} nums
 */
function sortColorsSinglePointer(nums: number[]): void {
  let headPointer: number = 0;
  const N: number = nums.length;

  for (let i = 0; i < N; i++) {
    if (nums[i] == 0) {
      [nums[i], nums[headPointer]] = [nums[headPointer], nums[i]];
      headPointer++;
    }
  }

  for (let i = headPointer; i < N; i++) {
    if (nums[i] == 1) {
      [nums[i], nums[headPointer]] = [nums[headPointer], nums[i]];
      headPointer++;
    }
  }
}

/**
 * 执行用时：80 ms, 在所有 typescript 提交中击败了 58.54% 的用户
 * 内存消耗：38.8 MB, 在所有 typescript 提交中击败了 11.54% 的用户
 *
 * @param {number[]} nums
 */
function sortColorsTwoPointers(nums: number[]): void {
  const N: number = nums.length;
  const RED: number = 0;
  const WHITE: number = 1;

  let redPointer: number = 0;
  let whitePointer: number = 0;

  for (let i = 0; i < N; i++) {
    const num: number = nums[i];

    if (num == WHITE) {
      [nums[i], nums[whitePointer]] = [nums[whitePointer], nums[i]];
      whitePointer++;
    } else if (num == RED) {
      [nums[i], nums[redPointer]] = [nums[redPointer], nums[i]];
      if (redPointer < whitePointer) {
        [nums[i], nums[whitePointer]] = [nums[whitePointer], nums[i]];
      }

      redPointer++;
      whitePointer++;
    }
  }
}

/**
 * 执行用时：84 ms, 在所有 typescript 提交中击败了 56.10% 的用户
 * 内存消耗：39.6 MB, 在所有 typescript 提交中击败了 7.69% 的用户
 *
 * @param {number[]} nums
 */
function sortColorsTwoPointersII(nums: number[]): void {
  const N: number = nums.length;
  const RED: number = 0;
  const BLUE: number = 2;

  let redPointer: number = 0;
  let bluePointer = N - 1;

  for (let i = 0; i <= bluePointer; i++) {
    while (i <= bluePointer && nums[i] == BLUE) {
      [nums[i], nums[bluePointer]] = [nums[bluePointer], nums[i]];
      bluePointer--;
    }

    if (nums[i] == RED) {
      [nums[i], nums[redPointer]] = [nums[redPointer], nums[i]];
      redPointer++;
    }
  }
}

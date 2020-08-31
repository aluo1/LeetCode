/**
 * Question 154. Find Minimum in Rotated Sorted Array II (https://leetcode-cn.com/problems/find-minimum-in-rotated-sorted-array-ii/submissions/)
 * 执行用时：96 ms, 在所有 typescript 提交中击败了 18.75% 的用户
 * 内存消耗：37.9 MB, 在所有 typescript 提交中击败了 100.00% 的用户
 *
 * @param {number[]} numbers
 * @returns {number}
 */
function findMin(numbers: number[]): number {
  let minValue: number = numbers[0];
  let minIndex: number = numbers.length - 1;

  while (minIndex >= 0) {
    const currentValue = numbers[minIndex];

    if (currentValue <= minValue) {
      minValue = currentValue;
      minIndex--;
    } else {
      break;
    }
  }

  return minValue;
}

/**
 * 剑指 Offer 11. 旋转数组的最小数字 (https://leetcode-cn.com/problems/xuan-zhuan-shu-zu-de-zui-xiao-shu-zi-lcof/s)
 * Difficulty: Easy
 *
 * This question is idential to [question 154](../Difficult/154 - FindMinimumInRotatedSortedArrayII).
 *
 * 执行用时：104 ms, 在所有 typescript 提交中击败了 10.42% 的用户
 * 内存消耗：37.8 MB, 在所有 typescript 提交中击败了 85.71% 的用户
 *
 * @param {number[]} numbers
 * @returns {number}
 */
function minArray(numbers: number[]): number {
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

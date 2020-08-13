/* Question 26. Remove Duplicates from Sorted Array (https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/) */

/**
 * 执行用时：104 ms, 在所有 typescript 提交中击败了 51.97% 的用户
 * 内存消耗：40.1 MB, 在所有 typescript 提交中击败了 80.88% 的用户
 *
 * @param {number[]} nums
 * @returns {number}
 */
function removeDuplicates(nums: number[]): number {
  if (nums.length <= 1) {
    return nums.length;
  }

  let uniqueNumbersCount: number = 1;
  let previousValue: number = nums[0];

  for (let i = 0; i < nums.length; ) {
    let indexOfNextUnique: number = i + 1;
    while (
      indexOfNextUnique < nums.length &&
      nums[indexOfNextUnique] === previousValue
    ) {
      indexOfNextUnique++;
    }

    if (indexOfNextUnique === nums.length) {
      break;
    }

    if (previousValue !== nums[indexOfNextUnique]) {
      previousValue = nums[indexOfNextUnique];
      nums[uniqueNumbersCount++] = previousValue;
      i = indexOfNextUnique;
    }
  }

  return uniqueNumbersCount;
}

/**
 * 执行用时：104 ms, 在所有 typescript 提交中击败了 51.97% 的用户
 * 内存消耗：40 MB, 在所有 typescript 提交中击败了 83.82% 的用户
 *
 * 作者：LeetCode
 * 链接：https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/solution/shan-chu-pai-xu-shu-zu-zhong-de-zhong-fu-xiang-by-/
 * 来源：力扣（LeetCode）
 * 著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。
 *
 * @param {number[]} nums
 * @returns {number}
 */
function removeDuplicatesProvidedSolution(nums: number[]): number {
  if (nums.length <= 1) {
    return nums.length;
  }

  let i: number = 0;

  for (let j = 1; i < nums.length; j++) {
    if (nums[j] !== nums[i]) {
      i++;
      nums[i] = nums[j];
    }
  }

  return i + 1;
}

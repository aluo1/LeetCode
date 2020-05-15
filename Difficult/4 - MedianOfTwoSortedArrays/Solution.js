/**
 * Question 4. Median of Two Sorted Arrays (https://leetcode-cn.com/problems/median-of-two-sorted-arrays/)
 * 执行用时: 136 ms, 在所有 JavaScript 提交中击败了 68.54% 的用户
 * 内存消耗: 40.1 MB, 在所有 JavaScript 提交中击败了 43.75% 的用户
 *
 * @param {number[]} nums1
 * @param {number[]} nums2
 * @return {number}
 */
var findMedianSortedArrays = function (nums1, nums2) {
  const newArray = [...nums1, ...nums2].sort((a, b) => a - b);
  const newArrayLength = newArray.length;

  if (newArrayLength % 2 === 1) {
    return newArray[Math.floor(newArrayLength / 2)];
  }

  return (newArray[newArrayLength / 2] + newArray[newArrayLength / 2 - 1]) / 2;
};

// Question 349. Intersection of Two Arrays (https://leetcode-cn.com/problems/intersection-of-two-arrays/)

/**
 * 执行用时：96 ms, 在所有 typescript 提交中击败了 36.90% 的用户
 * 内存消耗：40.1 MB, 在所有 typescript 提交中击败了 31.33% 的用户
 *
 * @param {number[]} nums1
 * @param {number[]} nums2
 * @returns {number[]}
 */
function intersection(nums1: number[], nums2: number[]): number[] {
  const uniqueNums1: number[] = [...new Set(nums1)];
  const uniqueNums2: number[] = [...new Set(nums2)];

  return uniqueNums1.filter((num) => uniqueNums2.indexOf(num) >= 0);
}

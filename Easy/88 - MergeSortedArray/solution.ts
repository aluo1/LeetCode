// Question 88. Merge Sorted Array (https://leetcode-cn.com/problems/merge-sorted-array/)

/**
 * Do not return anything, modify nums1 in-place instead.
 *
 * 执行用时：80 ms, 在所有 TypeScript 提交中击败了 94.26% 的用户
 * 内存消耗：39.4 MB, 在所有 TypeScript 提交中击败了 99.18% 的用户
 */
function merge(nums1: number[], m: number, nums2: number[], n: number): void {
  let num1Index: number = m - 1;
  let num2Index: number = n - 1;
  let sortedIndex: number = m + n - 1;

  while (sortedIndex >= 0) {
    if (num1Index >= 0 && num2Index >= 0) {
      nums1[sortedIndex--] =
        nums1[num1Index] >= nums2[num2Index]
          ? nums1[num1Index--]
          : nums2[num2Index--];
    } else if (num1Index >= 0) {
      nums1[sortedIndex--] = nums1[num1Index--];
    } else {
      nums1[sortedIndex--] = nums2[num2Index--];
    }
  }
}

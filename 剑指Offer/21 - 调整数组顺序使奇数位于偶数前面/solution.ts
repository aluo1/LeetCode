/**
 * 剑指 Offer 21. 调整数组顺序使奇数位于偶数前面 (https://leetcode-cn.com/problems/diao-zheng-shu-zu-shun-xu-shi-qi-shu-wei-yu-ou-shu-qian-mian-lcof/)
 * Difficulty: Easy
 *
 * @param {number[]} nums
 * @returns {number[]}
 */
function exchange(nums: number[]): number[] {
  let start: number = 0;

  const arraySize: number = nums.length;

  let end: number = arraySize - 1;

  while (start < end) {
    while (nums[start] % 2 !== 0 && start < end) {
      start++;
    }

    while (nums[end] % 2 === 0 && start < end) {
      end--;
    }

    if (start < arraySize && end >= 0) {
      const temp: number = nums[start];
      nums[start] = nums[end];
      nums[end] = temp;
    }
  }

  return nums;
}

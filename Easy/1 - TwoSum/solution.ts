// Question 1. Two Sum (https://leetcode-cn.com/problems/two-sum/)

/**
 * 执行用时：104 ms, 在所有 typescript 提交中击败了 54.33% 的用户
 * 内存消耗：40.2 MB, 在所有 typescript 提交中击败了 7.24% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/two-sum/solution/liang-shu-zhi-he-by-leetcode-solution/)
 * 
 * @param {number[]} nums
 * @param {number} target
 * @returns {number[]}
 */
function twoSum(nums: number[], target: number): number[] {
  const hash: Map<number, number> = new Map<number, number>();

  for (let i = 0; i < nums.length; i++) {
    const num: number = nums[i];
    if (hash.has(target - num)) {
      return [hash.get(target - num) as number, i];
    }

    hash.set(num, i);
  }

  return [];
}

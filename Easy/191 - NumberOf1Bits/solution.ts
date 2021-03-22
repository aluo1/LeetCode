// Question 191. Number of 1 Bits (https://leetcode-cn.com/problems/number-of-1-bits/)

/**
 * 执行用时：96 ms, 在所有 TypeScript 提交中击败了 71.43% 的用户
 * 内存消耗：40.6 MB, 在所有 TypeScript 提交中击败了 17.86% 的用户
 *
 * Acknowledgement: This solution is the TypeScript-version duplicate of method I of the
 * [official solution](https://leetcode-cn.com/problems/number-of-1-bits/solution/wei-1de-ge-shu-by-leetcode-solution-jnwf/)
 *
 * @param {number} n
 * @returns {number}
 */
function hammingWeight(n: number): number {
  let ret = 0;
  for (let i = 0; i < 32; i++) {
    if ((n & (1 << i)) !== 0) {
      ret++;
    }
  }
  return ret;
}

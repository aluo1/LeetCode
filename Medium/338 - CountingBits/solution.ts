// Question 338. Counting Bits (https://leetcode-cn.com/problems/counting-bits/)

/**
 * 执行用时：116 ms, 在所有 TypeScript 提交中击败了 52.17% 的用户
 * 内存消耗：43.8 MB, 在所有 TypeScript 提交中击败了 100.00% 的用户
 *
 * @param {number} num
 * @returns {number[]}
 */
function countBits(num: number): number[] {
  const bits: number[] = new Array(num + 1).fill(0);
  for (let i = 1; i <= num; i++) {
    bits[i] = bits[i >> 1] + (i & 1);
  }
  return bits;
}

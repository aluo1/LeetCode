/**
 * 剑指 Offer 17. 打印从 1 到最大的 n 位数 (https://leetcode-cn.com/problems/da-yin-cong-1dao-zui-da-de-nwei-shu-lcof/)
 * Difficulty: Easy
 *
 * 执行用时：136 ms, 在所有 typescript 提交中击败了 28.95% 的用户
 * 内存消耗：46.5 MB, 在所有 typescript 提交中击败了 81.25% 的用户
 *
 * @param {number} n
 * @returns {number[]}
 */
function printNumbers(n: number): number[] {
  const numbers: number[] = [];
  for (let i = 1; i < Math.pow(10, n); i++) {
    numbers.push(i);
  }

  return numbers;
}

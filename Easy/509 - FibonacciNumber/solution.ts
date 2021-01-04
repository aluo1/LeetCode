// Question 509. Fibonacci Number (https://leetcode-cn.com/problems/fibonacci-number/)

/**
 * 执行用时：112 ms, 在所有 TypeScript 提交中击败了 25.51% 的用户
 * 内存消耗：39.9 MB, 在所有 TypeScript 提交中击败了 83.67% 的用户
 *
 * @param {number} n
 * @returns {number}
 */
function fib(n: number): number {
  if (n < 2) {
    return n;
  }

  return fib(n - 1) + fib(n - 2);
}

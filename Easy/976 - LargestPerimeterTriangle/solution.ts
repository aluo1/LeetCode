// Question 976. Largest Perimeter Triangle (https://leetcode-cn.com/problems/largest-perimeter-triangle/)

/**
 * 执行用时：116 ms, 在所有 typescript 提交中击败了 83.33% 的用户
 * 内存消耗：42.8 MB, 在所有 typescript 提交中击败了 16.67% 的用户
 *
 * @param {number[]} A
 * @returns {number}
 */
function largestPerimeter(A: number[]): number {
  A.sort((a, b) => b - a);
  for (let i = 0; i < A.length - 2; i++) {
    if (A[i + 1] + A[i + 2] > A[i]) {
      return A[i + 1] + A[i + 2] + A[i];
    }
  }

  return 0;
}

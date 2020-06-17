/**
 * Question 1014. Best Sightseeing Pair (https://leetcode-cn.com/problems/best-sightseeing-pair/)
 *
 * 执行用时: 68 ms, 在所有 typescript 提交中击败了 100.00% 的用户
 * 内存消耗: 40.7 MB, 在所有 typescript 提交中击败了 100.00% 的用户
 *
 * @param {number[]} A
 * @returns {number}
 */
function maxScoreSightseeingPair(A: number[]): number {
  let maxScore = Number.MIN_VALUE;
  let mx = A[0] + 0;
  for (let i = 1; i <= A.length - 1; i++) {
    maxScore = Math.max(maxScore, mx + A[i] - i);
    mx = Math.max(mx, A[i] + i);
  }

  return maxScore;
}

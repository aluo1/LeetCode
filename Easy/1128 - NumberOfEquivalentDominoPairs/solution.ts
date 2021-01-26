// Question 1128. Number of Equivalent Domino Pairs (https://leetcode-cn.com/problems/number-of-equivalent-domino-pairs/)

/**
 * 执行用时：104 ms, 在所有 TypeScript 提交中击败了 100.00% 的用户
 * 内存消耗：43.9 MB, 在所有 TypeScript 提交中击败了 50.00% 的用户
 *
 * @param {number[][]} dominoes
 * @returns {number}
 */
function numEquivDominoPairs(dominoes: number[][]): number {
  const num: number[] = [];

  for (let index = 0; index < 100; index++) {
    num[index] = 0;
  }

  let pairsCount: number = 0;
  for (let index = 0; index < dominoes.length; index++) {
    const [first, second] = dominoes[index];
    const valueIndex: number =
      first > second ? first * 10 + second : second * 10 + first;

    pairsCount += num[valueIndex];
    num[valueIndex]++;
  }

  return pairsCount;
}

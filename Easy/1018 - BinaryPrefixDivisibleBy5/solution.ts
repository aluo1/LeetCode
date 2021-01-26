// Question 1018. Binary Prefix Divisible By 5 (https://leetcode-cn.com/problems/binary-prefix-divisible-by-5/)

/**
 * 执行用时：96 ms, 在所有 TypeScript 提交中击败了 100.00% 的用户
 * 内存消耗：42.7 MB, 在所有 TypeScript 提交中击败了 100.00% 的用户
 *
 * @param {number[]} A
 * @returns {boolean[]}
 */
function prefixesDivBy5(A: number[]): boolean[] {
  const results: boolean[] = [];
  const N: number = A.length;

  let value: number = 0;
  for (let index = 0; index < N; index++) {
    value = ((value << 1) + A[index]) % 5;
    results.push(!value);
  }

  return results;
}

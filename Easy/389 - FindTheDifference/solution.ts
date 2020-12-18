// Question 389. Find the Difference (https://leetcode-cn.com/problems/find-the-difference/)

/**
 * 执行用时：92 ms, 在所有 TypeScript 提交中击败了 81.25% 的用户
 * 内存消耗：40.4 MB, 在所有 TypeScript 提交中击败了 59.38% 的用户
 *
 * @param {string} s
 * @param {string} t
 * @returns {string}
 */
function findTheDifference(s: string, t: string): string {
  const N: number = s.length;
  if (!N) {
    return t;
  }

  let i: number = 0;
  const sortedS: string = s.split("").sort().join("");
  const sortedT: string = t.split("").sort().join("");

  for (i = 0; i < N; i++) {
    if (sortedS[i] != sortedT[i]) {
      return sortedT[i];
    }
  }

  //   console.log(`i = ${i}, N = ${N}`);
  return sortedT[i];
}

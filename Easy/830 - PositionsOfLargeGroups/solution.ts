// Question 830. Positions of Large Groups (https://leetcode-cn.com/problems/positions-of-large-groups/)

/**
 * 执行用时：108 ms, 在所有 TypeScript 提交中击败了 50.00% 的用户
 * 内存消耗：41.5 MB, 在所有 TypeScript 提交中击败了 50.00% 的用户
 *
 * @param {string} s
 * @returns {number[][]}
 */
function largeGroupPositions(s: string): number[][] {
  const largeGroups: number[][] = [];

  const N: number = s.length;
  if (!N) {
    return largeGroups;
  }

  let currentGroupChar: string = s[0];
  let startIndex: number;
  let endIndex: number;
  for (startIndex = 0, endIndex = 0; endIndex < N; endIndex++) {
    // System.Console.WriteLine($"startIndex = {startIndex}, endIndex = {endIndex}");
    if (s[endIndex] != currentGroupChar) {
      if (endIndex - startIndex >= 3) {
        largeGroups.push([startIndex, endIndex - 1]);
      }
      startIndex = endIndex;
      currentGroupChar = s[endIndex];
    }
  }

  if (s[N - 1] == currentGroupChar && N - 1 - startIndex + 1 >= 3) {
    largeGroups.push([startIndex, N - 1]);
  }

  return largeGroups;
}

/**
 * Question 771. Jewels and Stones (https://leetcode-cn.com/problems/jewels-and-stones/)
 * 执行用时：96 ms, 在所有 typescript 提交中击败了 22.86% 的用户
 * 内存消耗：39.3 MB, 在所有 typescript 提交中击败了 12.50% 的用户
 *
 * @param {string} J
 * @param {string} S
 * @returns {number}
 */
function numJewelsInStones(J: string, S: string): number {
  const jewels: Map<string, number> = new Map<string, number>();
  for (let jewel of J) {
    jewels.set(jewel, 1);
  }

  let jewelCount: number = 0;

  for (let stone of S) {
    if (jewels.has(stone)) {
      jewelCount++;
    }
  }

  return jewelCount;
}

/**
 * 执行用时：96 ms, 在所有 typescript 提交中击败了 22.86% 的用户
 * 内存消耗：39.5 MB, 在所有 typescript 提交中击败了 12.50% 的用户
 *
 * @param {string} J
 * @param {string} S
 * @returns {number}
 */
function numJewelsInStonesUsingSet(J: string, S: string): number {
  const jewels: Set<string> = new Set<string>();
  for (let jewel of J) {
    jewels.add(jewel);
  }

  let jewelCount: number = 0;

  for (let stone of S) {
    if (jewels.has(stone)) {
      jewelCount++;
    }
  }

  return jewelCount;
}

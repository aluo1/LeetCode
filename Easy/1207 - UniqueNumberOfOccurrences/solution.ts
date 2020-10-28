// Question 1207. Unique Number of Occurrences (https://leetcode-cn.com/problems/unique-number-of-occurrences/submissions/)

/**
 * 执行用时：112 ms, 在所有 typescript 提交中击败了 12.50% 的用户
 * 内存消耗：40.2 MB, 在所有 typescript 提交中击败了 12.50% 的用户
 *
 * @param {number[]} arr
 * @returns {boolean}
 */
function uniqueOccurrences(arr: number[]): boolean {
  const occurrenceCounts: Map<number, number> = new Map<number, number>();
  for (let num of arr) {
    occurrenceCounts.set(num, (occurrenceCounts.get(num) ?? 0) + 1);
  }

  return (
    [...occurrenceCounts.values()].length ===
    [...new Set(occurrenceCounts.values())].length
  );
}

/**
 * 执行用时：88 ms, 在所有 typescript 提交中击败了 37.50% 的用户
 * 内存消耗：40.2 MB, 在所有 typescript 提交中击败了 12.50% 的用户
 *
 * @param {number[]} arr
 * @returns {boolean}
 */
function uniqueOccurrences(arr: number[]): boolean {
  const occurrenceCounts: Map<number, number> = new Map<number, number>();
  for (let num of arr) {
    occurrenceCounts.set(num, (occurrenceCounts.get(num) ?? 0) + 1);
  }

  const uniqueOccurrences: Map<number, boolean> = new Map<number, boolean>();
  for (let [num, occurrence] of occurrenceCounts.entries()) {
    if (uniqueOccurrences.has(occurrence)) {
      return false;
    }

    uniqueOccurrences.set(occurrence, true);
  }

  return true;
}

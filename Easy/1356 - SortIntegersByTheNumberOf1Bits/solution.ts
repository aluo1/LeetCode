// Question 1356. Sort Integers by The Number of 1 Bits (https://leetcode-cn.com/problems/sort-integers-by-the-number-of-1-bits/)

/**
 * 执行用时：164 ms, 在所有 typescript 提交中击败了 66.67% 的用户
 * 内存消耗：44.8 MB, 在所有 typescript 提交中击败了 33.33% 的用户
 *
 * @param {number[]} arr
 * @returns {number[]}
 */
function sortByBits(arr: number[]): number[] {
  const N: number = arr.length;
  if (!N) {
    return arr;
  }
  const binaryMapping: Map<number, number> = getBinaryMapping(arr);

  return arr.sort((a, b) => {
    const a1Count: number = binaryMapping.get(a) as number;
    const b1Count: number = binaryMapping.get(b) as number;

    if (a1Count != b1Count) {
      return a1Count - b1Count;
    } else {
      return a - b;
    }
  });
}

function getBinaryMapping(arr: number[]): Map<number, number> {
  const mapping: Map<number, number> = new Map<number, number>();

  arr.forEach((num) =>
    mapping.set(
      num,
      Number(num)
        .toString(2)
        .split("")
        .filter((digitString) => digitString === "1").length
    )
  );

  return mapping;
}

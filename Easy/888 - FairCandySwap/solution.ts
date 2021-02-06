// Question 888. Fair Candy Swap (https://leetcode-cn.com/problems/fair-candy-swap/)

/**
 * 执行用时：120 ms, 在所有 TypeScript 提交中击败了 78.29% 的用户
 * 内存消耗：49.2 MB, 在所有 TypeScript 提交中击败了 20.39% 的用户
 *
 * @param {number[]} A
 * @param {number[]} B
 * @returns {number[]}
 */
function fairCandySwap(A: number[], B: number[]): number[] {
  let result: number[] = [];

  const aCandy: Map<number, number> = new Map<number, number>();
  for (const a of A) {
    aCandy.set(a, aCandy.has(a) ? aCandy.get(a) + 1 : 1);
  }

  const halfBAGap: number = (getSum(B) - getSum(A)) / 2;
  for (const b of B) {
    const x = b - halfBAGap;
    if (aCandy.has(x)) {
      return [x, b];
    }
  }

  return result;
}

function getSum(array: number[]): number {
  return array.reduce((acc, current) => acc + current, 0);
}

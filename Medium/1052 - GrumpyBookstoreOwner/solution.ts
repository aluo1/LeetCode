// Question 1052. Grumpy Bookstore Owner (https://leetcode-cn.com/problems/grumpy-bookstore-owner/)

/**
 * 执行用时：88 ms, 在所有 TypeScript 提交中击败了 100.00% 的用户
 * 内存消耗：42.3 MB, 在所有 TypeScript 提交中击败了 100.00% 的用户
 *
 * @param {number[]} customers
 * @param {number[]} grumpy
 * @param {number} X
 * @returns {number}
 */
function maxSatisfied(
  customers: number[],
  grumpy: number[],
  X: number
): number {
  const MINUTES: number = customers.length;
  let total: number = 0;
  for (let i = 0; i < MINUTES; i++) {
    total += (1 - grumpy[i]) * customers[i];
  }

  let increase: number = 0;
  let maxIncrease: number = 0;

  for (let i = 0; i < X; i++) {
    increase += grumpy[i] * customers[i];
  }
  maxIncrease = increase;

  for (let i = X; i < MINUTES; i++) {
    increase =
      increase - grumpy[i - X] * customers[i - X] + grumpy[i] * customers[i];
    maxIncrease = Math.max(maxIncrease, increase);
  }
  maxIncrease = Math.max(maxIncrease, increase);

  return total + maxIncrease;
}

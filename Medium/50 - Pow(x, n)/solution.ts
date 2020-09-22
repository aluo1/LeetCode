/**
 * Question 50. Pow(x, n) (https://leetcode-cn.com/problems/powx-n/)
 *
 * 执行用时：84 ms, 在所有 typescript 提交中击败了 54.55% 的用户
 * 内存消耗：37.6 MB, 在所有 typescript 提交中击败了 9.09% 的用户
 *
 * Acknowledgement: This solution borrows the idea from the [official solution](https://leetcode-cn.com/problems/powx-n/solution/powx-n-by-leetcode-solution/).
 *
 * @param {number} x
 * @param {number} n
 * @returns {number}
 */
function myPow(x: number, n: number): number {
  let poweredValue: number = 1;
  let absoluteN: number = Math.abs(n);
  let contribution: number = x;

  while (absoluteN > 0) {
    if (absoluteN % 2 == 1) {
      poweredValue *= contribution;
    }

    contribution *= contribution;
    absoluteN = Math.floor(absoluteN / 2);
  }

  return n <= 0 ? 1.0 / poweredValue : poweredValue;
}

/**
 * This solution time out in the test case:
 *  x = 2.00000
 *  n = -2147483648
 *
 * @param {number} x
 * @param {number} n
 * @returns {number}
 */
function myPowTimeoutSolution(x: number, n: number): number {
  if (n < 0) {
    x = 1 / x;
    n *= -1;
  }

  let poweredValue: number = 1;
  for (let i = 0; i < n; i++) {
    poweredValue *= x;
  }

  return poweredValue;
}

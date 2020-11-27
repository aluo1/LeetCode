// Question 454. 4Sum II (https://leetcode-cn.com/problems/4sum-ii/)

/**
 * 执行用时：200 ms, 在所有 typescript 提交中击败了 25.00% 的用户
 * 内存消耗：53.1 MB, 在所有 typescript 提交中击败了 37.50% 的用户
 *
 * @param {number[]} A
 * @param {number[]} B
 * @param {number[]} C
 * @param {number[]} D
 * @returns {number}
 */
function fourSumCount(
  A: number[],
  B: number[],
  C: number[],
  D: number[]
): number {
  const halfSum: Map<number, number> = new Map<number, number>();
  A.forEach((x) => {
    B.forEach((y) => {
      const sum: number = x + y;
      if (halfSum.has(sum)) {
        halfSum.set(sum, (halfSum.get(sum) as number) + 1);
      } else {
        halfSum.set(sum, 1);
      }
    });
  });

  let count: number = 0;
  C.forEach((x) => {
    D.forEach((y) => {
      const sum: number = x + y;
      if (halfSum.has(-sum)) {
        count += halfSum.get(-sum) as number;
      }
    });
  });

  return count;
}

/**
 * 执行用时：168 ms, 在所有 typescript 提交中击败了 25.00% 的用户
 * 内存消耗：53.4 MB, 在所有 typescript 提交中击败了 25.00% 的用户
 *
 * @param {number[]} A
 * @param {number[]} B
 * @param {number[]} C
 * @param {number[]} D
 * @returns {number}
 */
function fourSumCount(
  A: number[],
  B: number[],
  C: number[],
  D: number[]
): number {
  const halfSum: Map<number, number> = new Map<number, number>();
  const N: number = A.length;

  for (let i = 0; i < N; i++) {
    for (let j = 0; j < N; j++) {
      const sum: number = A[i] + B[j];
      if (halfSum.has(sum)) {
        halfSum.set(sum, (halfSum.get(sum) as number) + 1);
      } else {
        halfSum.set(sum, 1);
      }
    }
  }

  let count: number = 0;
  for (let k = 0; k < N; k++) {
    for (let l = 0; l < N; l++) {
      const sum: number = C[k] + D[l];
      if (halfSum.has(-sum)) {
        count += halfSum.get(-sum) as number;
      }
    }
  }
  return count;
}

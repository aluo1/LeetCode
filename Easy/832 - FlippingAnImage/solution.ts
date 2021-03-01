// Question 832. Flipping an Image (https://leetcode-cn.com/problems/flipping-an-image/)

/**
 * 执行用时：88 ms, 在所有 TypeScript 提交中击败了 100.00% 的用户
 * 内存消耗：40.6 MB, 在所有 TypeScript 提交中击败了 33.33% 的用户
 *
 * @param {number[][]} A
 * @returns {number[][]}
 */
function flipAndInvertImage(A: number[][]): number[][] {
  const M: number = A.length;
  const N: number = A[0].length;

  for (let index = 0; index < M; index++) {
    let left: number = 0;
    let right: number = N - 1;

    while (left < right) {
      [A[index][left], A[index][right]] = [
        1 - A[index][right],
        1 - A[index][left],
      ];

      left++;
      right--;
    }

    if (left === right) {
      A[index][left] = 1 - A[index][right];
    }
  }

  return A;
}

// Question 304. Range Sum Query 2D - Immutable (https://leetcode-cn.com/problems/range-sum-query-2d-immutable/)

/**
 * 执行用时：108 ms, 在所有 TypeScript 提交中击败了 83.33% 的用户
 * 内存消耗：44.1 MB, 在所有 TypeScript 提交中击败了 16.67% 的用户
 *
 * Acknowledgement: This solution is the TypeScript-version duplicate of the
 * [official solution](https://leetcode-cn.com/problems/range-sum-query-2d-immutable/solution/er-wei-qu-yu-he-jian-suo-ju-zhen-bu-ke-b-2z5n/).
 * I have came up with the identical solution, which is the [C# solution](./Solution.cs), but I just want to have a look how Leetcode Official
 * will write the solution.
 *
 * @class NumMatrix
 */
class NumMatrix {
  #sums: number[][];

  constructor(matrix: number[][]) {
    const m = matrix.length;
    if (m > 0) {
      const N: number = matrix[0].length;
      this.#sums = new Array(m + 1).fill(0).map(() => new Array(N + 1).fill(0));

      for (let i = 0; i < m; i++) {
        for (let j = 0; j < N; j++) {
          this.#sums[i + 1][j + 1] =
            this.#sums[i][j + 1] +
            this.#sums[i + 1][j] -
            this.#sums[i][j] +
            matrix[i][j];
        }
      }
    }
  }

  sumRegion(row1: number, col1: number, row2: number, col2: number): number {
    return (
      this.#sums[row2 + 1][col2 + 1] -
      this.#sums[row1][col2 + 1] -
      this.#sums[row2 + 1][col1] +
      this.#sums[row1][col1]
    );
  }
}

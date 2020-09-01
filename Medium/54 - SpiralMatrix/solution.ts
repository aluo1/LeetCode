/**
 * Question 54. Spiral Matrix (https://leetcode-cn.com/problems/spiral-matrix/)
 *
 * 执行用时：84 ms, 在所有 typescript 提交中击败了 20.69% 的用户
 * 内存消耗：37.2 MB, 在所有 typescript 提交中击败了 100.00% 的用户
 *
 * @param {number[][]} matrix
 * @returns {number[]}
 */
function spiralOrder(matrix: number[][]): number[] {
  const m: number = matrix.length;
  if (m === 0) {
    return [];
  }

  const n: number = matrix[0].length;
  if (n === 0) {
    return [];
  }

  let rowStart: number = 0;
  let rowEnd: number = m - 1;
  let columnStart: number = 0;
  let columnEnd: number = n - 1;

  let currentRow: number = rowStart;
  let currentColumn: number = columnStart;

  let horizontal: boolean = true;
  let horizontalDirection: number = 1;
  let verticalDirection: number = 1;

  const matrixSize: number = m * n;

  const visitedCells: number[] = [];

  while (visitedCells.length !== matrixSize) {
    visitedCells.push(matrix[currentRow][currentColumn]);

    if (horizontal) {
      if (horizontalDirection > 0) {
        // top right cornor
        if (currentColumn === columnEnd) {
          horizontal = !horizontal;
          currentRow += verticalDirection;
          horizontalDirection *= -1;
          rowStart++;
        } else {
          currentColumn++;
        }
      } else {
        // bottom left cornor
        if (currentColumn === columnStart) {
          horizontal = !horizontal;
          currentRow += verticalDirection;
          horizontalDirection *= -1;
          rowEnd--;
        } else {
          currentColumn--;
        }
      }
    } else {
      if (verticalDirection > 0) {
        // bottom right cornor
        if (currentRow === rowEnd) {
          horizontal = !horizontal;
          currentColumn += horizontalDirection;
          verticalDirection *= -1;
          columnEnd--;
        } else {
          currentRow++;
        }
      } else {
        // top left cornor
        if (currentRow === rowStart) {
          horizontal = !horizontal;
          currentColumn += horizontalDirection;
          verticalDirection *= -1;
          rowStart++;
        } else {
          currentRow--;
        }
      }
    }
  }

  return visitedCells;
}

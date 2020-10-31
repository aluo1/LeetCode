// Question 463. Island Perimeter (https://leetcode-cn.com/problems/island-perimeter/)

/**
 * 执行用时：212 ms, 在所有 typescript 提交中击败了 60.00% 的用户
 * 内存消耗：47.7 MB, 在所有 typescript 提交中击败了 30.00% 的用户
 *
 * @param {number[][]} grid
 * @returns {number}
 */
function islandPerimeter(grid: number[][]): number {
  const X_DIRECTION: number[] = [-1, 0, 1, 0];
  const Y_DIRECTION: number[] = [0, -1, 0, 1];

  const x: number = grid.length;
  const y: number = grid[0].length;

  let perimeter: number = 0;

  for (let i = 0; i < x; i++) {
    for (let j = 0; j < y; j++) {
      if (grid[i][j]) {
        let currentPerimeter: number = 0;
        for (let k = 0; k < 4; k++) {
          const dx = i + X_DIRECTION[k];
          const dy = j + Y_DIRECTION[k];

          if (dx < 0 || dx >= x || dx < 0 || dy >= y || !grid[dx][dy]) {
            currentPerimeter++;
          }
        }
        perimeter += currentPerimeter;
      }
    }
  }

  return perimeter;
}

/// Question 200. Number of Islands (https://leetcode-cn.com/problems/number-of-islands/)

const DIRECTIONS: number[][] = [
  [-1, 0],
  [1, 0],
  [0, 1],
  [0, -1],
];

/**
 * 执行用时：96 ms, 在所有 typescript 提交中击败了 46.91% 的用户
 * 内存消耗： 40.8 MB, 在所有 typescript 提交中击败了 17.86% 的用户
 *
 * @param {string[][]} grid
 * @returns {number}
 */
function numIslands(grid: string[][]): number {
  if (grid.length === 0) {
    return 0;
  }

  const ROW_COUNT: number = grid.length;
  const COLUMN_COUNT: number = grid[0].length;

  let islandCount: number = 0;
  let adjacentLands: number[][] = [];

  for (let i = 0; i < ROW_COUNT; i++) {
    for (let j = 0; j < COLUMN_COUNT; j++) {
      if (grid[i][j] === "1") {
        islandCount++;
        adjacentLands = [[i, j]];

        while (adjacentLands.length) {
          const [adjacentX, adjacentY] = adjacentLands.shift() as number[];

          for (const [xDirection, yDirection] of DIRECTIONS) {
            const newX: number = adjacentX + xDirection;
            const newY: number = adjacentY + yDirection;

            if (
              newX < 0 ||
              newX >= ROW_COUNT ||
              newY < 0 ||
              newY >= COLUMN_COUNT ||
              grid[newX][newY] === "0"
            ) {
              continue;
            }

            adjacentLands.push([newX, newY]);
            grid[newX][newY] = "0";
          }
        }
      }
    }
  }

  return islandCount;
}

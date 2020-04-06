/**
 * 面试题13. 机器人的运动范围 (https://leetcode-cn.com/problems/ji-qi-ren-de-yun-dong-fan-wei-lcof/)
 * Difficulty: Medium
 * 
 * Todo: 我忘记这要求的是能到达的格子了，只是所有符合要求的格子。等到我复习完DFS和BFS之后，再重写一遍。
 *
 * @param {number} m
 * @param {number} n
 * @param {number} k
 * @return {number}
 */
var movingCount = function (m, n, k) {
  const visitedCoordinates = [];

  for (let row = 0; row < m; row++) {
    for (let column = 0; column < n; column++) {
      for (let rowOffset = -1; rowOffset < 2; rowOffset++) {
        for (let columnOffset = -1; columnOffset < 2; columnOffset++) {
          if (Math.abs(rowOffset) === Math.abs(columnOffset)) {
            continue;
          }

          const adjacentRow = row + rowOffset;
          const adjacentColumn = column + columnOffset;

          if (
            adjacentRow < 0 ||
            adjacentRow >= m ||
            adjacentColumn < 0 ||
            adjacentColumn >= n ||
            sumOfTheDigit(adjacentRow) + sumOfTheDigit(adjacentColumn) > k
          ) {
            continue;
          }

          const reachableCoordinate = [adjacentRow, adjacentColumn];
          if (
            !visitedCoordinates.find(
              (visitedCoordinate) =>
                visitedCoordinate[0] === adjacentRow &&
                visitedCoordinate[1] === adjacentColumn
            )
          ) {
            visitedCoordinates.push(reachableCoordinate);
          }
        }
      }
    }
  }

  return visitedCoordinates.length;
};

var sumOfTheDigit = function (coordinateDigit) {
  return `${coordinateDigit}`
    .split("")
    .map((digitChar) => parseInt(digitChar))
    .reduce((accumulated, currentVal) => accumulated + currentVal, 0);
};

/**
 * 面试题13. 机器人的运动范围 (https://leetcode-cn.com/problems/ji-qi-ren-de-yun-dong-fan-wei-lcof/)
 * Difficulty: Medium
 *
 * @param {number} m
 * @param {number} n
 * @param {number} k
 * @return {number}
 */
/**
 * @param {number} m
 * @param {number} n
 * @param {number} k
 * @return {number}
 */
var movingCount = function (m, n, k) {
  const visitedCoordinates = [];
  const queue = [[0, 0]];

  while (queue.length > 0) {
    const [headX, headY] = queue.shift();

    if (
      !visitedCoordinates.some(
        ([coordinateX, coordinateY]) =>
          coordinateX === headX && coordinateY === headY
      )
    ) {
      visitedCoordinates.push([headX, headY]);

      [
        [0, 1],
        [1, 0],
      ].forEach((direction) => {
        const newX = headX + direction[0];
        const newY = headY + direction[1];
        if (
          newX < m &&
          newY < n &&
          sumOfTheDigit(newX) + sumOfTheDigit(newY) <= k &&
          !visitedCoordinates.some(
            (visited) => visited[0] === newX && visited[1] === newY
          )
        ) {
          queue.push([newX, newY]);
        }
      });
    }
  }

  return visitedCoordinates.length;
};

var sumOfTheDigit = function (coordinateDigit) {
  let sum = 0;
  while (coordinateDigit) {
    sum += coordinateDigit % 10;
    coordinateDigit = Math.floor(coordinateDigit / 10);
  }

  return sum;
};

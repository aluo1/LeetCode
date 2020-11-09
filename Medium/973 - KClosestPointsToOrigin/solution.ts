// Question 973. K Closest Points to Origin (https://leetcode-cn.com/problems/k-closest-points-to-origin/)

/**
 * 执行用时：272 ms, 在所有 typescript 提交中击败了 100.00% 的用户
 * 内存消耗：51.7 MB, 在所有 typescript 提交中击败了 50.00% 的用户
 *
 * @param {number[][]} points
 * @param {number} K
 * @returns {number[][]}
 */
function kClosest(points: number[][], K: number): number[][] {
  const pointsDistance: Map<number[], number> = new Map<number[], number>(
    points.map((point) => [
      point,
      Math.pow(point[0] - 0, 2) + Math.pow(point[1] - 0, 2),
    ])
  );

  points.sort(
    (a, b) =>
      (pointsDistance.get(a) as number) - (pointsDistance.get(b) as number)
  );

  return points.slice(0, K);
}

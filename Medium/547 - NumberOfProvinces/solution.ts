// Question 547. Number of Provinces (https://leetcode-cn.com/problems/number-of-provinces/)

/**
 * 执行用时：112 ms, 在所有 TypeScript 提交中击败了 32.26% 的用户
 * 内存消耗：41.4 MB, 在所有 TypeScript 提交中击败了 54.84% 的用户
 * 
 * Acknowledgement: This BFS borrows idea from 
 * the [official solution](https://leetcode-cn.com/problems/number-of-provinces/solution/sheng-fen-shu-liang-by-leetcode-solution-eyk0/).
 *
 * @param {number[][]} isConnected
 * @returns {number}
 */
function findCircleNum(isConnected: number[][]): number {
  const N: number = isConnected.length;
  const visited: Set<number> = new Set<number>();
  let provincesCount: number = 0;

  const queue: number[] = [];
  for (let i = 0; i < N; i++) {
    if (!visited.has(i)) {
      queue.push(i);
      while (queue.length) {
        const j: number = queue.shift() as number;
        visited.add(j);
        for (let k = 0; k < N; k++) {
          if (isConnected[j][k] && !visited.has(k)) {
            queue.push(k);
          }
        }
      }
      provincesCount++;
    }
  }

  return provincesCount;
}

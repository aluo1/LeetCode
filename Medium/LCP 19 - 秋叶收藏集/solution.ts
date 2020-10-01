// LCP 19. 秋叶收藏集 (https://leetcode-cn.com/problems/UlBDOe/)

const YELLOW_BEFORE_RED_INDEX: number = 0;
const RED_INDEX: number = 1;
const YELLOW_AFTER_RED_INDEX: number = 2;

/**
 * 执行用时：660 ms, 在所有 typescript 提交中击败了 100.00% 的用户
 * 内存消耗：79.3 MB, 在所有 typescript 提交中击败了 100.00% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/UlBDOe/solution/qiu-xie-shou-cang-ji-by-leetcode-solution/)
 * and [solution from superkakayong](https://leetcode-cn.com/problems/UlBDOe/solution/zhong-qiu-guo-qing-kuai-le-zi-jie-ti-ku-lcp19-zhon/)
 * Test case 1:
 *  Input: "rrryyyrryyyrr"
 *  Expected Output: 2
 *
 * Test case 2:
 *  Input: "ryr"
 *  Expected Output: 0
 *
 *
 * @param {string} leaves
 * @returns {number}
 */
function minimumOperations(leaves: string): number {
  // expected leaves would be: r*y*r*
  const leavesLength: number = leaves.length;
  const dp: number[][] = [
    [isYellow(leaves[0]), Number.MAX_SAFE_INTEGER, Number.MAX_SAFE_INTEGER],
  ];

  for (let i = 1; i < leavesLength; i++) {
    const currentLeave: string = leaves[i];
    const isYellowLeave: number = isYellow(currentLeave);
    const isRedLeave: number = isRed(currentLeave);

    const currentLeaveStatus: number[] = [];
    // f[i][0]
    currentLeaveStatus.push(dp[i - 1][YELLOW_BEFORE_RED_INDEX] + isYellowLeave);
    // f[i][1]
    currentLeaveStatus.push(
      Math.min(dp[i - 1][YELLOW_BEFORE_RED_INDEX], dp[i - 1][RED_INDEX]) +
        isRedLeave
    );
    // f[i][2]
    currentLeaveStatus.push(
      i === 1
        ? Number.MAX_SAFE_INTEGER
        : Math.min(dp[i - 1][RED_INDEX], dp[i - 1][YELLOW_AFTER_RED_INDEX]) +
            isYellowLeave
    );

    dp.push(currentLeaveStatus);
  }

  return dp[leavesLength - 1][YELLOW_AFTER_RED_INDEX];
}

function isYellow(leave: string): number {
  return leave === "y" ? 1 : 0;
}

function isRed(leave: string): number {
  return leave === "r" ? 1 : 0;
}

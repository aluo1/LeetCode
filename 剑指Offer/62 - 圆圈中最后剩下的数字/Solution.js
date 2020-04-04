/**
 * 面试题62. 圆圈中最后剩下的数字 (https://leetcode-cn.com/problems/yuan-quan-zhong-zui-hou-sheng-xia-de-shu-zi-lcof/)
 * Difficulty: Easy
 * 执行用时: 72 ms, 在所有 JavaScript 提交中击败了 78.29% 的用户
 * 内存消耗: 34.4 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 * 
 * Acknowledgement: 
 * - https://leetcode-cn.com/problems/yuan-quan-zhong-zui-hou-sheng-xia-de-shu-zi-lcof/solution/yuan-quan-zhong-zui-hou-sheng-xia-de-shu-zi-by-lee/
 * - https://leetcode-cn.com/problems/yuan-quan-zhong-zui-hou-sheng-xia-de-shu-zi-lcof/solution/javajie-jue-yue-se-fu-huan-wen-ti-gao-su-ni-wei-sh/
 * 
 * @param {number} n
 * @param {number} m
 * @return {number}
 */
var lastRemaining = function(n, m) {
  let ans = 0;

  for (let i = 2; i <= n; i++) {
    ans = (ans + m) % i;
  }

  return ans;
};

/**
 * 面试题05. 替换空格 (https://leetcode-cn.com/problems/ti-huan-kong-ge-lcof/)
 * Difficulty: Easy
 * 执行用时: 72 ms, 在所有 JavaScript 提交中击败了 25.88% 的用户
 * 内存消耗: 33.7 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 *
 * @param {string} s
 * @return {string}
 */
var replaceSpace = function(s) {
  return s.replace(/ /g, "%20");
};

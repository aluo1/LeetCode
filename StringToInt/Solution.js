/**
 * Question 8. String to Integer (atoi) (https://leetcode-cn.com/problems/string-to-integer-atoi/)
 * Difficulty: Medium
 * 执行用时: 96 ms, 在所有 JavaScript 提交中击败了 37.32% 的用户
 * 内存消耗: 35.9 MB, 在所有 JavaScript 提交中击败了 88.98% 的用户
 *
 * @param {string} str
 * @return {number}
 */
var myAtoi = function(str) {
  if (str && str.trim()) {
    const regex = /^[+|-]?\d+/;
    const matchedResults = regex.exec(str.trim());
    if (matchedResults) {
      return Math.max(
        Math.min(parseInt(matchedResults[0]), Math.pow(2, 31) - 1),
        -1 * Math.pow(2, 31)
      );
    }
  }
  return 0;
};

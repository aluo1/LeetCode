/**
 * LCP 1. 猜数字 (https://leetcode-cn.com/problems/guess-numbers/)
 * Difficulty: Easy
 * 执行用时: 56 ms, 在所有 Python3 提交中击败了 91.03% 的用户
 * 内存消耗: 33.8 MB , 在所有 Python3 提交中击败了 54.74% 的用户
 */

/**
 * @param {number[]} guess
 * @param {number[]} answer
 * @return {number}
 */
var game = function (guess, answer) {
  let correct_count = 0;
  for (i = 0; i < guess.length; i++) {
    if (guess[i] === answer[i]) {
      correct_count++;
    }
  }
  return correct_count;
};

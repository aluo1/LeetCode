/**
 * 面试题 01.02. 判定是否互为字符重排 (https://leetcode-cn.com/problems/check-permutation-lcci/)
 * Difficulty: Easy
 *
 * 执行用时 : 100 ms, 在所有 JavaScript 提交中击败了 6.04% 的用户
 * 内存消耗 : 33.8 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 *
 * @param {string} s1
 * @param {string} s2
 * @return {boolean}
 */
var CheckPermutation = function (s1, s2) {
  return s1.split("").sort().join("") === s2.split("").sort().join("");
};

/**
 * 执行用时: 64 ms, 在所有 JavaScript 提交中击败了 61.59% 的用户
 * 内存消耗: 33.5 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 *
 * @param {string} s1
 * @param {string} s2
 * @return {boolean}
 */
var CheckPermutation = function (s1, s2) {
  if (s1.length !== s2.length) {
    return false;
  }

  return s1.split("").sort().join("") === s2.split("").sort().join("");
};

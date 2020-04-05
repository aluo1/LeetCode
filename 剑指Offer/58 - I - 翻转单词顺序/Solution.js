/**
 * Question 面试题58 - I. 翻转单词顺序 (https://leetcode-cn.com/problems/fan-zhuan-dan-ci-shun-xu-lcof/)
 * Difficulty: Easy
 */
/**
 * 执行用时: 96 ms, 在所有 JavaScript 提交中击败了 9.07% 的用户
 * 内存消耗: 34.3 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 *
 * @param {string} s
 * @return {string}
 */
var reverseWords = function (s) {
  return s
    .trim()
    .split(" ")
    .reverse()
    .reduce((prev, cur) => {
      if (cur !== "" && cur.trim() !== "") {
        return `${prev} ${cur}`;
      }
      return prev;
    }, "")
    .trim();
};

/**
 * 执行用时: 100 ms, 在所有 JavaScript 提交中击败了 6.23% 的用户
 * 内存消耗: 34.5 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 *
 * @param {*} s
 * @returns
 */
var reverseWordsWithoutLastTrim = function (s) {
  return s
    .trim()
    .split(" ")
    .reverse()
    .reduce((prev, cur, currentIndex, srcArray) => {
      if (cur !== "" && cur.trim() !== "") {
        if (currentIndex !== 0) {
          return `${prev} ${cur}`;
        } else {
          return `${prev}${cur}`;
        }
      }
      return prev;
    }, "");
};

/**
 * 执行用时 : 76 ms, 在所有 JavaScript 提交中击败了 30.59% 的用户
 * 内存消耗 : 36.2 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 *
 * Acknowledgement: 从[本答案中](https://leetcode-cn.com/problems/fan-zhuan-dan-ci-shun-xu-lcof/solution/chao-jian-dan-yi-xing-dai-ma-liang-ci-fan-zhuan-py/) 收到启发，用join(" ")来代替繁琐的 reduce
 *
 * @param {string} s
 * @return {string}
 */
var reverseWordsWithFilterAndRegex = function (s) {
  return s
    .split(/\s/)
    .reverse()
    .map((word) => word.trim())
    .filter((word) => word)
    .join(" ");
};

/**
 * 执行用时 : 60 ms, 在所有 JavaScript 提交中击败了 89.80% 的用户
 * 内存消耗 : 36.4 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 * @param {string} s
 * @return {string}
 */
var reverseWordsWithFilter = function (s) {
  return s
    .split(" ")
    .reverse()
    .map((word) => word.trim())
    .filter((word) => word)
    .join(" ");
};

/**
 * Question 557. Reverse Words in a String III (https://leetcode-cn.com/problems/reverse-words-in-a-string-iii/)
 *
 * 执行用时：88 ms, 在所有 typescript 提交中击败了 62.86% 的用户
 * 内存消耗：44.3 MB, 在所有 typescript 提交中击败了 54.55% 的用户
 *
 * @param {string} s
 * @returns {string}
 */
function reverseWords(s: string): string {
  return s
    .split(" ")
    .map((word) => word.split("").reverse().join(""))
    .join(" ");
}

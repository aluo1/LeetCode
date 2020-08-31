/**
 * 面试题05. 替换空格 (https://leetcode-cn.com/problems/ti-huan-kong-ge-lcof/)
 * Difficulty: Easy
 * 
 * 执行用时：76 ms, 在所有 typescript 提交中击败了 58.54% 的用户
 * 内存消耗：36.8 MB, 在所有 typescript 提交中击败了 94.44% 的用户
 *
 * @param {string} s
 * @returns {string}
 */
function replaceSpace(s: string): string {
  return s
    .split("")
    .map((char) => (char === " " ? "%20" : char))
    .join("");
}

// Question 387. First Unique Character in a String (https://leetcode-cn.com/problems/first-unique-character-in-a-string/)

/**
 * 执行用时：104 ms, 在所有 TypeScript 提交中击败了 95.52% 的用户
 * 内存消耗：42.2 MB, 在所有 TypeScript 提交中击败了 50.75% 的用户
 *
 * @param {string} s
 * @returns {number}
 */
function firstUniqChar(s: string): number {
  const N: number = s.length;

  for (let i = 0; i < N; i++) {
    const char: string = s[i];
    if (s.indexOf(char) === s.lastIndexOf(char)) {
      return i;
    }
  }

  return -1;
}

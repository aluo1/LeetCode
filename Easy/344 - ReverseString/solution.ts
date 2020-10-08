/**
 * Question 344. Reverse String (https://leetcode-cn.com/problems/reverse-string/)
 *
 * Do not return anything, modify s in-place instead.
 *
 * 执行用时：132 ms, 在所有 typescript 提交中击败了 17.24% 的用户
 * 内存消耗：46 MB, 在所有 typescript 提交中击败了 8.00% 的用户
 */
function reverseString(s: string[]): void {
  const N: number = s.length;

  for (let i = 0; i < Math.floor(N / 2); i++) {
    const reverseIndex: number = N - 1 - i;
    [s[i], s[reverseIndex]] = [s[reverseIndex], s[i]];
  }
}

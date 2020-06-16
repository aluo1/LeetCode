/**
 * Question 9. Palindrome Number (https://leetcode-cn.com/problems/palindrome-number/)
 *
 * 执行用时: 204 ms, 在所有 typescript 提交中击败了 85.00% 的用户
 * 内存消耗: 44.1 MB, 在所有 typescript 提交中击败了 100.00% 的用户
 *
 * @param {number} x
 * @returns {boolean}
 */
function isPalindrome(x: number): boolean {
  let xString: string = `${x}`;
  let leftPointer: number = 0;
  let rightPointer: number = xString.length - 1;

  while (leftPointer < rightPointer) {
    if (xString[leftPointer++] !== xString[rightPointer--]) {
      return false;
    }
  }

  return true;
}

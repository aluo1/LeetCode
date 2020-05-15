/**
 * Question 20. Valid Parentheses (https://leetcode-cn.com/problems/valid-parentheses/)
 *
 * 执行用时: 64 ms, 在所有 JavaScript 提交中击败了 80.69% 的用户
 * 内存消耗: 34.4 MB, 在所有 JavaScript 提交中击败了 60.61% 的用户
 * @param {string} s
 * @return {boolean}
 */
var isValid = function (s) {
  const brackets = new Map();
  brackets.set("(", ")");
  brackets.set("[", "]");
  brackets.set("{", "}");

  const bracketsStack = [];
  for (let char of s) {
    if (brackets.has(char)) {
      // this is an open bracket.
      bracketsStack.push(char);
    } else {
      // this is a closing bracket.
      const lastChar = bracketsStack[bracketsStack.length - 1];
      if (brackets.has(lastChar) && brackets.get(lastChar) === char) {
        bracketsStack.pop();
      } else {
        return false;
      }
    }
  }

  return bracketsStack.length === 0;
};

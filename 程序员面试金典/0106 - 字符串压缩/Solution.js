/**
 * 面试题 01.06. 字符串压缩 (https://leetcode-cn.com/problems/compress-string-lcci/)
 * Difficulty: Easy
 *
 * 执行用时: 76 ms, 在所有 JavaScript 提交中击败了 61.00% 的用户
 * 内存消耗: 38.4 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 * @param {string} S
 * @return {string}
 */
var compressString = function (S) {
  let sLength = S.length;
  if (sLength <= 2) {
    return S;
  }

  let compressString = "";
  let firstPointer = 0;
  let secondPointer = 1;

  let firstChar = S[firstPointer];
  let secondChar;

  while (secondPointer < sLength) {
    if (compressString.length >= sLength) {
      return S;
    }
    secondChar = S[secondPointer];

    if (firstChar !== secondChar) {
      compressString += `${firstChar}${secondPointer - firstPointer}`;
      firstPointer = secondPointer;
      firstChar = secondChar;
      secondPointer++;
    } else {
      secondPointer++;
    }
  }

  compressString += `${firstChar}${secondPointer - firstPointer}`;

  return compressString.length >= sLength ? S : compressString;
};

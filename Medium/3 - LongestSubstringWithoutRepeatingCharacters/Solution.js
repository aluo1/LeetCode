/**
 * Question 3. Longest Substring Without Repeating Characters (https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/)
 *
 * 执行用时 : 100 ms, 在所有 JavaScript 提交中击败了 73.26% 的用户
 * 内存消耗 : 38.4 MB, 在所有 JavaScript 提交中击败了 71.23% 的用户
 * @param {string} s
 * @return {number}
 */
var lengthOfLongestSubstring = function (s) {
  const uniqueChars = new Set();
  let ans = 0;
  const sLength = s.length;

  let rightPointer = -1;

  for (let i = 0; i < sLength; i++) {
    if (i !== 0) {
      uniqueChars.delete(s[i - 1]);
    }

    while (
      rightPointer + 1 < sLength &&
      !uniqueChars.has(s[rightPointer + 1])
    ) {
      uniqueChars.add(s[rightPointer + 1]);
      rightPointer++;
    }

    ans = Math.max(ans, uniqueChars.size);
  }

  return ans;
};

/**
 * This function is an extension of function lengthOfLongestSubstring: it not only
 * records the length of longest substring, but also records the first occurrence of
 * longest substring.
 *
 * @param {string} s
 * @return {number}
 */
var lengthOfLongestSubstringWithSubstring = function (s) {
  const uniqueChars = new Set();
  let ans = 0;
  let longestSubstring = "";
  const sLength = s.length;

  let rightPointer = -1;

  for (let i = 0; i < sLength; i++) {
    if (i !== 0) {
      uniqueChars.delete(s[i - 1]);
    }

    while (
      rightPointer + 1 < sLength &&
      !uniqueChars.has(s[rightPointer + 1])
    ) {
      uniqueChars.add(s[rightPointer + 1]);
      rightPointer++;
    }

    if (uniqueChars.size > ans) {
      ans = uniqueChars.size;
      longestSubstring = Array.from(uniqueChars).join("");
    }
  }

  return ans;
};

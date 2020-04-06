/**
 * 面试题50. 第一个只出现一次的字符 (https://leetcode-cn.com/problems/di-yi-ge-zhi-chu-xian-yi-ci-de-zi-fu-lcof/)
 * Difficulty: Easy
 *
 * 执行用时: 200 ms, 在所有 JavaScript 提交中击败了 9.43% 的用户
 * 内存消耗: 39.7 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 *
 * @param {string} s
 * @return {character}
 */
var firstUniqChar = function (s) {
  const uniqChars = Object.entries(
    s.split("").reduce((acc, currentVal) => {
      if (acc[currentVal]) {
        acc[currentVal] = acc[currentVal] + 1;
      } else {
        acc[currentVal] = 1;
      }
      return acc;
    }, {})
  )
    .filter((entry) => entry[1] === 1)
    .map((entry) => entry[0]);

  console.debug(uniqChars);

  if (uniqChars.length === 0) {
    return " ";
  }

  for (let i = 0; i < s.length; i++) {
    if (uniqChars.indexOf(s[i]) !== -1) {
      return s[i];
    }
  }
};

/**
 * 执行用时: 124 ms, 在所有 JavaScript 提交中击败了 44.96% 的用户
 * 内存消耗: 38.8 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 * @param {string} s
 * @return {character}
 */
var firstUniqCharFirstIndex = function (s) {
  const uniqChars = Object.entries(
    s.split("").reduce((acc, currentVal) => {
      if (acc[currentVal]) {
        acc[currentVal] = acc[currentVal] + 1;
      } else {
        acc[currentVal] = 1;
      }
      return acc;
    }, {})
  )
    .filter((entry) => entry[1] === 1)
    .map((entry) => entry[0]);

  if (uniqChars.length === 0) {
    return " ";
  }

  return uniqChars[0];
};

/**
 * 执行用时: 112 ms, 在所有 JavaScript 提交中击败了 65.57% 的用户
 * 内存消耗: 38.7 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 * @param {string} s
 * @return {character}
 */
var firstUniqCharIterationOnly = function (s) {
  const freqDictionary = {};
  for (let i = 0; i < s.length; i++) {
    const si = s[i];
    if (freqDictionary[si]) {
      freqDictionary[si] = freqDictionary[si] + 1;
    } else {
      freqDictionary[si] = 1;
    }
  }

  for (let [char, freq] of Object.entries(freqDictionary)) {
    if (freq === 1) {
      return char;
    }
  }

  return " ";
};

/**
 * Question 136. Single Number (https://leetcode-cn.com/problems/single-number/)
 *
 * 执行用时: 72 ms, 在所有 JavaScript 提交中击败了 69.21% 的用户
 * 内存消耗: 38.6 MB, 在所有 JavaScript 提交中击败了 6.45% 的用户
 *
 * @param {number[]} nums
 * @return {number}
 */
var singleNumber = function (nums) {
  const freqDictionary = nums.reduce((accumulated, currentValue) => {
    if (accumulated[currentValue]) {
      accumulated[currentValue] += 1;
    } else {
      accumulated[currentValue] = 1;
    }
    return accumulated;
  }, {});

  return Object.entries(freqDictionary).find(([_, val]) => val === 1)[0];
};

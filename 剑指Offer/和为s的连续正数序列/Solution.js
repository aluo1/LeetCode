/**
 * 面试题57 - II. 和为s的连续正数序列 (https://leetcode-cn.com/problems/he-wei-sde-lian-xu-zheng-shu-xu-lie-lcof/submissions/)
 * Difficulty: Easy
 *
 * @param {number} target
 * @return {number[][]}
 */
var findContinuousSequence = function(target) {
  // 执行用时: 96 ms, 在所有 JavaScript 提交中击败了 27.82% 的用户
  // 内存消耗: 36.8 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户

  const sequence = [];
  for (let i = 1; i < target - 1; i++) {
    const sumSequence = [];
    let sum = 0;
    for (let j = i; j < target; j++) {
      sumSequence.push(j);
      sum += j;
      if (sum === target) {
        sequence.push(sumSequence);
        break;
      } else if (sum > target) {
        break;
      }
    }
  }

  return sequence;
};

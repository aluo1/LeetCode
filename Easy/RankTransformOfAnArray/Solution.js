/**
 * Question 1331. Rank Transform of an Array (https://leetcode-cn.com/problems/rank-transform-of-an-array/)
 * Difficulty: Easy
 * 执行用时: 5948 ms, 在所有 JavaScript 提交中击败了 15.00% 的用户
 * 内存消耗: 61.3 MB , 在所有 JavaScript 提交中击败了 100.00% 的用户
 * 
 * We need to be cautious when using JS to solve this issue, as JS does not support big integer by default sort().
 * To make sorting works well with big integer, we need to customize the sorting method, like what I did here.
 */

/**
 * @param {number[]} arr
 * @return {number[]}
 */
var arrayRankTransform = function(arr) {
  const sortedDistinctArray = [...new Set(arr)].sort(
    (aElem, bElem) => aElem - bElem
  );

  return arr.map(arrElem => sortedDistinctArray.indexOf(arrElem) + 1);
};

/**
 * Question 152. Maximum Product Subarray (https://leetcode-cn.com/problems/maximum-product-subarray/)
 *
 * 执行用时: 64 ms , 在所有 JavaScript 提交中击败了 92.82% 的用户
 * 内存消耗: 35 MB, 在所有 JavaScript 提交中击败了 83.33% 的用户
 *
 * @param {number[]} nums
 * @return {number}
 */
var maxProduct = function (nums) {
  let maxProduct = nums[0];
  let localMin = nums[0];
  let localMax = nums[0];

  for (let i = 1; i < nums.length; i++) {
    const tempMin = localMin;
    const tempMax = localMax;
    const num = nums[i];

    localMax = Math.max(num, num * tempMax, num * tempMin);
    localMin = Math.min(num, num * tempMax, num * tempMin);

    maxProduct = Math.max(localMax, maxProduct);
  }

  return maxProduct;
};

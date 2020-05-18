/// 448. Find All Numbers Disappeared in an Array (https://leetcode-cn.com/problems/find-all-numbers-disappeared-in-an-array/)

/**
 * 执行用时: 7948 ms, 在所有 JavaScript 提交中击败了 18.81% 的用户
 * 内存消耗: 43.9 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 *
 * @param {number[]} nums
 * @return {number[]}
 */
var findDisappearedNumbers = function (nums) {
  const disappearedNumbers = [];
  for (let i = 1; i <= nums.length; i++) {
    if (nums.indexOf(i) === -1) {
      disappearedNumbers.push(i);
    }
  }

  return disappearedNumbers;
};

/**
 * 执行用时: 5788 ms, 在所有 JavaScript 提交中击败了 25.59% 的用户
 * 内存消耗: 51.1 MB, 在所有 JavaScript 提交中击败了 33.33% 的用户
 *
 * @param {number[]} nums
 * @return {number[]}
 */
var findDisappearedNumbers = function (nums) {
  const disappearedNumbers = [];
  const distinctNums = [...new Set(nums)];

  for (let i = 1; i <= nums.length; i++) {
    if (distinctNums.indexOf(i) === -1) {
      disappearedNumbers.push(i);
    }
  }

  return disappearedNumbers;
};

/**
 * 执行用时: 124 ms, 在所有 JavaScript 提交中击败了 72.88% 的用户
 * 内存消耗: 44.9 MB, 在所有 JavaScript 提交中击败了 33.33% 的用户
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/find-all-numbers-disappeared-in-an-array/solution/zhao-dao-suo-you-shu-zu-zhong-xiao-shi-de-shu-zi-2/)
 *
 * @param {number[]} nums
 * @return {number[]}
 */
var findDisappearedNumbers = function (nums) {
  for (let i = 0; i < nums.length; i++) {
    if (nums[Math.abs(nums[i]) - 1] > 0) {
      nums[Math.abs(nums[i]) - 1] *= -1;
    }
  }

  return nums
    .map((num, index) => (num > 0 ? index + 1 : -1))
    .filter((num) => num > 0);
};

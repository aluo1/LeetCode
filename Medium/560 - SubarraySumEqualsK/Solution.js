/**
 * Question 560. Subarray Sum Equals K (https://leetcode-cn.com/problems/subarray-sum-equals-k/)
 *
 * 执行用时 : 524 ms, 在所有 JavaScript 提交中击败了 14.24% 的用户
 * 内存消耗 : 36.2 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 *
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var subarraySum = function (nums, k) {
  const numsLength = nums.length;
  let count = 0;

  for (let i = 0; i < numsLength; i++) {
    let sum = 0;
    for (let j = i; j < numsLength; j++) {
      sum += nums[j];
      if (sum == k) {
        count++;
      }
    }
  }

  return count;
};

/**
 * 执行用时: 96 ms, 在所有 JavaScript 提交中击败了 75.40% 的用户
 * 内存消耗: 40.4 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 *
 * Acknowledgement: This solution is the replicate of the [official solution](https://leetcode-cn.com/problems/subarray-sum-equals-k/solution/he-wei-kde-zi-shu-zu-by-leetcode-solution/)
 *
 * @param {*} nums
 * @param {*} k
 * @returns
 */
var subarraySum = function (nums, k) {
  const hashMap = new Map();
  hashMap.set(0, 1);

  let pre = 0;
  let count = 0;

  for (num of nums) {
    pre += num;

    if (hashMap.has(pre - k)) {
      count += hashMap.get(pre - k);
    }

    hashMap.set(pre, (hashMap.get(pre) || 0) + 1);
  }

  return count;
};

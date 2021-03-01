// Question 303. Range Sum Query - Immutable (https://leetcode-cn.com/problems/range-sum-query-immutable/)

/**
 * 执行用时：132 ms, 在所有 TypeScript 提交中击败了 86.96% 的用户
 * 内存消耗：45.2 MB, 在所有 TypeScript 提交中击败了 95.65% 的用户
 *
 * @class NumArray
 */
class NumArray {
  #_sums: number[];

  constructor(nums: number[]) {
    const N: number = nums.length;

    this.#_sums = [0];
    for (let i = 0; i <= N; i++) {
      this.#_sums[i + 1] = this.#_sums[i] + nums[i];
    }
  }

  sumRange(i: number, j: number): number {
    return this.#_sums[j + 1] - this.#_sums[i];
  }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * var obj = new NumArray(nums)
 * var param_1 = obj.sumRange(i,j)
 */

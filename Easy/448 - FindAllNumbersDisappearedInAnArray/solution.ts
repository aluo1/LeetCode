/// 448. Find All Numbers Disappeared in an Array (https://leetcode-cn.com/problems/find-all-numbers-disappeared-in-an-array/)

/**
 * 执行用时：112 ms, 在所有 TypeScript 提交中击败了 100.00% 的用户
 * 内存消耗：47.1 MB, 在所有 TypeScript 提交中击败了 23.53% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution]
 * (https://leetcode-cn.com/problems/find-all-numbers-disappeared-in-an-array/solution/zhao-dao-suo-you-shu-zu-zhong-xiao-shi-d-mabl/)
 *
 * @param {number[]} nums
 * @returns {number[]}
 */
function findDisappearedNumbers(nums: number[]): number[] {
  const N: number = nums.length;
  for (const num of nums) {
    nums[(num - 1) % N] += N;
  }

  const disappearedNumbers: number[] = [];
  for (let i = 0; i < N; i++) {
    if (nums[i] <= N) {
      disappearedNumbers.push(i + 1);
    }
  }

  return disappearedNumbers;
}

// Question 228. Summary Ranges (https://leetcode-cn.com/problems/summary-ranges/)

/**
 * 执行用时：84 ms, 在所有 TypeScript 提交中击败了 71.43% 的用户
 * 内存消耗：40.1 MB, 在所有 TypeScript 提交中击败了 71.43% 的用户
 *
 * Acknowledgement: This solution borrows idea from the
 * [official solution](https://leetcode-cn.com/problems/summary-ranges/solution/hui-zong-qu-jian-by-leetcode-solution-6zrs/)
 *
 * @param {number[]} nums
 * @returns {string[]}
 */
function summaryRanges(nums: number[]): string[] {
  const ranges: string[] = [];
  let i = 0;
  let N = nums.length;

  while (i < N) {
    let low = i;
    i++;
    while (i < N && nums[i] == nums[i - 1] + 1) {
      i++;
    }
    let high = i - 1;
    let range: string = `${nums[low]}`;
    if (low !== high) {
      range += `->${nums[high]}`;
    }
    ranges.push(range);
  }

  return ranges;
}

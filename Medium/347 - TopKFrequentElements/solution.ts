/**
 * Question 347. Top K Frequent Elements (https://leetcode-cn.com/problems/top-k-frequent-elements/)
 *
 * 执行用时：116 ms, 在所有 typescript 提交中击败了 16.67% 的用户
 * 内存消耗：40.5 MB, 在所有 typescript 提交中击败了 28.13% 的用户
 *
 * Acknowledgement: 
 *    This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/top-k-frequent-elements/solution/qian-k-ge-gao-pin-yuan-su-by-leetcode-solution/) 
 *    and the [solution from ING](https://leetcode-cn.com/problems/top-k-frequent-elements/solution/jing-jian-liao-dai-ma-bing-qie-jia-liao-zhu-shi-bu/)
 * 
 * @param {number[]} nums
 * @param {number} k
 * @returns {number[]}
 */
function topKFrequent(nums: number[], k: number): number[] {
  const numFreq: Map<number, number> = new Map<number, number>();
  for (const num of nums) {
    if (numFreq.has(num)) {
      numFreq.set(num, (numFreq.get(num) as number) + 1);
    } else {
      numFreq.set(num, 1);
    }
  }

  // Use a priority queue to pick top k frequent number.
  return [...numFreq]
    .sort((a, b) => b[1] - a[1])
    .slice(0, k)
    .map(([value, _]) => value);
}

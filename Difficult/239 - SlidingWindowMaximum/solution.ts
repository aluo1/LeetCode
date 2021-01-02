// Question 239. Sliding Window Maximum (https://leetcode-cn.com/problems/sliding-window-maximum/)


/**
 * 执行用时：356 ms, 在所有 TypeScript 提交中击败了 74.36% 的用户
 * 内存消耗：72.2 MB, 在所有 TypeScript 提交中击败了 41.03% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/sliding-window-maximum/solution/hua-dong-chuang-kou-zui-da-zhi-by-leetco-ki6m/)
 * 
 * @param {number[]} nums
 * @param {number} k
 * @returns {number[]}
 */
function maxSlidingWindow(nums: number[], k: number): number[] {
  if (k === 1) {
    return nums;
  }

  const N: number = nums.length;

  const q: number[] = [];
  for (let index = 0; index < k; index++) {
    while (q.length && nums[index] >= nums[q[q.length - 1]]) {
      q.pop();
    }
    q.push(index);
  }

  const ans: number[] = [nums[q[0]]];
  for (let index = k; index < N; index++) {
    while (q.length && nums[index] >= nums[q[q.length - 1]]) {
      q.pop();
    }

    q.push(index);

    while (q[0] <= index - k) {
      q.shift();
    }

    ans.push(nums[q[0]]);
  }

  return ans;
}

function maxSlidingWindowTimeoutSolution(nums: number[], k: number): number[] {
  if (k === 1) {
    return nums;
  }

  const N: number = nums.length;

  let priorityQueue: [number, number][] = [];
  let slidingWindow: number[] = [];
  let windowMax: number = nums[0];

  for (let index = 0; index < k; index++) {
    const currentValue: number = nums[index];
    priorityQueue.push([currentValue, index]);
    windowMax = Math.max(windowMax, currentValue);
  }
  slidingWindow.push(windowMax);
  priorityQueue.sort(([aValue, _], [bValue, b]) => aValue - bValue);

  for (let index = k; index < N; index++) {
    const currentValue: number = nums[index];
    priorityQueue = priorityQueue.filter(
      ([_, valueIndex]) => valueIndex !== index - k
    );

    priorityQueue.push([currentValue, index]);
    slidingWindow.push(Math.max(...priorityQueue.map(([value, _]) => value)));
  }

  return slidingWindow;
}

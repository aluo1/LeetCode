// Question 57. Insert Interval (https://leetcode-cn.com/problems/insert-interval/)

/**
 * 执行用时：116 ms, 在所有 typescript 提交中击败了 33.33% 的用户
 * 内存消耗：42.7 MB , 在所有 typescript 提交中击败了 33.33% 的用户
 *
 * @param {number[][]} intervals
 * @param {number[]} newInterval
 * @returns {number[][]}
 */
function insert(intervals: number[][], newInterval: number[]): number[][] {
  if (!intervals.length) {
    return [newInterval];
  }

  let mergedIntervals: number[][] = [];
  for (let i = 0; i < intervals.length; i++) {
    let currentInterval = intervals[i];
    let [currentStart, currentEnd] = currentInterval;
    let [newStart, newEnd] = newInterval;

    if (currentStart > newEnd) {
      return [...mergedIntervals, newInterval, ...intervals.slice(i)];
    } else if (currentEnd < newStart) {
      mergedIntervals.push(currentInterval);
      continue;
    } else {
      newInterval = [
        Math.min(currentStart, newStart),
        Math.max(currentEnd, newEnd),
      ];
    }
  }

  mergedIntervals.push(newInterval);

  return mergedIntervals;
}

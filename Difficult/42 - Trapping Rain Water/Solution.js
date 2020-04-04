/**
 * Question 42. Trapping Rain Water (https://leetcode-cn.com/problems/trapping-rain-water/)
 * Difficulty: Difficult
 *
 * @param {number[]} height
 * @return {number}
 */
var trap = function(height) {
  return trapBruteForce(height);
};

var trapBruteForce = function(height) {
  // Brute-Force Approach (暴力破解)
  // Acknowledgement: https://leetcode-cn.com/problems/trapping-rain-water/solution/jie-yu-shui-by-leetcode/
  //
  // 执行用时: 200 ms, 在所有 JavaScript 提交中击败了 8.98% 的用户
  // 内存消耗: 34.6 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
  let waterVolume = 0;
  for (let i = 1; i < height.length - 1; i++) {
    let leftMax = 0;
    let rightMax = 0;
    for (let j = i; j >= 0; j--) {
      leftMax = Math.max(leftMax, height[j]);
    }

    for (let j = i; j < height.length; j++) {
      rightMax = Math.max(rightMax, height[j]);
    }

    waterVolume += Math.min(leftMax, rightMax) - height[i];
  }

  return waterVolume;
};

var trapDP = function(height) {
  // Dynamic Programming Approach (动态规划)
  // Acknowledgement: https://leetcode-cn.com/problems/trapping-rain-water/solution/jie-yu-shui-by-leetcode/
  //
  // 执行用时: 112 ms, 在所有 JavaScript 提交中击败了 23.61% 的用户
  // 内存消耗: 36.3 MB, 在所有 JavaScript 提交中击败了 26.77% 的用户
  let waterVolume = 0;
  let leftMaxRecords = [];
  let rightMaxRecords = [];

  leftMaxRecords[0] = height[0];
  for (let i = 1; i < height.length - 1; i++) {
    leftMaxRecords[i] = Math.max(leftMaxRecords[i - 1], height[i]);
  }

  rightMaxRecords[height.length - 1] = height[height.length - 1];
  for (let i = height.length - 2; i >= 0; i--) {
    rightMaxRecords[i] = Math.max(rightMaxRecords[i + 1], height[i]);
  }

  for (let i = 1; i < height.length - 1; i++) {
    waterVolume += Math.min(leftMaxRecords[i], rightMaxRecords[i]) - height[i];
  }

  return waterVolume;
};

var trapTwoPointers = function(height) {
  // Two Pointers (双指针)
  // Acknowledgement: https://leetcode-cn.com/problems/trapping-rain-water/solution/jie-yu-shui-by-leetcode/
  //
  // 执行用时 : 76 ms, 在所有 JavaScript 提交中击败了 63.82% 的用户
  // 内存消耗 : 35.1 MB, 在所有 JavaScript 提交中击败了 86.61% 的用户
  let waterVolume = 0;
  let leftMax = 0;
  let rightMax = 0;
  let leftPointer = 0;
  let rightPointer = height.length - 1;

  while (leftPointer < rightPointer) {
    if (height[leftPointer] < height[rightPointer]) {
      if (height[leftPointer] > leftMax) {
        leftMax = height[leftPointer];
      } else {
        waterVolume += leftMax - height[leftPointer];
      }
      ++leftPointer;
    } else {
      if (height[rightPointer] > rightMax) {
        rightMax = height[rightPointer];
      } else {
        waterVolume += rightMax - height[rightPointer];
      }
      --rightPointer;
    }
  }

  return waterVolume;
};

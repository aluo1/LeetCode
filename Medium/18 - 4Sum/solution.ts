// Question 18. 4Sum (https://leetcode-cn.com/problems/4sum/)

const ARRAY_LENGTH: number = 4;

/**
 * 执行用时：100 ms, 在所有 typescript 提交中击败了 76.32% 的用户
 * 内存消耗：40.4 MB, 在所有 typescript 提交中击败了 20.00% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/4sum/solution/si-shu-zhi-he-by-leetcode-solution/)
 *
 * @param {number[]} nums
 * @param {number} target
 * @returns {number[][]}
 */
function fourSum(nums: number[], target: number): number[][] {
  const numsLength: number = nums.length;

  if (!nums || numsLength < ARRAY_LENGTH) {
    return [];
  }

  let quadruplets: number[][] = [];
  nums.sort((a, b) => a - b);

  for (let i = 0; i < numsLength - 3; i++) {
    const iValue: number = nums[i];
    if (i > 0 && iValue == nums[i - 1]) {
      continue;
    }

    if (iValue + nums[i + 1] + nums[i + 2] + nums[i + 3] > target) {
      break;
    }

    if (
      iValue +
        nums[numsLength - 1] +
        nums[numsLength - 2] +
        nums[numsLength - 3] <
      target
    ) {
      continue;
    }

    for (let j = i + 1; j < numsLength - 2; j++) {
      const jValue: number = nums[j];
      if (j > i + 1 && jValue == nums[j - 1]) {
        continue;
      }

      if (iValue + jValue + nums[j + 1] + nums[j + 2] > target) {
        break;
      }

      if (
        iValue + jValue + nums[numsLength - 2] + nums[numsLength - 1] <
        target
      ) {
        continue;
      }

      let left: number = j + 1;
      let right: number = numsLength - 1;

      while (left < right) {
        let sum = iValue + jValue + nums[left] + nums[right];

        if (sum == target) {
          quadruplets.push([iValue, jValue, nums[left], nums[right]]);

          while (left < right && nums[left] == nums[left + 1]) {
            left++;
          }
          left++;

          while (left < right && nums[right] == nums[right - 1]) {
            right--;
          }
          right--;
        } else if (sum < target) {
          left++;
        } else {
          right--;
        }
      }
    }
  }

  return quadruplets;
}

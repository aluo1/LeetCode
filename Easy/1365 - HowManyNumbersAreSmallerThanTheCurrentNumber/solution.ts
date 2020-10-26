// Question 1365. How Many Numbers Are Smaller Than the Current Number (https://leetcode-cn.com/problems/how-many-numbers-are-smaller-than-the-current-number/)

/**
 * 执行用时：100 ms, 在所有 typescript 提交中击败了 100.00% 的用户
 * 内存消耗：40.3 MB, 在所有 typescript 提交中击败了 25.00% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/how-many-numbers-are-smaller-than-the-current-number/solution/you-duo-shao-xiao-yu-dang-qian-shu-zi-de-shu-zi--2/) method III.
 *
 * @param {number[]} nums
 * @returns {number[]}
 */
function smallerNumbersThanCurrent(nums: number[]): number[] {
  const MAX_DOMAIN_LENGTH: number = 101;
  const domain: number[] = [];

  const NUMS_LENGTH: number = nums.length;
  for (let i = 0; i < NUMS_LENGTH; i++) {
    const num: number = nums[i];
    if (domain[num] && !Number.isNaN(domain[num])) {
      domain[num]++;
    } else {
      domain[num] = 1;
    }
  }

  for (let i = 1; i <= MAX_DOMAIN_LENGTH; i++) {
    const lastValue: number = domain[i - 1] as number;
    const currentValue: number = domain[i] as number;
    domain[i] =
      (lastValue && !Number.isNaN(lastValue) ? lastValue : 0) +
      (!currentValue || Number.isNaN(currentValue) ? 0 : currentValue);
  }

  //   console.log(domain);

  const results: number[] = [];
  for (let i = 0; i < NUMS_LENGTH; i++) {
    const num: number = nums[i] as number;

    results.push(num === 0 ? 0 : (domain[num - 1] as number) || 0);
  }

  return results;
}

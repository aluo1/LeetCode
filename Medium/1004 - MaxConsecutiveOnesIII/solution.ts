// Question 1004. Max Consecutive Ones III (https://leetcode-cn.com/problems/max-consecutive-ones-iii/)

/**
 * 执行用时：104 ms, 在所有 TypeScript 提交中击败了 50.00% 的用户
 * 内存消耗：43.8 MB, 在所有 TypeScript 提交中击败了 90.00% 的用户
 *
 * Acknowledgement: This solution borrows idea from the 
 * [official solution](https://leetcode-cn.com/problems/max-consecutive-ones-iii/solution/fen-xiang-hua-dong-chuang-kou-mo-ban-mia-f76z/)
 * @param {number[]} A
 * @param {number} K
 * @returns {number}
 */
function longestOnes(A: number[], K: number): number {
  let left: number = 0;
  let right: number = 0;
  let result: number = 0;
  const N: number = A.length;

  while (right < N) {
    if (!A[right]) {
      K--;
    }

    while (K < 0) {
      K += A[left] ? 0 : 1;
      left++;
    }

    result = Math.max(result, right - left + 1);
    right++;
  }

  return result;
}

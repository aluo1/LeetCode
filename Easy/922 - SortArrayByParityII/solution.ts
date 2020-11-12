// Question 922. Sort Array By Parity II (https://leetcode-cn.com/problems/sort-array-by-parity-ii/)


/**
 * 执行用时：128 ms, 在所有 typescript 提交中击败了 87.50% 的用户
 * 内存消耗：44.5 MB, 在所有 typescript 提交中击败了 12.50% 的用户
 * 
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/sort-array-by-parity-ii/solution/an-qi-ou-pai-xu-shu-zu-ii-by-leetcode-solution/) 
 * method 2, which is using two pointers.
 *
 * @param {number[]} A
 * @returns {number[]}
 */
function sortArrayByParityII(A: number[]): number[] {
  const N: number = A.length;
  let j: number = 1;

  for (let i = 0; i < N; i += 2) {
    if (A[i] % 2 === 1) {
      while (A[j] % 2 === 1) {
        j += 2;
      }

      [A[i], A[j]] = [A[j], A[i]];
    }
  }

  return A;
}

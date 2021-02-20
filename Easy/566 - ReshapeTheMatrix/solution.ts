// Question 566. Reshape the Matrix (https://leetcode-cn.com/problems/reshape-the-matrix/)

/**
 * 执行用时：116 ms, 在所有 TypeScript 提交中击败了 70.00% 的用户
 * 内存消耗：44.5 MB, 在所有 TypeScript 提交中击败了 50.00% 的用户
 *
 * @param {number[][]} nums
 * @param {number} r
 * @param {number} c
 * @returns {number[][]}
 */
function matrixReshape(nums: number[][], r: number, c: number): number[][] {
  const row: number = nums.length;
  const column: number = nums[0].length;

  if ((row == r && column == c) || row * column != r * c) {
    return nums;
  }

  const reshaped: number[][] = [];
  let newRowIndex: number = 0;
  let newColumnIndex: number = 0;

  let currentRow: number[] = [];
  for (var i = 0; i < row; i++) {
    for (var j = 0; j < column; j++) {
      currentRow[newColumnIndex++] = nums[i][j];

      if (newColumnIndex == c) {
        reshaped[newRowIndex++] = currentRow;
        currentRow = [];
        newColumnIndex = 0;
      }
    }
  }

  return reshaped;
}

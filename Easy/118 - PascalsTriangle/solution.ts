// 118. Pascal's Triangle - 杨辉三角

/**
 * 执行用时：76 ms, 在所有 TypeScript 提交中击败了 90.20% 的用户
 * 内存消耗：40.1 MB, 在所有 TypeScript 提交中击败了 56.00% 的用户
 *
 * @param {number} numRows
 * @returns {number[][]}
 */
function generate(numRows: number): number[][] {
  const pascalTriangle: number[][] = [];
  if (numRows === 0) {
    return pascalTriangle;
  }

  pascalTriangle.push([1]);
  if (numRows === 1) {
    return pascalTriangle;
  }

  pascalTriangle.push([1, 1]);
  if (numRows === 2) {
    return pascalTriangle;
  }

  for (let i = 3; i <= numRows; i++) {
    const currentRow: number[] = [1];
    const previousRow: number[] = pascalTriangle[i - 2];
    for (let j = 1; j < i - 1; j++) {
      currentRow.push(previousRow[j - 1] + previousRow[j]);
    }
    currentRow.push(1);
    pascalTriangle.push(currentRow);
  }

  return pascalTriangle;
}

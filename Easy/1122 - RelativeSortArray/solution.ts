// Question 1122. Relative Sort Array (https://leetcode-cn.com/problems/relative-sort-array/)

/**
 * 执行用时：84 ms, 在所有 typescript 提交中击败了 100.00% 的用户
 * 内存消耗：39.4 MB, 在所有 typescript 提交中击败了 50.00% 的用户
 *
 * @param {number[]} arr1
 * @param {number[]} arr2
 * @returns {number[]}
 */
function relativeSortArray(arr1: number[], arr2: number[]): number[] {
  const valueIndexMap: Map<number, number> = new Map<number, number>();
  for (let i = 0; i < arr2.length; i++) {
    valueIndexMap.set(arr2[i], i);
  }

  arr1.sort((x, y) => {
    if (valueIndexMap.has(x) && valueIndexMap.has(y)) {
      return (
        (valueIndexMap.get(x) as number) - (valueIndexMap.get(y) as number)
      );
    } else if (!valueIndexMap.has(x) && !valueIndexMap.has(y)) {
      return x - y;
    } else if (valueIndexMap.has(x)) {
      return -1;
    } else {
      return 1;
    }
  });

  return arr1;
}

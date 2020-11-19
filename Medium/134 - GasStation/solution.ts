// Question 134. Gas Station (https://leetcode-cn.com/problems/gas-station/)

/**
 * 执行用时：112 ms, 在所有 typescript 提交中击败了 18.75% 的用户
 * 内存消耗：40.5 MB, 在所有 typescript 提交中击败了 6.25% 的用户
 *
 * Acknowledgement: This solution is a TypeScript-version duplicate of the [official solution](https://leetcode-cn.com/problems/gas-station/solution/jia-you-zhan-by-leetcode-solution/)
 *
 * @param {number[]} gas
 * @param {number[]} cost
 * @returns {number}
 */
function canCompleteCircuit(gas: number[], cost: number[]): number {
  const stationsCount: number = gas.length;
  let i: number = 0;

  while (i < stationsCount) {
    let sumOfGas: number = 0;
    let sumOfCost: number = 0;

    let count: number = 0;
    while (count < stationsCount) {
      let j = (i + count) % stationsCount;
      sumOfGas += gas[j];
      sumOfCost += cost[j];

      if (sumOfCost > sumOfGas) {
        break;
      }

      count++;
    }

    if (count === stationsCount) {
      return i;
    } else {
      i = i + count + 1;
    }
  }

  return -1;
}

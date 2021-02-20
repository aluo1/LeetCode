// Question 697. Degree of an Array (https://leetcode-cn.com/problems/degree-of-an-array/)

/**
 * 执行用时：112 ms, 在所有 TypeScript 提交中击败了 44.44% 的用户
 * 内存消耗：47.6 MB, 在所有 TypeScript 提交中击败了 11.11% 的用户
 *
 * @param {number[]} nums
 * @returns {number}
 */
function findShortestSubArray(nums: number[]): number {
  const elementsMapping: Map<number, [number, number, number]> = new Map<
    number,
    [number, number, number]
  >();
  const N: number = nums.length;
  let maxFrequency: number = 0;

  // Create a mapping for elements.
  for (let i = 0; i < N; i++) {
    let element = nums[i];
    if (elementsMapping.has(element)) {
      let [startIndex, endIndex, frequency] = elementsMapping.get(element) as [
        number,
        number,
        number
      ];
      frequency++;
      elementsMapping.set(element, [
        startIndex,
        Math.max(endIndex, i),
        frequency,
      ]);
      maxFrequency = Math.max(frequency, maxFrequency);
    } else {
      elementsMapping.set(element, [i, i, 1]);
      maxFrequency = Math.max(1, maxFrequency);
    }
  }

  let minLength: number = N;
  elementsMapping.forEach(([startIndex, endIndex, frequency], key) => {
    // console.log(`key = ${key}, [${startIndex}, ${endIndex}, ${frequency}]`);
    if (frequency == maxFrequency) {
      minLength = Math.min(minLength, endIndex - startIndex + 1);
    }
  });

  return minLength;
}

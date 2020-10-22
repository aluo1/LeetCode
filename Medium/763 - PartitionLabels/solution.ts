// Question 763. Partition Labels (https://leetcode-cn.com/problems/partition-labels/)

/**
 * 执行用时：104 ms, 在所有 typescript 提交中击败了 66.67% 的用户
 * 内存消耗：45.9 MB, 在所有 typescript 提交中击败了 33.33% 的用户
 *
 * @param {string} S
 * @returns {number[]}
 */
function partitionLabels(S: string): number[] {
  let charactersIndex: Map<string, [number, number]> = new Map<
    string,
    [number, number]
  >();

  const sLength: number = S.length;

  for (let i = 0; i < sLength; i++) {
    const char = S[i];

    if (charactersIndex.has(char)) {
      let [startIndex, endIndex] = charactersIndex.get(char) as [
        number,
        number
      ];
      startIndex = Math.min(startIndex, i);
      endIndex = Math.max(endIndex, i);
      charactersIndex.set(char, [startIndex, endIndex]);
    } else {
      charactersIndex.set(char, [i, Number.MIN_SAFE_INTEGER]);
    }
  }

  //   console.log(charactersIndex);
  const partitionedLabelsLength: number[] = [];

  let currentPartitionStart: number = 0;
  let currentPartitionEnd: number = 0;
  for (let i = 0; i < sLength; ) {
    let char = S[i];
    currentPartitionStart = i;
    let [startIndex, endIndex] = charactersIndex.get(char) as [number, number];

    if (endIndex < 0) {
      endIndex = startIndex;
    }

    for (let j = startIndex; j <= endIndex; j++) {
      const currentChar: string = S[j];
      let [currentCharStartIndex, currentCharEndIndex] = charactersIndex.get(
        currentChar
      ) as [number, number];

      if (currentCharEndIndex < 0) {
        currentCharEndIndex = currentCharStartIndex;
      }

      currentPartitionEnd = Math.max(endIndex, currentCharEndIndex);
      endIndex = Math.max(endIndex, currentCharEndIndex);

      //   console.log(
      //     `currentPartitionEnd = ${currentPartitionEnd}, endIndex = ${endIndex}`
      //   );
    }

    partitionedLabelsLength.push(
      currentPartitionEnd - currentPartitionStart + 1
    );
    i = currentPartitionEnd + 1;
    // console.log(
    //   `partitionedLabelsLength: [${partitionedLabelsLength.join(
    //     ", "
    //   )}], currentPartitionEnd = ${currentPartitionEnd}, i = ${i}`
    // );
  }

  //   console.log(partitionedLabelsLength);
  return partitionedLabelsLength;
}

/**
 * 执行用时：108 ms, 在所有 typescript 提交中击败了 66.67% 的用户
 * 内存消耗：45.6 MB, 在所有 typescript 提交中击败了 33.33% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/partition-labels/solution/hua-fen-zi-mu-qu-jian-by-leetcode-solution/)
 * 
 * @param {string} S
 * @returns {number[]}
 */
function partitionLabels(S: string): number[] {
  let charactersIndex: Map<string, [number, number]> = new Map<
    string,
    [number, number]
  >();

  const sLength: number = S.length;

  for (let i = 0; i < sLength; i++) {
    const char = S[i];

    if (charactersIndex.has(char)) {
      let [startIndex, endIndex] = charactersIndex.get(char) as [
        number,
        number
      ];
      startIndex = Math.min(startIndex, i);
      endIndex = Math.max(endIndex, i);
      charactersIndex.set(char, [startIndex, endIndex]);
    } else {
      charactersIndex.set(char, [i, Number.MIN_SAFE_INTEGER]);
    }
  }

  let currentPartitionStart: number = 0;
  let currentPartitionEnd: number = 0;

  let partitionedLabelsLength: number[] = [];
  for (let i = 0; i < sLength; i++) {
    let char = S[i];
    let [startIndex, endIndex] = charactersIndex.get(char) as [number, number];
    
    endIndex = Math.max(startIndex, endIndex);
    currentPartitionEnd = Math.max(currentPartitionEnd, endIndex);

    if (i === currentPartitionEnd) {
      partitionedLabelsLength.push(
        currentPartitionEnd - currentPartitionStart + 1
      );
      currentPartitionStart = currentPartitionEnd + 1;
    }
  }

  return partitionedLabelsLength;
}

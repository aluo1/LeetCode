/**
 * Question 977. Squares of a Sorted Array (https://leetcode-cn.com/problems/squares-of-a-sorted-array/)
 *
 * 执行用时：144 ms, 在所有 typescript 提交中击败了 72.62% 的用户
 * 内存消耗：45.8 MB, 在所有 typescript 提交中击败了 5.00% 的用户
 *
 * @param {number[]} A
 * @returns {number[]}
 */
function sortedSquares(A: number[]): number[] {
  return A.map((a) => a * a).sort((a, b) => a - b);
}

/**
 * 执行用时：128 ms, 在所有 typescript 提交中击败了 92.86% 的用户
 * 内存消耗：46.7 MB, 在所有 typescript 提交中击败了 5.00% 的用户
 *
 * @param {number[]} A
 * @returns {number[]}
 */
function sortedSquaresTwoPointers(A: number[]): number[] {
  if (!A.length) {
    return A;
  }

  // This array contains no negative number.
  if (A[0] >= 0) {
    return A.map((a) => a * a);
  }

  const N: number = A.length;
  // This array contains no positive number.
  if (A[N - 1] < 0) {
    const sorted: number[] = [];

    for (let i = N - 1; i >= 0; i--) {
      const currentValue: number = A[i];
      sorted.push(currentValue * currentValue);
    }

    return sorted;
  }

  let negativeIndex: number = 0;
  let positiveIndex: number = 0;
  let sorted: number[] = [];

  while (positiveIndex < N) {
    if (A[positiveIndex] >= 0) {
      negativeIndex = positiveIndex - 1;
      break;
    }

    positiveIndex++;
  }

  let positiveSquare: number = A[positiveIndex] * A[positiveIndex];
  let negativeSquare: number = A[negativeIndex] * A[negativeIndex];

  while (positiveIndex < N || negativeIndex >= 0) {
    // console.log(
    //   `positiveIndex = ${positiveIndex}, positiveSquare = ${positiveSquare}, negativeIndex = ${negativeIndex}, negativeSquare = ${negativeSquare}`
    // );

    if (positiveSquare < negativeSquare) {
      sorted.push(positiveSquare);
      positiveIndex++;

      if (positiveIndex < N) {
        const currentValue: number = A[positiveIndex];
        positiveSquare = currentValue * currentValue;
      } else {
        positiveSquare = Number.MAX_SAFE_INTEGER;
      }
    } else if (positiveSquare === negativeSquare) {
      sorted.push(positiveSquare);
      positiveIndex++;

      if (positiveIndex < N) {
        const currentValue: number = A[positiveIndex];
        positiveSquare = currentValue * currentValue;
      } else {
        positiveSquare = Number.MAX_SAFE_INTEGER;
      }

      sorted.push(negativeSquare);
      negativeIndex--;

      if (negativeIndex >= 0) {
        const currentValue: number = A[negativeIndex];
        negativeSquare = currentValue * currentValue;
      } else {
        negativeSquare = Number.MAX_SAFE_INTEGER;
      }
    } else {
      sorted.push(negativeSquare);
      negativeIndex--;

      if (negativeIndex >= 0) {
        const currentValue: number = A[negativeIndex];
        negativeSquare = currentValue * currentValue;
      } else {
        negativeSquare = Number.MAX_SAFE_INTEGER;
      }
    }
  }

  return sorted;
}

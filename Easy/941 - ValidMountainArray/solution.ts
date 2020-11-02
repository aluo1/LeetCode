// Question 941. Valid Mountain Array (https://leetcode-cn.com/problems/valid-mountain-array/)


/**
 * Execution failed due to internal error.
 *
 * @param {number[]} A
 * @returns {boolean}
 */
function validMountainArray(A: number[]): boolean {
  const aLength: number = A.length;
  if (aLength < 3) {
    return false;
  }

  let peak: number = A[0];
  let previousValue: number = A[0];
  let declining: boolean = false;

  for (let i = 1; i < aLength; i++) {
    const currentValue: number = A[i];
    if (currentValue === previousValue) {
      return false;
    }

    if (declining) {
      if (currentValue > previousValue) {
        return false;
      }
    } else {
      if (currentValue > peak) {
        peak = currentValue;
      } else {
        declining = true;
      }
    }

    previousValue = currentValue;
  }

  return declining;
}

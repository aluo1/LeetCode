// Question 17. Letter Combinations of a Phone Number (https://leetcode-cn.com/problems/letter-combinations-of-a-phone-number/)

const NUM_LETTERS_MAPPING: Map<string, string[]> = new Map([
  ["2", ["a", "b", "c"]],
  ["3", ["d", "e", "f"]],
  ["4", ["g", "h", "i"]],
  ["5", ["j", "k", "l"]],
  ["6", ["m", "n", "o"]],
  ["7", ["p", "q", "r", "s"]],
  ["8", ["t", "u", "v"]],
  ["9", ["w", "x", "y", "z"]],
]);

/**
 * Backtracking Algorithm
 *
 * Acknowledgement: This solution borrows the idea from the [official solution](https://leetcode-cn.com/problems/letter-combinations-of-a-phone-number/solution/dian-hua-hao-ma-de-zi-mu-zu-he-by-leetcode-solutio/)
 *
 * 执行用时：84 ms, 在所有 typescript 提交中击败了 40.38% 的用户
 * 内存消耗： 38 MB, 在所有 typescript 提交中击败了 13.64% 的用户
 *
 * @param {string} digits
 * @returns {string[]}
 */
function letterCombinations(digits: string): string[] {
  const combinations: string[] = [];
  if (!digits.length) {
    return combinations;
  }

  backtrack(combinations, digits, "", 0);

  return combinations;
}

function backtrack(
  combinations: string[],
  digits: string,
  combination: string,
  digitIndex: number
): void {
  if (combination.length === digits.length) {
    combinations.push(combination);
    return;
  }

  const digit: string = digits[digitIndex] as string;
  const digitLetters: string[] = NUM_LETTERS_MAPPING.get(digit) as string[];

  for (const letter of digitLetters) {
    combination = `${combination}${letter}`;
    backtrack(combinations, digits, combination, digitIndex + 1);
    combination = combination
      .split("")
      .filter((_, idx) => idx !== digitIndex)
      .reduce((prev, current) => prev + current, "");
  }
}

// Question 290. Word Pattern (https://leetcode-cn.com/problems/word-pattern/)


/**
 * 执行用时：76 ms, 在所有 TypeScript 提交中击败了 94.44% 的用户
 * 内存消耗：39.3 MB, 在所有 TypeScript 提交中击败了 94.44% 的用户
 *
 * @param {string} pattern
 * @param {string} s
 * @returns {boolean}
 */
function wordPattern(pattern: string, s: string): boolean {
  const patternWord: Map<string, string> = new Map<string, string>();
  const wordPattern: Map<string, string> = new Map<string, string>();

  if (pattern.length !== s.length) {
    return false;
  }

  for (let i = 0; i < pattern.length; i++) {
    const currentPattern: string = pattern[i];
    const currentWord: string = s[i];

    // console.log(
    //   `currentPattern = ${currentPattern}, currentWord = ${currentWord}`
    // );

    if (
      (patternWord.has(currentPattern) &&
        patternWord.get(currentPattern) !== currentWord) ||
      (wordPattern.has(currentWord) &&
        wordPattern.get(currentWord) !== currentPattern)
    ) {
      return false;
    } else {
      patternWord.set(currentPattern, currentWord);
      wordPattern.set(currentWord, currentPattern);
    }
  }

  return true;
}

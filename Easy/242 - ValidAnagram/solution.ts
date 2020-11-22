// Question 242. Valid Anagram (https://leetcode-cn.com/problems/valid-anagram/)

/**
 * 执行用时：88 ms, 在所有 typescript 提交中击败了 97.80% 的用户
 * 内存消耗：40.3 MB, 在所有 typescript 提交中击败了 72.53% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution] 
 * (https://leetcode-cn.com/problems/valid-anagram/solution/you-xiao-de-zi-mu-yi-wei-ci-by-leetcode-solution/) 
 * method II.
 * 
 * @param {string} s
 * @param {string} t
 * @returns {boolean}
 */
function isAnagram(s: string, t: string): boolean {
  const sLength: number = s.length;

  if (sLength !== t.length) {
    return false;
  }

  const charactersFreq: number[] = [];
  for (let i = 0; i < 26; i++) {
    charactersFreq[i] = 0;
  }

  for (let i = 0; i < sLength; i++) {
    charactersFreq[
      (s.codePointAt(i) as number) - ("a".codePointAt(0) as number)
    ]++;
  }

  for (let i = 0; i < sLength; i++) {
    const index: number =
      (t.codePointAt(i) as number) - ("a".codePointAt(0) as number);
    charactersFreq[index]--;

    if (charactersFreq[index] < 0) {
      return false;
    }
  }

  return true;
}

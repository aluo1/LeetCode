/**
 * Question 1002. Find Common Characters (https://leetcode-cn.com/problems/find-common-characters/)
 *
 * 执行用时：112 ms, 在所有 typescript 提交中击败了 42.86% 的用户
 * 内存消耗：43.1 MB, 在所有 typescript 提交中击败了 66.67% 的用户
 *
 * @param {string[]} A
 * @returns {string[]}
 */
function commonChars(A: string[]): string[] {
  const N: number = A.length;

  if (N === 0) {
    return [];
  }

  const firstString: string = A[0];

  let wordFreqDictionary: Map<string, number> = new Map<string, number>();
  for (let str of firstString) {
    if (wordFreqDictionary.has(str)) {
      wordFreqDictionary.set(str, (wordFreqDictionary.get(str) as number) + 1);
    } else {
      wordFreqDictionary.set(str, 1);
    }
  }

  for (let i = 1; i < N; i++) {
    const word = A[i];

    let frequencyDictionary: Map<string, number> = new Map<string, number>();

    for (let str of word) {
      if (frequencyDictionary.has(str)) {
        frequencyDictionary.set(
          str,
          Math.min(
            (frequencyDictionary.get(str) as number) + 1,
            wordFreqDictionary.has(str)
              ? (wordFreqDictionary.get(str) as number)
              : 0
          )
        );
      } else {
        frequencyDictionary.set(
          str,
          Math.min(
            1,
            wordFreqDictionary.has(str)
              ? (wordFreqDictionary.get(str) as number)
              : 0
          )
        );
      }
    }

    wordFreqDictionary = frequencyDictionary;
  }

  const commonCharacters: string[] = [];

  for (let [word, frequency] of wordFreqDictionary.entries()) {
    for (let i = 0; i < frequency; i++) {
      commonCharacters.push(word);
    }
  }

  return commonCharacters;
}

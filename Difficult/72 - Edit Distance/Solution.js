/**
 * Question 72. Edit Distance (https://leetcode-cn.com/problems/edit-distance/)
 * Difficulty: Difficult/Hard
 *
 * 执行用时: 108 ms, 在所有 JavaScript 提交中击败了 47.47% 的用户
 * 内存消耗: 41.7 MB, 在所有 JavaScript 提交中击败了 33.33% 的用户
 * @param {string} word1
 * @param {string} word2
 * @return {number}
 */
var minDistance = function (word1, word2) {
  const word1Length = word1.length;
  const word2Length = word2.length;

  if (word1Length * word2Length === 0) {
    return word1Length + word2Length;
  }

  let dp = [];

  for (let i = 0; i <= word1Length; i++) {
    dp[i] = [i];
  }

  for (let j = 0; j <= word2Length; j++) {
    dp[0][j] = j;
  }

  for (let i = 1; i <= word1Length; i++) {
    for (let j = 1; j <= word2Length; j++) {
      const left = 1 + dp[i - 1][j];
      const bottom = 1 + dp[i][j - 1];
      let bottomLeft = dp[i - 1][j - 1];

      if (word1[i - 1] !== word2[j - 1]) {
        bottomLeft += 1;
      }

      dp[i][j] = Math.min(left, bottom, bottomLeft);
    }
  }

  return dp[word1Length][word2Length];
};

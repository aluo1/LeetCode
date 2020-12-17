// Question 714. Best Time to Buy and Sell Stock with Transaction Fee (https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/)

/**
 * 执行用时：116 ms, 在所有 TypeScript 提交中击败了 14.29% 的用户
 * 内存消耗：47.9 MB, 在所有 TypeScript 提交中击败了 57.14% 的用户
 *
 * Acknowledgement: All these 3 solutions are TypeScript-duplicate of the
 * [official solution] (https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/solution/mai-mai-gu-piao-de-zui-jia-shi-ji-han-sh-rzlz/)
 *
 * @param {number[]} prices
 * @param {number} fee
 * @returns {number}
 */
function maxProfit(prices: number[], fee: number): number {
  const N: number = prices.length;
  let buy: number = prices[0] + fee;
  let profit: number = 0;

  for (let i = 0; i < N; i++) {
    if (prices[i] + fee < buy) {
      buy = prices[i] + fee;
    } else if (prices[i] > buy) {
      profit += prices[i] - buy;
      buy = prices[i];
    }
  }

  return profit;
}

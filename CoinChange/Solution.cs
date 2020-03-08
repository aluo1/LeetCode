public class Solution {
    public int CoinChange(int[] coins, int amount) {
        
    }

    public int CoinChangeFirstTry(int[] coins, int amount) {
        /// Failed
        /// Input: [186,419,83,408], 6249
        /// Output: -1
        /// Expected Output: 20
    
        // Sort the coins descending.
        Array.Sort(coins);
        Array.Reverse(coins);

        int coinsCount = 0;

        foreach (int coin in coins) {
            int currentCoinCount = amount / coin;
            amount -= currentCoinCount * coin;
            coinsCount += currentCoinCount;
        }

        return amount != 0 ? -1 : coinsCount;
    }
}
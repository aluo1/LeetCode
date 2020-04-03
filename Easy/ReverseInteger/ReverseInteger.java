/**
 * Question 7. Reverse Integer (https://leetcode-cn.com/problems/reverse-integer/)
 * Difficulty: Easy
 * 
 * 执行用时: 1 ms, 在所有 Java 提交中击败了 100.00% 的用户
 * 内存消耗: 36.9 MB, 在所有 Java 提交中击败了 5.08% 的用户
 */
class Solution {
    public int reverse(int x) {
        long num = x;
        long reversedNum = 0;
        int isNegative;
        boolean isFirstNum = true;

        if (x < 0) {
            isNegative = -1;
            num = -1 * num;
        } else {
            isNegative = 1;
        }

        while (num != 0) {
            if (isFirstNum) {
                reversedNum = num % 10;
                isFirstNum = false;
            } else {
                reversedNum = reversedNum * 10 + num % 10;
            }
            num /= 10;
        }
        reversedNum *= isNegative;

        if (reversedNum > Integer.MAX_VALUE || reversedNum < Integer.MIN_VALUE) {
            return 0;
        }

        return (int) reversedNum;
    }
}
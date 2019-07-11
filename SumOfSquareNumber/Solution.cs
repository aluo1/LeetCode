public class Solution {
    public bool JudgeSquareSum(int c) {
        int sqrtOfC = (int) Math.Ceiling(Math.Sqrt(c));
        for (int i = sqrtOfC; i >= 0; i--) {
            for (int j = 0; j <= i; j++) {
                if (i*i + j*j == c) {
                    return true;
                }
            }
        }
        
        return false;
    }
}
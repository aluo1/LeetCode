public class Solution {
    public bool JudgeSquareSum(int c) {
        int sqrtOfC = (int) Math.Sqrt(c);
        for (int i = 0; i <= sqrtOfC; i++) {
            for (int j = sqrtOfC; j >= 0; j--) {
                if (i*i + j*j == c) {
                    return true;
                }
            }
        }
        
        return false;
    }
}
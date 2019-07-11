public class Solution {
    public bool JudgeSquareSum(int c) {
        int sqrtOfC = (int) Math.Ceiling(Math.Sqrt(c));
        int breakPoint = sqrtOfC/2+1;
                
        for (int i = breakPoint; i >= 0; i--) {
            for (int j = 0; j <= breakPoint; j++) {
                if (i*i + j*j == c) {
                    return true;
                }
            }
        }
        
        return false;
    }
}
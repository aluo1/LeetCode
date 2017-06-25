public class ReverseInteger {
    public int reverse(int x) {
        int num = x;
        int reversedNum = 0;
        int isNegative;
        boolean isFirstNum = true;


        if (x < 0) {
            isNegative = -1;
            num = -1 * num;
        }
        else {
            isNegative = 1;
        }

        while (num != 0) {
            if (isFirstNum) {
                reversedNum = num % 10;
                isFirstNum = false;
            }
            else {
                reversedNum = reversedNum * 10 + num % 10;
            }
            num /= 10;
        }
        reversedNum *= isNegative;

        return reversedNum;
    }
}
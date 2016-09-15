/**
 * Author: An Luo
 * email: aluo1.developer@gmail.com
 *
 * Notes: This code is not yet optimized.
 *
 * Problem Website: https://leetcode.com/problems/two-sum/
 *
 * Acknowledgement: This code is built upon the skeleton provided by LeetCode
 *
 */

public class TwoSum {
    public int[] twoSum(int[] nums, int target) {
        int length = nums.length;
        int indexOne, indexTwo;
        int result[] = new int[2];
        boolean found = false;

        for (indexOne = 0; indexOne < length; indexOne++) {
            for (indexTwo = indexOne + 1; indexTwo < length; indexTwo++) {
                if ((nums[indexOne] + nums[indexTwo]) == target) {
                    result[0] = indexOne;
                    result[1] = indexTwo;
                    found = true;
                    break;
                }
            }

            if (found) {
                break;
            }
        }

        return result;
    }
}
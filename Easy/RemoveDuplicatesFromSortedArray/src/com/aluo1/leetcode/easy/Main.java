package com.aluo1.leetcode.easy;

public class Main {

    public static void main(String[] args) {
	// write your code here

    }

    public static int removeDuplicates(int[] nums) {
        int elementNumber = 0;
        int indexOne = 0;

        if (nums.length == 0) {
            return 0;
        } else if (nums.length == 1) {
            return 1;
        } else if (nums.length == 2) {
            return nums[0] == nums[1] ? 1 : 2;
        } else {
            while (indexOne != (nums.length-2)) {
                if (nums[indexOne] != nums[indexOne+1]) {
                    elementNumber++;
                }
                indexOne++;
            }
            return elementNumber;
        }
    }
}

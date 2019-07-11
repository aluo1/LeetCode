public class Solution {
    public int PivotIndex(int[] nums) {
        int pivotIndex = -1;
        int midOfTheArray = (int) Math.Ceiling(nums.Length / 2d);

        // Start from the mid, move towards start of the array.
        for (int i = midOfTheArray; i > 0; i--) {
            int sumOfLeft = 0;
            int sumOfRight = 0;
            bool broken = false;
            
            for (int j = 0; j < i; j++) {
                sumOfLeft += nums[j];
            }
            
            // this is the right most index, skip.
            if (i + 1 > nums.Length) {
                continue;
            }
            
            for (int j = i + 1; j < nums.Length; j++) {
                sumOfRight += nums[j];
            }
            
            if (sumOfLeft == sumOfRight) {
                pivotIndex = i;
            }
        }
        
        if (pivotIndex != -1) {
            return pivotIndex;
        }
        
        // Start from the mid, move towards end of the array.
        for (int i = midOfTheArray; i < nums.Length; i++) {
            int sumOfLeft = 0;
            int sumOfRight = 0;
            bool broken = false;
            
            for (int j = 0; j < i; j++) {
                sumOfLeft += nums[j];
            }
            
            // this is the right most index, skip.
            if (i + 1 > nums.Length) {
                continue;
            }
            
            for (int j = i + 1; j < nums.Length; j++) {
                sumOfRight += nums[j];
            }
            
            if (sumOfLeft == sumOfRight) {
                return i;
            }
        }
        
        return -1;
    }
}
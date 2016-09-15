/**
 * Note: The returned array must be malloced, assume caller calls free().
 *
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

#include <stdio.h>

#define true 1
#define false 0

int* twoSum(int* nums, int numsSize, int target) {
    int *returnedIndex;
    int indexOne;
    int indexTwo;
    int found = false;
    
    returnedIndex = (int *) malloc(sizeof(int) * 2);
    for (indexOne = 0; indexOne < numsSize; indexOne++) {
        for (indexTwo = indexOne + 1; indexTwo < numsSize; indexTwo++) {
            if ((nums[indexOne] + nums[indexTwo]) == target) {
                returnedIndex[0] = indexOne;
                returnedIndex[1] = indexTwo;
                found = true;
                break;
            }
        }

        if (found) {
            break;
        }
    }

    return returnedIndex;
}

int main(int argc, char *argv[]) {
    int *result;
    
    result = twoSum([2, 7, 11, 15], 4, 9);
    printf("Given list Given nums = [2, 7, 11, 15], target = 9, the result is [%d, %d]", result[0], result[1]);

    result = twoSum([3, 2, 4], 3, 6);
    printf("Given list Given nums = [3, 2, 4], target = 6, the result is [%d, %d]", result[0], result[1]);

    result = twoSum([3, 2, 4], 3, 7);
    printf("Given list Given nums = [3, 2, 4], target = 7, the result is [%d, %d]", result[0], result[1]);

    result = twoSum([-1,-2,-3,-4,-5], 5, -8);
    printf("Given list Given nums = [-1,-2,-3,-4,-5], target = -8, the result is [%d, %d]", result[0], result[1]);
    return 0;
}

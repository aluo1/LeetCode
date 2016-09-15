"""
    Author: An Luo
    email: aluo1.developer@gmail.com
    
    Notes: This code is not yet optimized.
    Problem Website: https://leetcode.com/problems/two-sum/
    Acknowledgement: This code is built upon the skeleton provided by LeetCode    
"""

class Solution(object):
    def twoSum(self, nums, target):
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[int]
        """
        result = [int] * 2
        length = len(nums)
        found = False

        for indexOne in range(length):
            for indexTwo in range(indexOne+1, length):
                if ((nums[indexOne] + nums[indexTwo]) == target):
                    result[0] = indexOne
                    result[1] = indexTwo
                    found = True
                    break
            if (found):
                break
        return result

# Test case
solution = Solution()

result = solution.twoSum([2, 7, 11, 15], 9)
print "Given list Given nums = [2, 7, 11, 15], target = 9, the result is [", result[0], ",", result[1], "]"

result = solution.twoSum([3, 2, 4], 6)
print "Given list Given nums = [3, 2, 4], target = 6, the result is [", result[0], ",", result[1], "]"

result = solution.twoSum([3, 2, 4], 7)
print "Given list Given nums = [3, 2, 4], target = 7, the result is [", result[0], ",", result[1], "]"

result = solution.twoSum([-1,-2,-3,-4,-5], -8)
print "Given list Given nums = [-1,-2,-3,-4,-5], target = -8, the result is [", result[0], ",", result[1], "]"
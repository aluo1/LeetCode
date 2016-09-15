"""
    Author: An Luo
    email: aluo1.developer@gmail.com
    
    Notes: This code is not yet optimized.
    Problem Website: https://leetcode.com/problems/two-sum/
    Acknowledgement: This code is built upon the skeleton provided by LeetCode    
"""

class TwoSum(object):
    def twoSum(self, nums, target):
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[int]
        """
        result = [int] * 2
        length = len(nums)
        found = False

        for index_one in range(length):
            for index_two in range(index_one+1, length):
                if ((nums[index_one] + nums[index_two]) == target):
                    result[0] = index_one
                    result[1] = index_two
                    found = True
                    break
            if (found):
                break
        return result

# Test case
solution = TwoSum()

result = solution.twoSum([2, 7, 11, 15], 9)
print "Given list Given nums = [2, 7, 11, 15], target = 9, the result is [", result[0], ",", result[1], "]"

result = solution.twoSum([3, 2, 4], 6)
print "Given list Given nums = [3, 2, 4], target = 6, the result is [", result[0], ",", result[1], "]"

result = solution.twoSum([3, 2, 4], 7)
print "Given list Given nums = [3, 2, 4], target = 7, the result is [", result[0], ",", result[1], "]"

result = solution.twoSum([-1,-2,-3,-4,-5], -8)
print "Given list Given nums = [-1,-2,-3,-4,-5], target = -8, the result is [", result[0], ",", result[1], "]"
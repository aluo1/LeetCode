"""
LCP 1. 猜数字 (https://leetcode-cn.com/problems/guess-numbers/)
Difficulty: Easy
"""


class Solution:
    """
    执行用时: 28 ms, 在所有 Python3 提交中击败了 87.11% 的用户
    内存消耗: 13.6 MB , 在所有 Python3 提交中击败了 15.42% 的用户
    """

    def game(self, guess: List[int], answer: List[int]) -> int:
        correct_count = 0

        for i in range(len(guess)):
            if guess[i] == answer[i]:
                correct_count += 1

        return correct_count

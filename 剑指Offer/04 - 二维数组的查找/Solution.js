/**
 * 面试题04. 二维数组中的查找 (https://leetcode-cn.com/problems/er-wei-shu-zu-zhong-de-cha-zhao-lcof/)
 * Difficulty: Easy
 * 执行用时: 68 ms, 在所有 JavaScript 提交中击败了 84.01% 的用户
 * 内存消耗: 37.4 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 * 
 * @param {number[][]} matrix
 * @param {number} target
 * @return {boolean}
 */
var findNumberIn2DArray = function(matrix, target) {
    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            if (matrix[i][j] === target) {
                return true;
            }
        }        
    }

    return false;
};
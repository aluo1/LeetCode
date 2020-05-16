/**
 * Question 836. Rectangle Overlap (https://leetcode-cn.com/problems/rectangle-overlap/)
 *
 * 执行用时 : 60 ms, 在所有 JavaScript 提交中击败了 79.85% 的用户
 * 内存消耗 : 33.8 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 * 
 * @param {number[]} rec1
 * @param {number[]} rec2
 * @return {boolean}
 */
var isRectangleOverlap = function (rec1, rec2) {
  const [x1, y1, x2, y2] = rec1;
  const [x3, y3, x4, y4] = rec2;

  return !(x1 >= x4 || y1 >= y4 || x3 >= x2 || y3 >= y2);
};

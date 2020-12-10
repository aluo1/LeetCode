// Question 860. Lemonade Change (https://leetcode-cn.com/problems/lemonade-change/)

/**
 * 执行用时：84 ms, 在所有 TypeScript 提交中击败了 100.00% 的用户
 * 内存消耗：40.8 MB, 在所有 TypeScript 提交中击败了 56.52% 的用户
 *
 * @param {number[]} bills
 * @returns {boolean}
 */
function lemonadeChange(bills: number[]): boolean {
  let five: number = 0;
  let ten: number = 0;

  for (let i = 0; i < bills.length; i++) {
    let bill: number = bills[i];

    if (bill == 20) {
      if (ten > 0 && five > 0) {
        ten--;
        five--;
      } else if (five >= 3) {
        five -= 3;
      } else {
        return false;
      }
    } else if (bill == 10) {
      if (five > 0) {
        five--;
        ten = ten + 1;
      } else {
        return false;
      }
    } else {
      five = five + 1;
    }
  }

  return true;
}

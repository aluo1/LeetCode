// Question 605. Can Place Flowers (https://leetcode-cn.com/problems/can-place-flowers/)

/**
 * 执行用时：88 ms, 在所有 TypeScript 提交中击败了 86.67% 的用户
 * 内存消耗：40.8 MB, 在所有 TypeScript 提交中击败了 80.00% 的用户
 *
 * Acknowledgement: The idea of increasing i by 2 is borrowed from the [solution](https://leetcode-cn.com/problems/can-place-flowers/solution/qi-si-miao-jie-by-heroding-h7m0/)
 * 
 * @param {number[]} flowerbed
 * @param {number} n
 * @returns {boolean}
 */
function canPlaceFlowers(flowerbed: number[], n: number): boolean {
  if (!n) {
    return true;
  }

  const plotsCount: number = flowerbed.length;

  for (let i = 0; i < plotsCount; i += 2) {
    if (!flowerbed[i]) {
      if (
        (i - 1 < 0 || (i - 1 >= 0 && flowerbed[i - 1] == 0)) &&
        (i + 1 >= plotsCount || (i + 1 < plotsCount && flowerbed[i + 1] == 0))
      ) {
        n--;
        if (!n) {
          return true;
        }
      } else {
        i++;
      }
    }
  }

  return n == 0;
}

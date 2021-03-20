// Question 1603. Design Parking System (https://leetcode-cn.com/problems/design-parking-system/)

/**
 * 执行用时：152 ms, 在所有 TypeScript 提交中击败了 100.00% 的用户
 * 内存消耗：45.3 MB, 在所有 TypeScript 提交中击败了 96.15% 的用户
 *
 * @class ParkingSystem
 */
class ParkingSystem {
  private BIG_INDEX: number = 1;
  private MEDIUM_INDEX: number = 2;
  private SMALL_INDEX: number = 3;
  #parkingSpaces: number[];

  constructor(big: number, medium: number, small: number) {
    this.#parkingSpaces = [0, 0, 0, 0];
    this.#parkingSpaces[this.BIG_INDEX] = big;
    this.#parkingSpaces[this.MEDIUM_INDEX] = medium;
    this.#parkingSpaces[this.SMALL_INDEX] = small;
  }

  addCar(carType: number): boolean {
    const remainingSpaces: number = this.#parkingSpaces[carType] - 1;

    if (remainingSpaces >= 0) {
      this.#parkingSpaces[carType] = remainingSpaces;
      return true;
    }

    return false;
  }
}

/**
 * Your ParkingSystem object will be instantiated and called as such:
 * var obj = new ParkingSystem(big, medium, small)
 * var param_1 = obj.addCar(carType)
 */

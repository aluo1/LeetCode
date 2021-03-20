// Question 706. Design HashMap (https://leetcode-cn.com/problems/design-hashmap/)

/**
 * 执行用时：280 ms, 在所有 TypeScript 提交中击败了 21.05% 的用户
 * 内存消耗：51.9 MB, 在所有 TypeScript 提交中击败了 10.53% 的用户
 *
 * @class MyHashMap
 */
class MyHashMap {
  #HASHSET_BASE: number = 2027;
  #hashMapList: number[][][] = [];

  private calculateHash(value: number): number {
    return value % this.#HASHSET_BASE;
  }

  constructor() {
    for (let i = 0; i < this.#HASHSET_BASE; i++) {
      this.#hashMapList[i] = [];
    }
  }

  put(key: number, value: number): void {
    const hashValue: number = this.calculateHash(key);

    this.#hashMapList[hashValue] = [
      ...this.#hashMapList[hashValue].filter(([hashKey, _]) => hashKey !== key),
      [key, value],
    ];
  }

  get(key: number): number {
    const hashValue: number = this.calculateHash(key);
    var searchResult = this.#hashMapList[hashValue].find(
      ([hashKey]) => hashKey === key
    );

    return searchResult && searchResult.length ? searchResult[1] : -1;
  }

  remove(key: number): void {
    const hashValue: number = this.calculateHash(key);

    this.#hashMapList[hashValue] = this.#hashMapList[hashValue].filter(
      ([hashKey, _]) => hashKey !== key
    );
  }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * var obj = new MyHashSet()
 * obj.add(key)
 * obj.remove(key)
 * var param_3 = obj.contains(key)
 */

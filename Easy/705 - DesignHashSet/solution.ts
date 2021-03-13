// Question 705. Design HashSet (https://leetcode-cn.com/problems/design-hashset/)

/**
 * 执行用时：256 ms, 在所有 TypeScript 提交中击败了 50.00% 的用户
 * 内存消耗：50.1 MB, 在所有 TypeScript 提交中击败了 16.67% 的用户
 *
 * @class MyHashSet
 */
class MyHashSet {
  #HASHSET_BASE: number = 2027;
  #hashSetList: number[][] = [];

  private calculateHash(value: number): number {
    return value % this.#HASHSET_BASE;
  }

  constructor() {
    for (let i = 0; i < this.#HASHSET_BASE; i++) {
      this.#hashSetList[i] = [];
    }
  }

  add(key: number): void {
    const hashValue: number = this.calculateHash(key);

    if (!this.contains(key)) {
      this.#hashSetList[hashValue].push(key);
    }
  }

  remove(key: number): void {
    const hashValue: number = this.calculateHash(key);

    const valueListOfHash: number[] = this.#hashSetList[hashValue];
    this.#hashSetList[hashValue] = valueListOfHash.filter(
      (valueOfHash) => valueOfHash !== key
    );
  }

  contains(key: number): boolean {
    const hashValue: number = this.calculateHash(key);

    return this.#hashSetList[hashValue].indexOf(key) !== -1;
  }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * var obj = new MyHashSet()
 * obj.add(key)
 * obj.remove(key)
 * var param_3 = obj.contains(key)
 */

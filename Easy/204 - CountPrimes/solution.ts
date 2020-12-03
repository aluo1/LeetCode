// Question 204. Count Primes (https://leetcode-cn.com/problems/count-primes/)

/**
 * 执行用时：128 ms, 在所有 typescript 提交中击败了 91.49% 的用户
 * 内存消耗：52.2 MB, 在所有 typescript 提交中击败了 6.52% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/count-primes/solution/ji-shu-zhi-shu-by-leetcode-solution/)
 *
 * @param {number} n
 * @returns {number}
 */
function countPrimes(n: number): number {
  let isPrime: boolean[] = new Array<boolean>(n);
  isPrime.fill(true, 0, n);

  let count: number = 0;
  for (let i = 2; i < n; i++) {
    if (isPrime[i]) {
      count++;
      if (i < n / i) {
        for (let j = i * i; j < n; j += i) {
          isPrime[j] = false;
        }
      }
    }
  }

  return count;
}

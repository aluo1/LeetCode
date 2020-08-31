/**
 * Question 841. Keys and Rooms (https://leetcode-cn.com/problems/keys-and-rooms/)
 *
 * 执行用时：92 ms, 在所有 typescript 提交中击败了 33.33% 的用户
 * 内存消耗：39.6 MB, 在所有 typescript 提交中击败了 40.00% 的用户
 *
 * @param {number[][]} rooms
 * @returns {boolean}
 */
function canVisitAllRooms(rooms: number[][]): boolean {
  const keys: number[] = [...rooms[0]];
  const unlockedRooms: Map<number, boolean> = new Map([[0, true]]);

  while (keys.length) {
    const key: number = keys.shift() as number;
    if (unlockedRooms.has(key)) {
      continue;
    }

    unlockedRooms.set(key, true);

    for (const newKey of rooms[key]) {
      if (!unlockedRooms.has(newKey)) {
        keys.push(newKey);
      }
    }
  }

  return unlockedRooms.size === rooms.length;
}

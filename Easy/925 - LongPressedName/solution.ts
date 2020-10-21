/**
 * Question 925. Long Pressed Name (https://leetcode-cn.com/problems/long-pressed-name/)
 *
 * 执行用时：80 ms, 在所有 typescript 提交中击败了 77.78% 的用户
 * 内存消耗：40.2 MB, 在所有 typescript 提交中击败了 20.00% 的用户
 *
 * @param {string} name
 * @param {string} typed
 * @returns {boolean}
 */
function isLongPressedName(name: string, typed: string): boolean {
  let nameIndex: number = 0;
  let typedIndex: number = 0;

  const nameLength: number = name.length;
  const typedLength: number = typed.length;

  while (typedIndex < typedLength) {
    if (nameIndex < nameLength && name[nameIndex] === typed[typedIndex]) {
      nameIndex++;
      typedIndex++;
    } else if (typedIndex > 0 && typed[typedIndex] === typed[typedIndex - 1]) {
      typedIndex++;
    } else {
      return false;
    }
  }

  return nameIndex === nameLength;
}

// Question 844. Backspace String Compare (https://leetcode-cn.com/problems/backspace-string-compare/)

/**
 * 执行用时：96 ms, 在所有 typescript 提交中击败了 48.15% 的用户
 * 内存消耗：40.5 MB, 在所有 typescript 提交中击败了 15.79% 的用户
 *
 * @param {string} S
 * @param {string} T
 * @returns {boolean}
 */
function backspaceCompare(S: string, T: string): boolean {
  const compactS: string[] = getCompactString(S);
  const compactT: string[] = getCompactString(T);

  if (compactS.length !== compactT.length) {
    return false;
  }

  for (let i = 0; i < compactS.length; i++) {
    if (compactS[i] !== compactT[i]) {
      return false;
    }
  }

  return true;
}

function getCompactString(S: string): string[] {
  const stringLength: number = S.length;

  if (!stringLength) {
    return [];
  }

  let compactString: string[] = [];

  for (let i = 0; i < stringLength; i++) {
    const currentChar: string = S[i];
    if (currentChar === "#") {
      if (compactString.length) {
        compactString.pop();
      }
    } else {
      compactString.push(currentChar);
    }
  }

  return compactString;
}

/**
 * 执行用时：88 ms, 在所有 typescript 提交中击败了 74.07% 的用户
 * 内存消耗：40.2 MB, 在所有 typescript 提交中击败了 21.05% 的用户
 *
 * Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/backspace-string-compare/solution/bi-jiao-han-tui-ge-de-zi-fu-chuan-by-leetcode-solu/)
 *
 * @param {string} S
 * @param {string} T
 * @returns {boolean}
 */
function backspaceCompareUsingTwoPointers(S: string, T: string): boolean {
  const SKIP_CHAR: string = "#";

  let sIndex: number = S.length - 1;
  let sSkip: number = 0;

  let tIndex: number = T.length - 1;
  let tSkip: number = 0;

  while (sIndex >= 0 || tIndex >= 0) {
    while (sIndex >= 0) {
      if (S[sIndex] === SKIP_CHAR) {
        sSkip++;
        sIndex--;
      } else if (sSkip) {
        sSkip--;
        sIndex--;
      } else {
        break;
      }
    }

    while (tIndex >= 0) {
      if (T[tIndex] === SKIP_CHAR) {
        tSkip++;
        tIndex--;
      } else if (tSkip) {
        tSkip--;
        tIndex--;
      } else {
        break;
      }
    }

    if (sIndex >= 0 && tIndex >= 0) {
      if (S[sIndex] !== T[tIndex]) {
        return false;
      }
    } else {
      if (sIndex >= 0 || tIndex >= 0) {
        return false;
      }
    }

    sIndex--;
    tIndex--;
  }

  return true;
}

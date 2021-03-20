/// Question 150. Evaluate Reverse Polish Notation (https://leetcode-cn.com/problems/evaluate-reverse-polish-notation/)

/**
 * 执行用时：724 ms, 在所有 TypeScript 提交中击败了 5.88% 的用户
 * 内存消耗：49.4 MB, 在所有 TypeScript 提交中击败了 5.88% 的用户
 *
 * @param {string[]} tokens
 * @returns {number}
 */
function evalRPN(tokens: string[]): number {
  let numbers: number[] = [];
  const TOKENS_COUNT: number = tokens.length;

  for (let i = 0; i < TOKENS_COUNT; i++) {
    const token = tokens[i];

    if (i <= 1) {
      numbers.push(parseInt(token));
    } else {
      if (token === "+") {
        const tokenOne: number = numbers.pop();
        const tokenTwo: number = numbers.pop();
        numbers.push(tokenOne + tokenTwo);
      } else if (token === "-") {
        const tokenOne: number = numbers.pop();
        const tokenTwo: number = numbers.pop();
        numbers.push(tokenTwo - tokenOne);
      } else if (token === "*") {
        const tokenOne: number = numbers.pop();
        const tokenTwo: number = numbers.pop();
        numbers.push(tokenOne * tokenTwo);
      } else if (token === "/") {
        const tokenOne: number = numbers.pop();
        const tokenTwo: number = numbers.pop();
        const divisionResult = tokenTwo / tokenOne;
        numbers.push(
          divisionResult < 0
            ? Math.ceil(divisionResult)
            : Math.floor(divisionResult)
        );
      } else {
        numbers.push(parseInt(token));
      }
    }

    // console.log(numbers);
  }

  return numbers[0];
}

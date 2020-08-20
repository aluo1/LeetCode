/**
 * Question 529. Minesweeper (https://leetcode-cn.com/problems/minesweeper/)
 */

const UNREVEALED_MINE: string = "M";
const UNREVEALED_EMPTY: string = "E";

const REVEALED_MINE: string = "X";
const REVEALED_BLANK: string = "B";

const UNREVEALED_SQUARES: string[] = [UNREVEALED_MINE, UNREVEALED_EMPTY];
const MINE_SQUARES: string[] = [REVEALED_MINE, UNREVEALED_MINE];

/**
 * This is the DFS solution, which is almost identical to the C# solution.
 *
 * 执行用时：156 ms, 在所有 typescript 提交中击败了 100.00% 的用户
 * 内存消耗：44.8 MB, 在所有 typescript 提交中击败了 100.00% 的用户
 *
 * @param {string[][]} board
 * @param {number[]} click
 * @returns {string[][]}
 */
function updateBoard(board: string[][], click: number[]): string[][] {
  const [clickedX, clickedY] = click;

  if (board[clickedX][clickedY] === UNREVEALED_MINE) {
    board[clickedX][clickedY] = REVEALED_MINE;
    return board;
  }

  let stack: number[][] = [click];

  while (stack.length) {
    const [currentX, currentY] = stack.pop() as number[];
    let adjacentMinesCount: number = 0;
    let adjacentUnrevealedSquares: number[][] = [];

    for (let xDirection = -1; xDirection <= 1; xDirection++) {
      for (let yDirection = -1; yDirection <= 1; yDirection++) {
        if (xDirection === yDirection && xDirection === 0) {
          continue;
        }

        const newX = currentX + xDirection;
        const newY = currentY + yDirection;

        if (
          newX >= 0 &&
          newX < board.length &&
          newY >= 0 &&
          newY < board[0].length &&
          UNREVEALED_SQUARES.some((square) => square === board[newX][newY])
        ) {
          adjacentUnrevealedSquares.push([newX, newY]);
          if (MINE_SQUARES.some((mine) => mine === board[newX][newY])) {
            adjacentMinesCount++;
          }
        }
      }
    }

    if (adjacentMinesCount === 0) {
      stack = [...stack, ...adjacentUnrevealedSquares];
      board[currentX][currentY] = REVEALED_BLANK;
    } else {
      board[currentX][currentY] = `${adjacentMinesCount}`;
    }
  }

  return board;
}

/**
 * 执行用时：140 ms, 在所有 typescript 提交中击败了 100.00% 的用户
 * 内存消耗：44.6 MB, 在所有 typescript 提交中击败了 100.00% 的用户
 *
 * @param {string[][]} board
 * @param {number[]} click
 * @returns {string[][]}
 */
function updateBoardBFS(board: string[][], click: number[]): string[][] {
  const [clickedX, clickedY] = click;

  if (board[clickedX][clickedY] === UNREVEALED_MINE) {
    board[clickedX][clickedY] = REVEALED_MINE;
    return board;
  }

  let queue: number[][] = [click];

  while (queue.length) {
    const [currentX, currentY] = queue.shift() as number[];
    let adjacentMinesCount: number = 0;
    let adjacentUnrevealedSquares: number[][] = [];

    for (let xDirection = -1; xDirection <= 1; xDirection++) {
      for (let yDirection = -1; yDirection <= 1; yDirection++) {
        if (xDirection === yDirection && xDirection === 0) {
          continue;
        }

        const newX = currentX + xDirection;
        const newY = currentY + yDirection;

        if (
          newX >= 0 &&
          newX < board.length &&
          newY >= 0 &&
          newY < board[0].length &&
          UNREVEALED_SQUARES.some((square) => square === board[newX][newY]) &&
          !queue.some(
            ([recordedX, recordedY]) => recordedX === newX && recordedY === newY
          )
        ) {
          adjacentUnrevealedSquares.push([newX, newY]);
          if (MINE_SQUARES.some((mine) => mine === board[newX][newY])) {
            adjacentMinesCount++;
          }
        }
      }
    }

    if (adjacentMinesCount === 0) {
      queue = [...queue, ...adjacentUnrevealedSquares];
      board[currentX][currentY] = REVEALED_BLANK;
    } else {
      board[currentX][currentY] = `${adjacentMinesCount}`;
    }
  }

  return board;
}

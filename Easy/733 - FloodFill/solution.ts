const DIRECTIONS: number[][] = [
  [-1, 0],
  [1, 0],
  [0, -1],
  [0, 1],
];

/**
 * 执行用时：104 ms, 在所有 typescript 提交中击败了 36.84% 的用户
 * 内存消耗：39.8 MB, 在所有 typescript 提交中击败了 100.00% 的用户
 *
 * @param {number[][]} image
 * @param {number} sr
 * @param {number} sc
 * @param {number} newColor
 * @returns {number[][]}
 */
function floodFill(
  image: number[][],
  sr: number,
  sc: number,
  newColor: number
): number[][] {
  const imageRow: number = image.length;
  if (imageRow === 0) {
    return image;
  }

  const imageColumn: number = image[0].length;
  const sourcePixel: number = image[sr][sc];
  const floodedImage: number[][] = [];

  for (let i = 0; i < imageRow; i++) {
    let floodedColumn: number[] = [];
    for (let j = 0; j < imageColumn; j++) {
      floodedColumn[j] = image[i][j];
    }
    floodedImage[i] = floodedColumn;
  }

  const floodedPixels: number[][] = [[sr, sc]];
  while (floodedPixels.length) {
    const [pixelRow, pixelColumn] = floodedPixels.shift() as number[];

    for (const [rowDirection, columnDirection] of DIRECTIONS) {
      const newRow: number = pixelRow + rowDirection;
      const newColumn: number = pixelColumn + columnDirection;

      if (
        newRow >= 0 &&
        newRow < imageRow &&
        newColumn >= 0 &&
        newColumn < imageColumn &&
        image[newRow][newColumn] === sourcePixel &&
        floodedImage[newRow][newColumn] !== newColor
      ) {
        floodedPixels.push([newRow, newColumn]);
      }
    }

    floodedImage[pixelRow][pixelColumn] = newColor;
  }

  return floodedImage;
}

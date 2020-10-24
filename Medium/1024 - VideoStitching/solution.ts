// Question 1024. Video Stitching (https://leetcode-cn.com/problems/video-stitching/)

/**
 * This solution will failed in the case where max end time of the clip is greater than
 * the target value T, but the clips are not overlapped. e.g.
 *  [[0,2],[4,8]]
 *  5
 *
 * @param {number[][]} clips
 * @param {number} T
 * @returns {number}
 */
function videoStitchingFailed(clips: number[][], T: number): number {
  const clipsStarEndTimeMapping: Map<number, number[]> = new Map<
    number,
    number[]
  >();

  const startTimes: number[] = [];
  let maxEndTimes: number = 0;
  for (let [startTime, endTime] of clips) {
    if (clipsStarEndTimeMapping.has(startTime)) {
      const endTimeForTheStartTime: number[] = clipsStarEndTimeMapping.get(
        startTime
      ) as number[];
      clipsStarEndTimeMapping.set(startTime, [
        ...endTimeForTheStartTime,
        endTime,
      ]);
    } else {
      clipsStarEndTimeMapping.set(startTime, [endTime]);
      startTimes.push(startTime);
    }

    maxEndTimes = Math.max(maxEndTimes, endTime);
  }

  let startTime: number = 0;
  if (maxEndTimes < T || !clipsStarEndTimeMapping.has(startTime)) {
    return -1;
  }

  let clipsNumber: number = 1;
  let endTime: number = Math.max(
    ...(clipsStarEndTimeMapping.get(startTime) as number[])
  );

  while (
    endTime < T &&
    startTimes.filter((nextStartTime) => nextStartTime <= endTime)
  ) {
    let possibleStartTimes: number[] = startTimes.filter(
      (nextStartTime) => nextStartTime <= endTime
    ) as number[];

    // console.log(
    //   `endTime = ${endTime}, clipsNumber = ${clipsNumber}, startTimes = [${startTimes.join(
    //     ", "
    //   )}], possibleStartTimes = [${possibleStartTimes.join(", ")}]`
    // );

    endTime = Math.max(
      ...possibleStartTimes
        .map(
          (possibleStartTime) =>
            clipsStarEndTimeMapping.get(possibleStartTime) as number[]
        )
        .reduce((acc, current) => [...acc, ...current])
    );

    clipsNumber++;
  }

  return endTime >= T ? clipsNumber : -1;
}

/**
 * 执行用时：84 ms, 在所有 typescript 提交中击败了 100.00% 的用户
 * 内存消耗：39.7 MB, 在所有 typescript 提交中击败了 100.00% 的用户
 *
 * Acknowledgement: This solution borrows the lastEndTime idea from the 
 * [official solution](https://leetcode-cn.com/problems/video-stitching/solution/shi-pin-pin-jie-by-leetcode-solution/),
 * so the dilemma in teh function videoStitchingFailed can be resolved.
 *
 * @param {number[][]} clips
 * @param {number} T
 * @returns {number}
 */
function videoStitching(clips: number[][], T: number): number {
  const clipsStarEndTimeMapping: Map<number, number[]> = new Map<
    number,
    number[]
  >();

  const startTimes: number[] = [];
  let maxEndTimes: number = 0;
  for (let [startTime, endTime] of clips) {
    if (clipsStarEndTimeMapping.has(startTime)) {
      const endTimeForTheStartTime: number[] = clipsStarEndTimeMapping.get(
        startTime
      ) as number[];
      clipsStarEndTimeMapping.set(startTime, [
        ...endTimeForTheStartTime,
        endTime,
      ]);
    } else {
      clipsStarEndTimeMapping.set(startTime, [endTime]);
      startTimes.push(startTime);
    }

    maxEndTimes = Math.max(maxEndTimes, endTime);
  }

  let startTime: number = 0;
  if (maxEndTimes < T || !clipsStarEndTimeMapping.has(startTime)) {
    return -1;
  }

  let clipsNumber: number = 1;
  let endTime: number = Math.max(
    ...(clipsStarEndTimeMapping.get(startTime) as number[])
  );
  let lastEndTime: number = endTime;

  while (
    endTime < T &&
    startTimes.filter((nextStartTime) => nextStartTime <= endTime)
  ) {
    let possibleStartTimes: number[] = startTimes.filter(
      (nextStartTime) => nextStartTime <= endTime
    ) as number[];

    // console.log(
    //   `endTime = ${endTime}, clipsNumber = ${clipsNumber}, startTimes = [${startTimes.join(
    //     ", "
    //   )}], possibleStartTimes = [${possibleStartTimes.join(", ")}]`
    // );

    endTime = Math.max(
      ...possibleStartTimes
        .map(
          (possibleStartTime) =>
            clipsStarEndTimeMapping.get(possibleStartTime) as number[]
        )
        .reduce((acc, current) => [...acc, ...current])
    );

    if (lastEndTime === endTime) {
      return -1;
    }

    clipsNumber++;
  }

  return endTime >= T ? clipsNumber : -1;
}

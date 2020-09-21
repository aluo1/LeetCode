function topKFrequent(nums: number[], k: number): number[] {
  const numFreq: Map<number, number> = new Map<number, number>();
  for (const num of nums) {
    if (numFreq.has(num)) {
      numFreq.set(num, (numFreq.get(num) as number) + 1);
    } else {
      numFreq.set(num, 1);
    }
  }

  const frequencyNum: Map<number, number[]> = new Map<number, number[]>();
  const frequencies: number[] = [];

  for (const [num, freq] of numFreq) {
    if (frequencyNum.has(freq)) {
      frequencyNum.set(freq, [...(frequencyNum.get(freq) as number[]), num]);
    } else {
      frequencyNum.set(freq, [num]);
    }

    frequencies.push(freq);
  }

  frequencies.sort((a, b) => a - b);
}

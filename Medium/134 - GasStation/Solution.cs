// Question 134. Gas Station (https://leetcode-cn.com/problems/gas-station/)

/// <summary>
/// 执行用时：224 ms, 在所有 C# 提交中击败了 24.21% 的用户
/// 内存消耗：25.3 MB, 在所有 C# 提交中击败了 5.38% 的用户
/// </summary>
public class Solution
{
    private int GAS_STATION_COUNT;
    private int[] GAS;
    private int[] COST;

    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        Dictionary<int, List<int>> gainIndexMapping = new Dictionary<int, List<int>>();
        this.GAS = gas;
        this.COST = cost;
        this.GAS_STATION_COUNT = gas.Count();

        int maxGain = -1;

        for (int i = 0; i < this.GAS_STATION_COUNT; i++)
        {
            int gain = this.GetGasGainedAfterTheStep(i);
            maxGain = Math.Max(gain, maxGain);

            if (gainIndexMapping.ContainsKey(gain))
            {
                gainIndexMapping[gain].Add(i);
            }
            else
            {
                gainIndexMapping[gain] = new List<int>() { i };
            }
        }

        if (maxGain < 0) { return -1; }

        List<int> nonNegativeGainValues = gainIndexMapping.Keys.Where(gain => gain >= 0)
                                                                .OrderByDescending(a => a)
                                                                .ToList();
        List<(int, int)> possibleStartIndex = new List<(int, int)>();
        nonNegativeGainValues.ForEach(gainValue => possibleStartIndex.AddRange(gainIndexMapping[gainValue].Select(index => (index, gainValue))));

        foreach ((int startIndex, int gainValue) in possibleStartIndex)
        {
            // System.Console.WriteLine($"startIndex = {startIndex}");

            int gasRemaining = gainValue;

            int currentIndex = this.MoveToNextStation(startIndex);
            while (currentIndex != startIndex && gasRemaining >= 0)
            {
                gasRemaining += this.GetGasGainedAfterTheStep(currentIndex);
                currentIndex = this.MoveToNextStation(currentIndex);

                // System.Console.WriteLine($"startIndex = {startIndex}, gasRemaining = {gasRemaining},  currentIndex = {currentIndex}");
            }
            // System.Console.WriteLine($"gasRemaining = {gasRemaining}, currentIndex = {currentIndex}");

            if (currentIndex == startIndex && gasRemaining >= 0) { return startIndex; }
        }

        return -1;
    }

    private int GetGasGainedAfterTheStep(int currentStationIndex) => this.GAS[currentStationIndex] - this.COST[currentStationIndex];

    private int MoveToNextStation(int currentStationIndex) => currentStationIndex == this.GAS_STATION_COUNT - 1 ? 0 : currentStationIndex + 1;
}
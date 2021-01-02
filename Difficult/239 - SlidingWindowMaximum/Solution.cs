// Question 239. Sliding Window Maximum (https://leetcode-cn.com/problems/sliding-window-maximum/)

public class Solution 
{
    private List<(int, int)> currentWindow;
    private int K;

    public int[] MaxSlidingWindow(int[] nums, int k) 
    {
        if (k == 1) {  return nums; }
        
        this.K = k;
        int N = nums.Count();  
        int[] maxSlidingWindows = new int[N - k + 1];
        this.currentWindow = new List<(int, int)>();
        
        // Initialize the windows.
        int maxOfWindow = this.InitializeWindow(nums);
        maxSlidingWindows[0] = maxOfWindow;

        System.Console.WriteLine("21");
        for (int i = k - 1, windowIndex = 1; i <= N - 1; i++, windowIndex++)
        {
            maxSlidingWindows[windowIndex] = this.UpdateWindowAndGetMaxValue(i - k + 1, i, nums[i]);
        }

        return maxSlidingWindows;
    }

    private int InitializeWindow(int[] nums)
    {
        int maxOfWindow = nums[0];

        for (int i = 0; i < this.K; i++)
        {
            int currentValue = nums[i];
            
            int windowCount = this.currentWindow.Count();
            if (windowCount == 0)
            {
                this.currentWindow.Add((currentValue, i));
            } 
            else 
            {
                for (int existingValueIndex = 0; i < windowCount; i++)
                {
                    (int value, int index) = this.currentWindow[existingValueIndex];
                    if (value < currentValue)
                    {
                        this.currentWindow.Insert(i, (currentValue, i));
                    }
                }

                if (this.currentWindow.Count() == windowCount)
                {
                    this.currentWindow.Add((currentValue, i));
                }
            }

            // this.UpdateWindowAndGetMaxValue(-1, i, currentValue);
            maxOfWindow = Math.Max(maxOfWindow, currentValue);
        }

        return maxOfWindow;
    }

    private int UpdateWindowAndGetMaxValue(int indexToRemove, int indexToAdd, int valueToAdd)
    {
        this.currentWindow = this.currentWindow.Where(windowValue => windowValue.Item1 == indexToRemove).ToList();
        
        for (int i = 0; i < this.currentWindow.Count(); i++)
        {
            System.Console.WriteLine($"i = {i}, this.currentWindow.Count() = {this.currentWindow.Count()}");

            (int value, int index) = this.currentWindow[i];
            if (value < valueToAdd)
            {
                this.currentWindow.Insert(i, (valueToAdd, indexToAdd));
                break;
            }
        }

        (int maxValue, _) = this.currentWindow[0];
        return maxValue;
    }
}
/// Question 560. Subarray Sum Equals K (https://leetcode-cn.com/problems/subarray-sum-equals-k/)

public class SolutionFirstTryUsingSlidingWindow
{
    // This is a wrong answer.
    // I tried to solve this question using sliding windows, but I just realized this may miss some of the answers,
    // e.g, subarray (1,6), for a array with length 10.
    public int SubarraySum(int[] nums, int k)
    {
        Queue<int> subarray = new Queue<int>();
        int currentSum = 0;
        int numOfSubarray = 0;

        int rightPointer = -1;

        int arrayLength = nums.Count();

        for (int i = 0; i < arrayLength; i++)
        {
            if (i != 0) { subarray.Dequeue(); }

            currentSum = subarray.Sum();
            if (currentSum == k) { numOfSubarray++; }
            Console.WriteLine($"subarray = [{string.Join(", ", subarray)}], currentSum = {currentSum}, numOfSubarray = {numOfSubarray}, i = {i}\n");

            while (currentSum <= k && rightPointer + 1 < arrayLength)
            {
                subarray.Enqueue(nums[rightPointer + 1]);
                currentSum = subarray.Sum();

                if (currentSum == k) { numOfSubarray++; }
                rightPointer++;

                Console.WriteLine($"subarray = [{string.Join(", ", subarray)}], currentSum = {currentSum}, numOfSubarray = {numOfSubarray}, i = {i},  rightPointer = {rightPointer}");
            }
        }

        return numOfSubarray;
    }
}

public class SolutionBruteForce
{
    // This solution fail when the nums array is too big.
    public int SubarraySum(int[] nums, int k)
    {
        int numOfSubarray = 0;
        int arrayLength = nums.Count();
        List<int> subarray = new List<int>();

        for (int i = 0; i < arrayLength; i++)
        {
            subarray.Add(nums[i]);
            if (subarray.Sum() == k) { numOfSubarray++; }

            for (int j = i + 1; j < arrayLength; j++)
            {
                subarray.Add(nums[j]);
                if (subarray.Sum() == k) { numOfSubarray++; }
            }

            subarray = new List<int>();
        }

        return numOfSubarray;
    }
}

public class SolutionFirstAnswer
{
    // This is a modifieid version of `SolutionBruteForce`, it speeds up
    // as I remove the array operation, and record the sum only.
    //
    // 执行用时: 1332 ms, 在所有 C# 提交中击败了 12.12% 的用户
    // 内存消耗: 28.4 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public int SubarraySum(int[] nums, int k)
    {
        int numOfSubarray = 0;
        int arrayLength = nums.Count();

        for (int i = 0; i < arrayLength; i++)
        {
            int sum = 0;
            sum += nums[i];

            if (sum == k) { numOfSubarray++; }

            for (int j = i + 1; j < arrayLength; j++)
            {
                sum += nums[j];
                if (sum == k) { numOfSubarray++; }
            }
        }

        return numOfSubarray;
    }
}

public class SolutionOfficialOptimal
{
    // 执行用时: 152 ms, 在所有 C# 提交中击败了 57.58% 的用户
    // 内存消耗: 33.4 MB, 在所有 C# 提交中击败了 100.00% 的用户
    // Acknowledgement: This solution is a C# version of the [official solution](https://leetcode-cn.com/problems/subarray-sum-equals-k/solution/he-wei-kde-zi-shu-zu-by-leetcode-solution/)
    public int SubarraySum(int[] nums, int k)
    {
        int numOfSubarray = 0;
        int sum = 0;

        Dictionary<int, int> hashMap = new Dictionary<int, int>();
        hashMap[0] = 1;

        for (int i = 0; i < nums.Count(); i++)
        {
            sum += nums[i];

            int remaining = sum - k;
            if (hashMap.ContainsKey(remaining))
            {
                Console.WriteLine(remaining);
                numOfSubarray += hashMap[remaining];
            }

            if (hashMap.ContainsKey(sum))
            {
                hashMap[sum] += 1;
            }
            else
            {
                hashMap[sum] = 1;
            }
        }

        return numOfSubarray;
    }
}
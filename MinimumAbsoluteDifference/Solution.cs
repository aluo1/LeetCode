public class Solution {
    public IList<IList<int>> MinimumAbsDifference(int[] arr) {
        int minAbsDiff = arr.Max();
        Dictionary<string, List<List<int>>> absDiffMapping = new Dictionary<string, List<List<int>>>();

        int arraySize = arr.Length;
        for (int i = 0; i < arraySize; i++) {
            for (int j = 0; j < arraySize; j++) {
                if (i == j) { continue; }

                int iVal = arr[i];
                int jVal = arr[j];
                
                int absDiff = iVal - jVal;
                List<int> currentCombo = new List<int>{jVal, iVal};
                if (absDiff < 0) {
                    absDiff *= -1;
                    currentCombo = new List<int>{iVal, jVal};
                }

                if (minAbsDiff > absDiff) {
                    minAbsDiff = absDiff;
                }

                string absDiffString = absDiff.ToString();
                List<List<int>> currentValue = absDiffMapping.ContainsKey(absDiffString) ? absDiffMapping[absDiffString] : new List<List<int>>();

                if (!currentValue.Any(currentVal => currentVal[0] == currentCombo[0] && currentVal[1] == currentCombo[1])) {
                    currentValue.Add(currentCombo);
                }
                
                absDiffMapping[absDiffString] = currentValue;
            }
        }

        IList<IList<int>> iList = new List<IList<int>>();
        List<List<int>> minAbsDiffList = absDiffMapping[minAbsDiff.ToString()];

        minAbsDiffList.Sort((firstVal, secondVal) => {
            if (firstVal[0] == secondVal[0]) {
                return firstVal[1].CompareTo(secondVal[1]);
            } else {
                return firstVal[0].CompareTo(secondVal[0]);
            }
        });
        minAbsDiffList.ForEach(val => iList.Add(val));

        return iList;
    }
}
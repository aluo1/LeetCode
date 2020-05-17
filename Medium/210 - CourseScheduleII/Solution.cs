/// Question 210. Course Schedule II (https://leetcode-cn.com/problems/course-schedule-ii/)

public class Solution
{
    // 执行用时: 332 ms, 在所有 C# 提交中击败了 66.67% 的用户
    // 内存消耗: 35.3 MB, 在所有 C# 提交中击败了 100.00% 的用户
    // Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/course-schedule-ii/solution/ke-cheng-biao-ii-by-leetcode-solution/).
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        // Key is the prerequisite, value is (number of this course's prerequisite, the list of course depend on it).
        Dictionary<int, (int, HashSet<int>)> dependencyGraph = new Dictionary<int, (int, HashSet<int>)>();

        for (int i = 0; i < prerequisites.Count(); i++)
        {
            int[] prerequisite = prerequisites[i];
            int course = prerequisite[0];
            int prerequisiteCourse = prerequisite[1];

            if (dependencyGraph.ContainsKey(prerequisiteCourse))
            {
                dependencyGraph[prerequisiteCourse].Item2.Add(course);
            }
            else
            {
                dependencyGraph[prerequisiteCourse] = (0, new HashSet<int>() { course });
            }

            if (dependencyGraph.ContainsKey(course))
            {
                (int dependencyCount, HashSet<int> dependents) = dependencyGraph[course];
                dependencyGraph[course] = (dependencyCount + 1, dependents);
            }
            else
            {
                dependencyGraph[course] = (1, new HashSet<int>());
            }
        }

        for (int i = 0; i < numCourses; i++)
        {
            if (!dependencyGraph.ContainsKey(i))
            {
                dependencyGraph[i] = (0, new HashSet<int>());
            }
        }

        Queue<int> currentAvailableCourses = new Queue<int>(
            dependencyGraph.Where(dependencies => dependencies.Value.Item1 == 0)
                 .Select(dependencies => dependencies.Key)
        );
        HashSet<int> results = new HashSet<int>();

        while (currentAvailableCourses.Any())
        {
            int currentCourse = currentAvailableCourses.Dequeue();
            results.Add(currentCourse);

            foreach (int dependentCourse in dependencyGraph[currentCourse].Item2)
            {
                (int dependencyCount, HashSet<int> dependents) = dependencyGraph[dependentCourse];
                dependencyCount--;

                if (dependencyCount == 0)
                {
                    currentAvailableCourses.Enqueue(dependentCourse);
                }

                dependencyGraph[dependentCourse] = (dependencyCount, dependents);
            }

        }

        if (results.Count() != numCourses)
        {
            return new int[0];
        }

        return results.ToArray();
    }
}
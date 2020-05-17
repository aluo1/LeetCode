/**
 * Question 210. Course Schedule II (https://leetcode-cn.com/problems/course-schedule-ii/)
 * 执行用时: 100 ms, 在所有 JavaScript 提交中击败了 39.06% 的用户
 * 内存消耗: 42 MB, 在所有 JavaScript 提交中击败了 100.00% 的用户
 *
 * Acknowledgement: Same as the C#-version, this solution borrows idea from the [official solution](https://leetcode-cn.com/problems/course-schedule-ii/solution/ke-cheng-biao-ii-by-leetcode-solution/).
 *
 * @param {number} numCourses
 * @param {number[][]} prerequisites
 * @return {number[]}
 */
var findOrder = function (numCourses, prerequisites) {
  const dependencyGraph = new Map();
  for (let [course, prerequisite] of prerequisites) {
    if (dependencyGraph.has(course)) {
      const [dependencyCount, dependentCourses] = dependencyGraph.get(course);
      dependencyGraph.set(course, [dependencyCount + 1, dependentCourses]);
    } else {
      dependencyGraph.set(course, [1, []]);
    }

    if (dependencyGraph.has(prerequisite)) {
      const [dependencyCount, dependentCourses] = dependencyGraph.get(
        prerequisite
      );
      dependencyGraph.set(prerequisite, [
        dependencyCount,
        [...dependentCourses, course],
      ]);
    } else {
      dependencyGraph.set(prerequisite, [0, [course]]);
    }
  }

  for (let i = 0; i < numCourses; i++) {
    if (!dependencyGraph.has(i)) {
      dependencyGraph.set(i, [0, []]);
    }
  }

  const results = [];
  const queue = [];

  for (const [course, [dependencyCount, _]] of dependencyGraph) {
    if (dependencyCount === 0) {
      queue.push(course);
    }
  }

  while (queue.length) {
    const currentCourse = queue.shift();
    results.push(currentCourse);

    dependencyGraph.get(currentCourse)[1].forEach((dependentCourse) => {
      let [dependencyCount, dependentCourses] = dependencyGraph.get(
        dependentCourse
      );

      dependencyCount--;
      if (dependencyCount === 0) {
        queue.push(dependentCourse);
      }

      dependencyGraph.set(dependentCourse, [dependencyCount, dependentCourses]);
    });
  }

  if (results.length === numCourses) {
    return results;
  } else {
    return [];
  }
};

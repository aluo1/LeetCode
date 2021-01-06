// Question 399. Evaluate Division (https://leetcode-cn.com/problems/evaluate-division/)

/**
 * 执行用时：76 ms, 在所有 JavaScript 提交中击败了 83.87% 的用户
 * 内存消耗：37.8 MB, 在所有 JavaScript 提交中击败了 36.21% 的用户
 *
 * 作者：LeetCode-Solution
 * 链接：https://leetcode-cn.com/problems/evaluate-division/solution/chu-fa-qiu-zhi-by-leetcode-solution-8nxb/
 * 来源：力扣（LeetCode）
 * 著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。
 *
 * @param {*} equations
 * @param {*} values
 * @param {*} queries
 */
var calcEquation = function (equations, values, queries) {
  let nvars = 0;
  const variables = new Map();

  const n = equations.length;
  for (let i = 0; i < n; i++) {
    if (!variables.has(equations[i][0])) {
      variables.set(equations[i][0], nvars++);
    }
    if (!variables.has(equations[i][1])) {
      variables.set(equations[i][1], nvars++);
    }
  }

  // 对于每个点，存储其直接连接到的所有点及对应的权值
  const edges = new Array(nvars).fill(0);
  for (let i = 0; i < nvars; i++) {
    edges[i] = [];
  }
  for (let i = 0; i < n; i++) {
    const va = variables.get(equations[i][0]),
      vb = variables.get(equations[i][1]);
    edges[va].push([vb, values[i]]);
    edges[vb].push([va, 1.0 / values[i]]);
  }

  const queriesCount = queries.length;
  const ret = [];
  for (let i = 0; i < queriesCount; i++) {
    const query = queries[i];
    let result = -1.0;
    if (variables.has(query[0]) && variables.has(query[1])) {
      const ia = variables.get(query[0]),
        ib = variables.get(query[1]);
      if (ia === ib) {
        result = 1.0;
      } else {
        const points = [];
        points.push(ia);
        const ratios = new Array(nvars).fill(-1.0);
        ratios[ia] = 1.0;

        while (points.length && ratios[ib] < 0) {
          const x = points.pop();
          for (const [y, val] of edges[x]) {
            if (ratios[y] < 0) {
              ratios[y] = ratios[x] * val;
              points.push(y);
            }
          }
        }
        result = ratios[ib];
      }
    }
    ret[i] = result;
  }
  return ret;
};

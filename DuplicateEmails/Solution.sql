/*
182. Duplicate Emails
Difficulty: Easy
执行用时: 1489 ms , 在所有 MS SQL Server 提交中击败了 76.61% 的用户
内存消耗: N/A
*/
SELECT Email FROM 
(
    SELECT Email, COUNT(*) AS EmailFreq FROM Person
    GROUP BY Email
) groupedEmail
WHERE groupedEmail.EmailFreq > 1


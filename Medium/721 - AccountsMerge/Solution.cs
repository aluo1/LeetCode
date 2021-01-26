// Question 721. Accounts Merge (https://leetcode-cn.com/problems/accounts-merge/)

public class Solution 
{
    private readonly int INDEX_WHEN_NOT_FOUND = -1;

    private List<HashSet<string>> emails;
    private List<string> names;

    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) 
    {
        this.InitLists();
        
        // Merge accounts
        foreach (IList<string> account in accounts)
        {
            string name = account.First();
            List<string> emails = account.Skip(1).ToList();
            int accountIndex = this.GetIndexOfAccount(emails);
            if (accountIndex != this.INDEX_WHEN_NOT_FOUND)
            {
                this.emails[accountIndex].UnionWith(emails);
            }
            else
            {
                this.emails.Add(new HashSet<string>(emails));
                this.names.Add(name);
            }
        }

        // Sort emails in account
        int N = this.emails.Count();
        IList<IList<string>> mergedAccounts = new List<IList<string>>();
        for (int i = 0; i < N; i++)
        {
            List<string> emailList = this.emails[i].ToList();
            emailList.Sort(string.CompareOrdinal);

            List<string> mergedAccount = new List<string>() { this.names[i] };
            mergedAccount.AddRange(emailList);
            mergedAccounts.Add(mergedAccount);
        }

        return mergedAccounts;
    }

    private void InitLists() 
    {
        this.emails = new List<HashSet<string>>();
        this.names = new List<string>();
    }

    private int GetIndexOfAccount(List<string> accountEmails)
    {
        int N = this.emails.Count();
        for (int i = 0; i < N; i++)
        {
            HashSet<string> emailList = this.emails[i];
            if (accountEmails.Any(email => emailList.Contains(email))) { return i; }   
        }

        return this.INDEX_WHEN_NOT_FOUND;
    }
}
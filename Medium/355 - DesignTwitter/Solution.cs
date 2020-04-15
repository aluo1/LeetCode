/// Question 355. Design Twitter (https://leetcode-cn.com/problems/design-twitter/)
/// 执行用时: 432 ms , 在所有 C# 提交中击败了 28.57% 的用户
/// 内存消耗: 42 MB, 在所有 C# 提交中击败了 100.00% 的用户

public class Twitter
{
    private Dictionary<int, List<int>> followship;
    private List<(int, int)> feeds;

    /** Initialize your data structure here. */
    public Twitter()
    {
        this.followship = new Dictionary<int, List<int>>();
        this.feeds = new List<(int, int)>();
    }

    /** Compose a new tweet. */
    public void PostTweet(int userId, int tweetId)
    {
        this.feeds.Add((userId, tweetId));
    }

    /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
    public IList<int> GetNewsFeed(int userId)
    {
        List<int> mostRecentTweets = new List<int>();
        List<int> userIdList = new List<int>() { userId };

        if (this.followship.ContainsKey(userId))
        {
            userIdList = userIdList.Concat(this.followship[userId]).ToList();
        }

        for (int i = this.feeds.Count() - 1; i >= 0; i--)
        {
            if (mostRecentTweets.Count() >= 10)
            {
                break;
            }

            (int posterId, int tweetId) = this.feeds.ElementAt(i);
            if (userIdList.IndexOf(posterId) != -1)
            {
                mostRecentTweets.Add(tweetId);
            }
        }

        return mostRecentTweets;
    }

    /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
    public void Follow(int followerId, int followeeId)
    {
        if (!this.followship.ContainsKey(followerId))
        {
            this.followship[followerId] = new List<int>() { followeeId };
        }
        else if ((this.followship.ContainsKey(followerId) && this.followship[followerId].IndexOf(followeeId) == -1))
        {
            this.followship[followerId].Add(followeeId);
        }
    }

    /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
    public void Unfollow(int followerId, int followeeId)
    {
        if (this.followship.ContainsKey(followerId) && this.followship[followerId].IndexOf(followeeId) != -1)
        {
            this.followship[followerId].Remove(followeeId);
        }
    }
}

/**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.PostTweet(userId,tweetId);
 * IList<int> param_2 = obj.GetNewsFeed(userId);
 * obj.Follow(followerId,followeeId);
 * obj.Unfollow(followerId,followeeId);
 */

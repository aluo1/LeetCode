// Question 1603. Design Parking System (https://leetcode-cn.com/problems/design-parking-system/)

/// <summary>
/// 执行用时：212 ms, 在所有 C# 提交中击败了 92.96% 的用户
/// 内存消耗：42.2 MB, 在所有 C# 提交中击败了 81.69% 的用户
/// </summary>
public class ParkingSystem 
{
    private const int BIG_INDEX = 1;
    private const int MEDIUM_INDEX = 2;
    private const int SMALL_INDEX = 3;

    private int[] _parkingSpaces = new int[4];

    public ParkingSystem(int big, int medium, int small) 
    {
        this._parkingSpaces[BIG_INDEX] = big;
        this._parkingSpaces[MEDIUM_INDEX] = medium;
        this._parkingSpaces[SMALL_INDEX] = small;
    }
    
    public bool AddCar(int carType) 
    {
        var remainingSpaces = this._parkingSpaces[carType];
        if (remainingSpaces > 0) 
        {
            this._parkingSpaces[carType] -= 1;
            return true;
        }

        return false;
    }
}

/**
 * Your ParkingSystem object will be instantiated and called as such:
 * ParkingSystem obj = new ParkingSystem(big, medium, small);
 * bool param_1 = obj.AddCar(carType);
 */
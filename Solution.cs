using System;

public class Solution
{
    public static bool IsFirstComeFirstServed(int[] takeOutOrders, int[] dineInOrders, int[] servedOrders)
    {
        // Check if we're serving orders first-come, first-served
        int take = 0, 
            dine = 0, 
            served = 0, 
            matched= 0;

        //checks if two arrays are bigger than resulting array
        if ( servedOrders.Length < takeOutOrders.Length + dineInOrders.Length){
            return false;
        }
        
        for (int i = 0; i < servedOrders.Length; i++ ) {
            //check if empty arrays
            if (take >= takeOutOrders.Length) {
                if (dine >= dineInOrders.Length) {
                    return (matched == servedOrders.Length);
                }
                    dine ++;
                    served++;
                    matched++;
            }
            
            //match in take out
            else if (servedOrders[i] == takeOutOrders[take]){
                    take ++;
                    served++;
                    matched++;
            }
            
            //matched in dine in
            else if (servedOrders[i] == dineInOrders[dine]) {
                    dine ++;
                    served++;
                    matched++;
            }
            else {
                return false;
            }
        }
        if ( matched == servedOrders.Length) {
            return true;
        }

        return false;
    }





    // Tests

    [Fact]
    public void BothRegistersHaveSameNumberOfOrdersTest()
    {
        var takeOutOrders = new int[] { 1, 4, 5 };
        var dineInOrders = new int[] { 2, 3, 6 };
        var servedOrders = new int[] { 1, 2, 3, 4, 5, 6 };
        var result = IsFirstComeFirstServed(takeOutOrders, dineInOrders, servedOrders);
        Assert.True(result);
    }

    [Fact]
    public void RegistersHaveDifferentLengthsTest()
    {
        var takeOutOrders = new int[] { 1, 5 };
        var dineInOrders = new int[] { 2, 3, 6 };
        var servedOrders = new int[] { 1, 2, 6, 3, 5 };
        var result = IsFirstComeFirstServed(takeOutOrders, dineInOrders, servedOrders);
        Assert.False(result);
    }

    [Fact]
    public void OneRegisterIsEmptyTest()
    {
        var takeOutOrders = new int[] { };
        var dineInOrders = new int[] { 2, 3, 6 };
        var servedOrders = new int[] { 2, 3, 6 };
        var result = IsFirstComeFirstServed(takeOutOrders, dineInOrders, servedOrders);
        Assert.True(result);
    }

    [Fact]
    public void ServedOrdersIsMissingOrdersTest()
    {
        var takeOutOrders = new int[] { 1, 5 };
        var dineInOrders = new int[] { 2, 3, 6 };
        var servedOrders = new int[] { 1, 6, 3, 5 };
        var result = IsFirstComeFirstServed(takeOutOrders, dineInOrders, servedOrders);
        Assert.False(result);
    }

    [Fact]
    public void ServedOrdersHasExtraOrders()
    {
        var takeOutOrders = new int[] { 1, 5 };
        var dineInOrders = new int[] { 2, 3, 6 };
        var servedOrders = new int[] { 1, 2, 3, 5, 6, 8 };
        var result = IsFirstComeFirstServed(takeOutOrders, dineInOrders, servedOrders);
        Assert.False(result);
    }

    [Fact]
    public void OneRegisterHasExtraOrders()
    {
        var takeOutOrders = new int[] { 1, 9 };
        var dineInOrders = new int[] { 7, 8 };
        var servedOrders = new int[] { 1, 7, 8 };
        var result = IsFirstComeFirstServed(takeOutOrders, dineInOrders, servedOrders);
        Assert.False(result);
    }

    [Fact]
    public void OneRegisterHasUnservedOrders()
    {
        var takeOutOrders = new int[] { 55, 9 };
        var dineInOrders = new int[] { 7, 8 };
        var servedOrders = new int[] { 1, 7, 8, 9 };
        var result = IsFirstComeFirstServed(takeOutOrders, dineInOrders, servedOrders);
        Assert.False(result);
    }

    [Fact]
    public void OrderNumbersAreNotSequential()
    {
        var takeOutOrders = new int[] { 27, 12, 18 };
        var dineInOrders = new int[] { 55, 31, 8 };
        var servedOrders = new int[] { 55, 31, 8, 27, 12, 18 };
        var result = IsFirstComeFirstServed(takeOutOrders, dineInOrders, servedOrders);
        Assert.True(result);
    }

    public static void Main(string[] args)
    {
        TestRunner.RunTests(typeof(Solution));
    }
}

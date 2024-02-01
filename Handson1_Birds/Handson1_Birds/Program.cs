using System.Buffers.Text;
using System.Collections.Generic;

public class Program
{
    private static void Main(string[] args)
    {
        // 1)
        BirdCount.LastWeek();

        #region // Print output
        int[] lastWeekCounts = BirdCount.LastWeek();        // multiple no return -> array type
        Console.WriteLine("Bird counts for the last week: [ " + string.Join(" , ", lastWeekCounts) + " ]");
        #endregion

        // 2)
        //int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };       
        //var birdCount = new BirdCount(birdsPerDay);
        //birdCount.Today();

        #region // Print output
        //int todayscount = birdCount.Today();        // only 1 no return -> int type
        //Console.WriteLine($"Number of birds visited today: {todayscount}");
        #endregion

        // 3)
        //int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
        //var birdCount = new BirdCount(birdsPerDay);
        //birdCount.IncrementTodaysCount();   // Output: 1
        //birdCount.Today();                  // Output: 1 + 1 = 2

        #region // Print output
        //int todayscount = birdCount.Today();        // only one int so returns number -> int type
        //Console.WriteLine($"Number of birds visited today after increment: {todayscount}");
        #endregion

        // 4)
        //int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
        //var birdCount = new BirdCount(birdsPerDay);
        //birdCount.HasDayWithoutBirds();

        #region // Print output
        //bool count = birdCount.HasDayWithoutBirds();        
        //Console.WriteLine($"Was there was a day at which zero birds visited the garden?: {count}");
        #endregion

        // 5)
        //int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
        //var birdCount = new BirdCount(birdsPerDay);
        //birdCount.CountForFirstDays(4);

        #region // Print output
        //int countdays = birdCount.CountForFirstDays(4);        
        //Console.WriteLine($"Number of visiting birds for the first number of days: {countdays}");
        #endregion

        // 6)
        //int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
        //var birdCount = new BirdCount(birdsPerDay);
        //birdCount.BusyDays();

        #region // Print output
        //int busydays = birdCount.BusyDays();
        //Console.WriteLine($"Number of busy days: {busydays}");
        #endregion

    }
}
public class BirdCount
{
    private int[] birdsPerDay;      // property

    public BirdCount(int[] birdsPerDay)     // constructor
    {
        this.birdsPerDay = birdsPerDay;
    }

    #region 1) Check what the counts were last week:
    public static int[] LastWeek()
    {
        int[] arr = [0, 2, 5, 3, 7, 8, 4];
        return arr;
    }
    #endregion

    #region 2) Check how many birds visited today:
    public int Today()
    {
        //return birdsPerDay[5];
        //return birdsPerDay[^1]; // Using the index of -1 to get the last element
        return birdsPerDay[birdsPerDay.Length-1]; // birdsPerDay.Length gives you the total number of elements in the array. Subtracting 1 from the length represents the index of the last element because array indices are zero - based in C#. So, if an array has n elements, the valid indices are from 0 to n-1.
    }

    #endregion

    #region 3) Increment today's count:
    public int IncrementTodaysCount()
    {
        //return birdsPerDay[5]++;
        //return birdsPerDay[^1]++;
        return birdsPerDay[birdsPerDay.Length-1]++;

    }

    #endregion

    #region 4) Check if there was a day with no visiting birds:

    public bool HasDayWithoutBirds()
    {
        foreach (int count in birdsPerDay)
        {
            if (count == 0)
            {
                return true;        // once returned, it will exit the code.
            }
        }
        return false;
    }

    #endregion

    #region 5) Calculate the number of visiting birds for the first number of days:

    public int CountForFirstDays(int days) 
    {
        int count = 0;
        for (int i = 0; i < days; i++ )     // days - 1 -> bcs its an array, not string. If string, use length
        {
            count = count + birdsPerDay[i];         // adding to the same variable
        }
        return count;
    }

    #endregion

    #region 6) Calculate the number of busy days

    public int BusyDays()
    {
        int bd = 0;
        foreach (int bird in birdsPerDay)
        {
            if (bird >= 5)
            {
                bd++;           // count repeated no of ocurrances; // Increment count by 1
            }
        }
        return bd;
    }

    #endregion
}
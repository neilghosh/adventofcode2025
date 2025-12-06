using System;
using System.IO;

class Day02_Part2
{
    static void Main(string[] args)
    {
        string[]? lines = InputReader.ReadLines(args, "Day02_input.txt");
        if (lines == null) return;
        String[] ranges = lines[0].Split(',');
        //Each range is in the format "start-end"
        //large number data type to store the result
        long result = 0;
        foreach (String range in ranges)
        {
            String[] bounds = range.Split('-');
            long start = Int64.Parse(bounds[0]);
            long end = Int64.Parse(bounds[1]);
            // Process the range from start to end by increamenting 1
            for (long  i = start; i <= end; i++)
            {
                //This can have repeating group of any size. Minimum 1. So we need to check for all possible group sizes.
                // Max group size would be half the length of the number
                int minGroupSize = 1;
                int maxGroupSize = i.ToString().Length / 2;
                bool invalidCurrentNumber = false;
                // Check for all group sizes from min to max
                for (int groupSize = minGroupSize; groupSize <= maxGroupSize && !invalidCurrentNumber; groupSize++)
                {
                    // Check if its a valid group size given the length of the number
                    if (i.ToString().Length % groupSize == 0)
                    {
                        // Get the first group
                        String numStr = i.ToString();
                        String firstGroup = i.ToString().Substring(0, groupSize);
                        bool allGroupsEqual = true;
                        // Check all subsequent groups
                        for (int pos = groupSize; pos < numStr.Length; pos += groupSize)
                        {
                            String currentGroup = numStr.Substring(pos, groupSize);
                            if (currentGroup != firstGroup)
                            {
                                allGroupsEqual = false;
                                break;
                            }
                        }
                        // If all groups are equal, add to result and mark as found
                        if (allGroupsEqual)
                        {
                            result += i;
                            invalidCurrentNumber = true;
                        }
                    }
                }
            }
        }
        Console.WriteLine($"Result: "+ result);
    }
}

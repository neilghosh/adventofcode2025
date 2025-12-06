using System;
using System.IO;

class Day02_
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
                // split the number into two numbers by splitting digits equally 
                // For example, 1234 becomes 12 and 34
                String numStr = i.ToString();
                int len = numStr.Length;
                int mid = len / 2;
                string firstHalf = numStr.Substring(0, mid);
                string secondHalf = numStr.Substring(mid, len - mid);
                // If the first and second half are equal then add the original number into result
                if (firstHalf == secondHalf)
                {
                    result += i;
                }
            }
        }
        Console.WriteLine($"Result: "+ result);
    }
}

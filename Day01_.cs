using System;
using System.IO;

class Day01_
{
    static void Main(string[] args)
    {
        string[]? directions = InputReader.ReadLines(args, "Day01_input.txt");
        if (directions == null) return;

        //Intialize starting position as 50
        int position = 50;
        int result = 0;
        foreach (var dir in directions)
        {
            //Get the 1st Character to be left or right based on the letter 
            char turn = dir[0];
            //Get the number of steps to move forward
            int steps = int.Parse(dir.Substring(1));
            int effectiveSteps = steps % 100;
            //Update position based on turn direction
            if (turn == 'L')
            {
                position -= effectiveSteps;
                if (position < 0)
                {
                    position = 100 + position;
                }
            }
            else if (turn == 'R')
            {
                //if it smore than 99 it wraps around to 0
                position += effectiveSteps;
                if (position > 99)
                {
                    position = position - 100;
                }
            }
            else
            {
                Console.WriteLine($"Invalid direction: {dir}");
            }
            // if the position is 0 then increase a global counter 
            if (position == 0)
            {
                // Increment counter or perform action when position reaches 0
                result++;
            }
        }
        //Print number of times position reached 0
        Console.WriteLine($"Position reached 0 a total of {result} times.");
    }
}

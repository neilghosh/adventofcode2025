using System;
using System.IO;

class Day01_Part2
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
            int completeRounds = steps / 100;
            int effectiveSteps = steps % 100;
            //For every complete round it would cross 0 
            
            if (completeRounds > 0)
            {
                result += completeRounds;
                //unless it is at 0 already and ends there after steps
                //In this case it will be anyway counted once later
                if( position == 0 && effectiveSteps == 0)
                {
                    result--;
                }
            }
            int oldPosition = position;
            //Update position based on turn direction
            if (turn == 'L')
            {
                position -= effectiveSteps;
                if (position < 0)
                {
                    //Since it crosses 0 we need to account for that unless it was in 0 already before move
                    if (oldPosition != 0)
                    {
                        result++;
                    }
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
                   //Since it crosses 0 we need to account for that unless new position is exactly 0
                    if (position != 0)
                    {
                        result++;
                    }
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

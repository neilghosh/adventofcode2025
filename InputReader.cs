using System;
using System.IO;

public static class InputReader
{
    /// <summary>
    /// Reads a file and returns its contents as an array of lines.
    /// </summary>
    /// <param name="args">Command line arguments (first arg is file path)</param>
    /// <param name="defaultFileName">Default file name if no args provided</param>
    /// <returns>Array of non-empty lines from the file, or null if error</returns>
    public static string[]? ReadLines(string[] args, string defaultFileName)
    {
        string filePath = args.Length > 0 ? args[0] : defaultFileName;
        
        try
        {
            string[] lines = File.ReadAllText(filePath)
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            
            Console.WriteLine($"Loaded {lines.Length} lines from {filePath}");
            return lines;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File '{filePath}' not found.");
            return null;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
            return null;
        }
    }
}

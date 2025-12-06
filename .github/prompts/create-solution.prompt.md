---
agent: agent
description: Generate Advent of Code solution files for a specific day
---

# Advent of Code Solution Generator

Create new Advent of Code solution files following the project's established patterns.

## User Input Required

The user will provide:
1. **Day number** (e.g., "Day 2", "Day 15")
2. **Part indicator** (Part 1 is default, or explicitly "Part 2")
3. **Puzzle input content** (the actual input data to save)
4. **Test input content** (optional, smaller test dataset)

## File Generation Rules

### For Part 1 (default)

Create **three files**:

1. **`Day{XX}_.cs`** - Main solution file with this template:
```csharp
using System;
using System.IO;

class Day{XX}_
{
    static void Main(string[] args)
    {
        string[]? lines = InputReader.ReadLines(args, "Day{XX}_input.txt");
        if (lines == null) return;

        // TODO: Implement solution logic here
        
        Console.WriteLine($"Result: ");
    }
}
```

2. **`Day{XX}_input.txt`** - Contains the puzzle input provided by the user

3. **`Day{XX}_input_test.txt`** - Contains the test input provided by the user (or empty if not provided)

### For Part 2

Create **one file** (reuses existing input files):

1. **`Day{XX}_Part2.cs`** - Part 2 solution file:
   - **If `Day{XX}_.cs` exists:** Copy the Part 1 file content and rename the class from `Day{XX}_` to `Day{XX}_Part2`
   - **If Part 1 doesn't exist:** Use this template:
```csharp
using System;
using System.IO;

class Day{XX}_Part2
{
    static void Main(string[] args)
    {
        string[]? lines = InputReader.ReadLines(args, "Day{XX}_input.txt");
        if (lines == null) return;

        // TODO: Implement Part 2 solution logic here
        
        Console.WriteLine($"Result: ");
    }
}
```

## Naming Conventions

| Element | Format | Example |
|---------|--------|---------|
| Day number | Two digits, zero-padded | `02`, `15` |
| Part 1 class | `Day{XX}_` | `Day02_` |
| Part 2 class | `Day{XX}_Part2` | `Day02_Part2` |
| Part 1 file | `Day{XX}_.cs` | `Day02_.cs` |
| Part 2 file | `Day{XX}_Part2.cs` | `Day02_Part2.cs` |
| Input file | `Day{XX}_input.txt` | `Day02_input.txt` |
| Test input | `Day{XX}_input_test.txt` | `Day02_input_test.txt` |

## Important Notes

- All files are created in the project root: `/workspaces/adventofcode2025/`
- Both Part 1 and Part 2 have their own `Main` function (standalone entry points)
- Part 2 reuses the same input file as Part 1 (`Day{XX}_input.txt`)
- Use `InputReader.ReadLines(args, "Day{XX}_input.txt")` to load input at program start
- The `InputReader` class is already available in the project

## Example Usage

**User prompt:** "Create Day 5 solution with this input: [paste input]"

**Result:** Creates `Day05_.cs`, `Day05_input.txt`, `Day05_input_test.txt`

**User prompt:** "Create Day 5 Part 2"

**Result:** Creates `Day05_Part2.cs` (uses existing input file)
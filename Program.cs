using System;
using System.IO;
using System.Linq;

var numbers = (await File.ReadAllLinesAsync("data.txt")).Select(n => Convert.ToInt64(n)).ToArray();
var range = 25;
Console.WriteLine($"The problem is with {FindEncodingErrorNumber()}");

long FindEncodingErrorNumber()
{
    for (var targetIndex = range; targetIndex < numbers.Length; targetIndex++)
    {
        var target = numbers[targetIndex];
        var foundTarget = false;
        for (var firstNumberIndex = targetIndex - range; firstNumberIndex < targetIndex - 1; firstNumberIndex++)
        {
            for (var secondNumberIndex = targetIndex - range + 1; secondNumberIndex < targetIndex; secondNumberIndex++)
            {
                if (numbers[firstNumberIndex] + numbers[secondNumberIndex] == target)
                {
                    foundTarget = true;
                    break;
                }
            }

            if (foundTarget) break;
        }
        
        if (!foundTarget) return target;
    }

    throw new Exception("It is perfect ?!?!?!");
}
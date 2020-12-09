using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var numbers = (await File.ReadAllLinesAsync("data.txt")).Select(n => Convert.ToInt64(n)).ToArray();
// Console.WriteLine($"The problem is with {FindEncodingErrorNumber()}");
Console.WriteLine($"Break the encryption with {FindEncryptionWeakness()}");

long FindEncryptionWeakness()
{
    var target = 36845998; // determined from calling FindEncodingErrorNumber
    for (var startIndex = 0; startIndex < numbers.Length - 1; startIndex++)
    {
        var set = new List<long>();
        for (var testIndex = startIndex; testIndex < numbers.Length; testIndex++)
        {
            set.Add(numbers[testIndex]);
            if (set.Sum() == target)
            {
                var smallest = set.Min();
                var largest = set.Max();
                return smallest + largest;
            }
        }
    }

    throw new Exception("Unbreakable!");
}

long FindEncodingErrorNumber()
{
    var range = 25;

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
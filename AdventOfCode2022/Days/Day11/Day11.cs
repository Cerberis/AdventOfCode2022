

namespace AdventOfCode2022.Days
{
    internal abstract class Day11
    {

        internal Day11(string filePath)
        {
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }

        protected abstract int Calculate();

  
    }
}
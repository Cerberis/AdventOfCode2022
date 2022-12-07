namespace AdventOfCode2022.Days
{
    internal abstract class Day8
    {

        internal Day8(string filePath)
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
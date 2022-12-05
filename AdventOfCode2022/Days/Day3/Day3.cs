namespace AdventOfCode2022.Days
{
    internal abstract class Day3
    {
        internal List<string> ParsedData { get; }

        internal Day3(string filePath)
        {
            ParsedData = FileReaders.ReadDataFileAsStringList(filePath);
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }

        internal abstract int Calculate();
    }
}

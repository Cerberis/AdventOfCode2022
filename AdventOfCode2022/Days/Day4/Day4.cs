namespace AdventOfCode2022.Days
{
    internal abstract class Day4
    {
        internal List<string> ParsedData { get; }

        internal Day4(string filePath)
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






using CommonCode;

namespace AdventOfCode2022.Days
{
    internal abstract class Day9
    {
        internal List<List<int>> ParsedData { get; set; }

        internal Day9(string filePath)
        {
            ParseData(filePath);
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }

        protected abstract int Calculate();

        void ParseData(string filePath)
        {
            ParsedData = FileReaders.ReadDataFileAsIntMatrix(filePath);
        }
    }
}
using CommonCode;

namespace AdventOfCode2022.Days
{
    internal abstract class Day22
    {
        internal List<List<int>> ParsedData { get; set; }

        internal Day22(string filePath)
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
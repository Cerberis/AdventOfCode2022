namespace AdventOfCode2022.Days
{
    internal abstract class Day6
    {
        internal string ParsedData { get; set; }

        internal Day6(string filePath)
        {
            ParsedData = File.ReadAllLines(filePath).First();
        }



        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }


        internal abstract long Calculate();

    }
}
namespace AdventOfCode2022.Days
{
    internal abstract class Day5
    {

        internal List<List<char>> BoxStacks { get; }
        internal List<StackMove> Moves { get; }
        internal List<string> ParsedData { get; }
        internal Day5(string filePath)
        {
            ParsedData = FileReaders.ReadDataFileAsStringList(filePath);
            int boxStacksEndline = GetBoxStacksEndline();
            BoxStacks = GetBoxStacks(boxStacksEndline);
            Moves = GetMoves(boxStacksEndline);
        }

        private List<StackMove> GetMoves(int boxStacksEndline)
        {
            var moves = new List<StackMove>();
            foreach (var row in ParsedData.Skip(boxStacksEndline + 2))
            {
                var foundNumbers = row.Split(" ").Where(m => int.TryParse(m, out int _)).ToList();
                moves.Add(new StackMove(foundNumbers[1].ToInt(), foundNumbers[2].ToInt(), foundNumbers[0].ToInt()));
            }

            return moves;
        }

        private int GetBoxStacksEndline()
        {
            for (var i = 0; i < ParsedData.Count; i++)
            {
                if (!ParsedData[i].Contains("[") && !ParsedData[i].Contains("move"))
                {
                    return i;
                }
            }

            throw new Exception("Bad data file");
        }

        private List<List<char>> GetBoxStacks(int boxStacksEndline)
        {
            var result = new List<List<char>>();
            int maxColumnNumber = GetMaxColumnNumber(boxStacksEndline);
            for (int i = 0; i < maxColumnNumber; i++)
            {
                result.Add(new List<char>());
            }

            for (int rowIndex = 0; rowIndex < boxStacksEndline; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < maxColumnNumber; columnIndex++)
                {
                    var columnData = ParsedData[rowIndex].Skip(columnIndex * 4).Take(3);
                    var foundLetter = columnData.Where(m => char.IsLetter(m)).FirstOrDefault();
                    if (foundLetter != '\0')
                        result[columnIndex].Insert(0,foundLetter);
                }
            }

            return result;
        }

        private int GetMaxColumnNumber(int boxStacksEndline)
        {
            var numbers = ParsedData[boxStacksEndline].Split(' ').Where(m => !string.IsNullOrEmpty(m));
            return numbers.Last().ToInt();
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Times overlapped: {result}");
            return result.ToString();
        }

        internal abstract string Calculate();

    }
}
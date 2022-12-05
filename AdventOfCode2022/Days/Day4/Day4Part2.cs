namespace AdventOfCode2022.Days
{
    internal class Day4Part2 : Day4
    {
        internal Day4Part2(string filePath) : base(filePath)
        {

        }

        internal override int Calculate()
        {
            var result = 0;
            foreach (var parsedLine in ParsedData)
            {
                var splitters = new char[] { ',', '-' };
                var parsedLineNumbers = parsedLine.Split(splitters);

                if (FullyContains(parsedLineNumbers))
                    result++;
            }
            return result;
        }

        private bool FullyContains(string[] parsedLineNumbers)
        {
            var firstPairStart = parsedLineNumbers[0].ToInt();
            var firstPairFinish = parsedLineNumbers[1].ToInt();
            var secondPairStart = parsedLineNumbers[2].ToInt();
            var secondPairFinish = parsedLineNumbers[3].ToInt();
            if (firstPairStart >= secondPairStart && firstPairStart <= secondPairFinish)
                return true;

            if (firstPairFinish >= secondPairStart && firstPairFinish <= secondPairFinish)
                return true;

            if (secondPairStart >= firstPairStart && secondPairStart <= firstPairFinish)
                return true;

            if (secondPairFinish >= firstPairStart && secondPairFinish <= firstPairFinish)
                return true;

            return false;
        }
    }
}

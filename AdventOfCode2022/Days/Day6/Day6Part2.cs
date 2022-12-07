namespace AdventOfCode2022.Days
{
    internal class Day6Part2 : Day6
    {
        internal Day6Part2(string filePath) : base(filePath)
        {

        }

        private const int PacketLength = 14;

        internal override long Calculate()
        {
            bool foundStartSignal = false;
            int startingIndex = 0;
            while (!foundStartSignal)
            {
                var dataToTest = ParsedData.Skip(startingIndex).Take(PacketLength).Distinct();

                if (dataToTest.Count() == PacketLength)
                {
                    foundStartSignal = true;
                }

                startingIndex++;
            }

            return startingIndex + PacketLength - 1;
        }
    }
}

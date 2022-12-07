namespace AdventOfCode2022.Days
{
    internal class Day6Part1 : Day6
    {
        private const int PacketLength = 4;
        internal Day6Part1(string filePath) : base(filePath)
        {
        }

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

            return startingIndex + PacketLength -1;
        }

      
    }
}

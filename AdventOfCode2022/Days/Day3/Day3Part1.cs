namespace AdventOfCode2022.Days
{
    internal class Day3Part1 : Day3
    {
        internal Day3Part1(string filePath) : base(filePath)
        {
        }

        internal override int Calculate()
        {
            List<char> typesInBothCompartments = GetItemsInBothCompartments();
            return CalculatePriorityScore(typesInBothCompartments);

        }

        private int CalculatePriorityScore(List<char> typesInBothCompartments)
        {
            var result = 0;
            foreach (var typeInBothCompartments in typesInBothCompartments)
            {
                var add26Points = char.IsUpper(typeInBothCompartments);
                var points = char.ToLower(typeInBothCompartments) % 32;
                if (add26Points)
                    points += 26;
                result += points;
            }

            return result;
        }

        private List<char> GetItemsInBothCompartments()
        {
            var result = new List<char>();
            foreach (var parsedData in ParsedData)
            {
                var middleLetter = parsedData.Length / 2;
                var compartment1 = parsedData.Take(middleLetter).Distinct();
                var compartment2 = parsedData.Skip(middleLetter).Distinct();
                var dublicates = GetDublicates(compartment1, compartment2);
                result.AddRange(dublicates);
            }

            return result;
        }

        private List<char> GetDublicates(IEnumerable<char> compartment1, IEnumerable<char> compartment2)
        {
            var result = new List<char>();
            foreach (var typeInComp1 in compartment1)
            {
                foreach (var typeInComp2 in compartment2)
                {
                    if (typeInComp1.Equals(typeInComp2))
                        result.Add(typeInComp1);
                }
            }

            return result;
        }
    }
}

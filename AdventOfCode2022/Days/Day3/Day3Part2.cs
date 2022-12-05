namespace AdventOfCode2022.Days
{
    internal class Day3Part2 : Day3
    {
        internal Day3Part2(string filePath) : base(filePath)
        {
        }

        internal override int Calculate()
        {
            List<char> typesInBothCompartments = GetItemsInAll3Compartments();
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

        private List<char> GetItemsInAll3Compartments()
        {
            var result = new List<char>();
            for (int i = 0; i < ParsedData.Count(); i += 3)
            {
                var compartment1 = ParsedData[i].Distinct();
                var compartment2 = ParsedData[i + 1].Distinct();
                var compartment3 = ParsedData[i + 2].Distinct();
                var dublicatesFirstIteration = GetDublicates(compartment1, compartment2);
                var dublicatesSecondIteration = GetDublicates(dublicatesFirstIteration, compartment3);
                result.AddRange(dublicatesSecondIteration);
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

namespace AdventOfCode2022.Days
{
    internal class Day5Part2 : Day5
    {
        internal Day5Part2(string filePath) : base(filePath)
        {

        }

        internal override string Calculate()
        {
            foreach (var move in Moves)
            {
                var boxHeight = BoxStacks[move.FromColumnIndex].Count;
                var boxesToMove = BoxStacks[move.FromColumnIndex].Skip(boxHeight-move.Quantity);
                BoxStacks[move.ToColumnIndex].AddRange(boxesToMove);
                BoxStacks[move.FromColumnIndex].RemoveRange(boxHeight - move.Quantity, move.Quantity);
            }

            string result = string.Empty;
            foreach (var boxStack in BoxStacks)
            {
                result += boxStack.Last();
            }

            return result;
        }
    }
}

namespace AdventOfCode2022.Days
{
    internal class Day5Part1 : Day5
    {
        internal Day5Part1(string filePath) : base(filePath)
        {
        }

        internal override string Calculate()
        {
            foreach (var move in Moves)
            {
                int boxesMoved = 0;
                while (boxesMoved < move.Quantity)
                {
                    var boxToMove = BoxStacks[move.FromColumnIndex].LastOrDefault();
                    BoxStacks[move.ToColumnIndex].Add(boxToMove);
                    BoxStacks[move.FromColumnIndex].RemoveAt(BoxStacks[move.FromColumnIndex].Count - 1);
                    boxesMoved++;
                }
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

namespace AdventOfCode2022.Models
{
    internal class Tree
    {
        internal int Column;
        internal int Row;
        internal int Height;
        internal bool CanBeSeen;
        internal int Score { get; set; }

        internal Tree(int row, int column, int height) : this(row, column, height, false)
        {

        }

        internal Tree(int row, int column, int height, bool canBeSeen)
        {
            Column = column;
            Row = row;
            Height = height;
            CanBeSeen = canBeSeen;
            Score = 1;
        }
    }
}

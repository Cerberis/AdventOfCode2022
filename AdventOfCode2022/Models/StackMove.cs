namespace AdventOfCode2022.Models
{
    internal class StackMove
    {
        public int FromColumnIndex { get; set; }
        public int ToColumnIndex { get; set; }
        public int Quantity { get; set; }

        internal StackMove(int fromColumnIndex, int toColumnIndex, int quantity)
        {
            FromColumnIndex = fromColumnIndex - 1;
            ToColumnIndex = toColumnIndex - 1;
            Quantity = quantity;
        }
    }
}

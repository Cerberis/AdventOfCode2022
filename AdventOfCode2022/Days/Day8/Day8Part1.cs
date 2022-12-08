namespace AdventOfCode2022.Days
{
    internal class Day8Part1 : Day8
    {
        internal Day8Part1(string filePath) : base(filePath)
        {
        }

        protected override int Calculate()
        {
            MarkOutsideTrees();
            MarkHorizontalTrees();
            MarkVerticalTrees();
            return Trees.Count(m => m.CanBeSeen);
        }

        private void MarkOutsideTrees()
        {
            foreach (var tree in Trees.Where((m => m.Column == 0
                                                   || m.Column == LastColumnIndex
                                                   || m.Row == 0
                                                   || m.Row == LastRowIndex)))
            {
                tree.CanBeSeen = true;
            }
        }

        private void MarkVerticalTrees()
        {
            for (var columnIndex = 1; columnIndex <= LastColumnIndex; columnIndex++)
            {
                MarkTreesTopToBottom(columnIndex);
                MarkTreesBottomToTop(columnIndex);
            }
        }
        private void MarkHorizontalTrees()
        {
            for (var rowIndex = 1; rowIndex <= LastRowIndex; rowIndex++)
            {
                MarkTreesLeftToRight(rowIndex);
                MarkTreesRightToLeft(rowIndex);
            }
        }

        private void MarkTreesTopToBottom(int columnIndex)
        {
            var maxHeight = Trees.First(m => m.Column == columnIndex && m.Row == 0).Height;
            for (var rowIndex = 1; rowIndex <= LastRowIndex; rowIndex++)
            {
                var currentTree = Trees.First(m => m.Column == columnIndex && m.Row == rowIndex);
                if (maxHeight >= currentTree.Height) continue;
                Trees.First(m => m.Column == columnIndex && m.Row == rowIndex).CanBeSeen = true;
                maxHeight = currentTree.Height;
            }
        }

        private void MarkTreesBottomToTop(int columnIndex)
        {
            var maxHeight = Trees.First(m => m.Column == columnIndex && m.Row == LastRowIndex).Height;
            for (var rowIndex = LastRowIndex - 1; rowIndex >= 0; rowIndex--)
            {
                var currentTree = Trees.First(m => m.Column == columnIndex && m.Row == rowIndex);
                if (maxHeight >= currentTree.Height) continue;
                Trees.First(m => m.Column == columnIndex && m.Row == rowIndex).CanBeSeen = true;
                maxHeight = currentTree.Height;
            }
        }

        private void MarkTreesRightToLeft(int rowIndex)
        {
            var maxHeight = Trees.First(m => m.Row == rowIndex && m.Column == LastColumnIndex).Height;
            for (var columnIndex = LastColumnIndex - 1; columnIndex >= 0; columnIndex--)
            {
                var currentTree = Trees.First(m => m.Row == rowIndex && m.Column == columnIndex);
                if (maxHeight >= currentTree.Height) continue;
                Trees.First(m => m.Column == columnIndex && m.Row == rowIndex).CanBeSeen = true;
                maxHeight = currentTree.Height;
            }
        }

        private void MarkTreesLeftToRight(int rowIndex)
        {
            var maxHeight = Trees.First(m => m.Row == rowIndex && m.Column == 0).Height;
            for (var columnIndex = 1; columnIndex <= LastColumnIndex; columnIndex++)
            {
                var currentTree = Trees.First(m => m.Row == rowIndex && m.Column == columnIndex);
                if (maxHeight >= currentTree.Height) continue;
                Trees.First(m => m.Column == columnIndex && m.Row == rowIndex).CanBeSeen = true;
                maxHeight = currentTree.Height;
            }
        }
    }
}

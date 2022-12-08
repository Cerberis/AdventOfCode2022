namespace AdventOfCode2022.Days
{
    internal class Day8Part2 : Day8
    {
        private const int OutsideFirstIndex = 0;

        public Day8Part2(string filePath) : base(filePath)
        {
        }

        protected override int Calculate()
        {
            NullScoreForTreesOnEdge();
            CalculatePointsForHorizontalTrees();
            CalculatePointsForVerticalTrees();

            return Trees.Max(m => m.Score);

        }

        private void NullScoreForTreesOnEdge()
        {
            foreach (var tree in Trees.Where((m => m.Column == 0
                                                   || m.Column == LastColumnIndex
                                                   || m.Row == 0
                                                   || m.Row == LastRowIndex)))
            {
                tree.Score = 0;
            }
        }


        private void CalculatePointsForVerticalTrees()
        {
            for (var columnIndex = 1; columnIndex <= LastColumnIndex; columnIndex++)
            {
                CalculatePointsForTreesTopToBottom(columnIndex);
                CalculatePointsForTreesBottomToTop(columnIndex);
            }
        }
        private void CalculatePointsForHorizontalTrees()
        {
            for (var rowIndex = 1; rowIndex <= LastRowIndex; rowIndex++)
            {
                CalculatePointsForTreesLeftToRight(rowIndex);
                CalculatePointsForTreesRightToLeft(rowIndex);
            }
        }

        private void CalculatePointsForTreesTopToBottom(int columnIndex)
        {
            var firstTreeHeight = Trees.First(m => m.Column == columnIndex && m.Row == OutsideFirstIndex).Height;
            var maxHeights = new Dictionary<int, int> { { firstTreeHeight, OutsideFirstIndex } };
            for (var rowIndex = 1; rowIndex <= LastRowIndex; rowIndex++)
            {
                var currentTree = Trees.First(m => m.Column == columnIndex && m.Row == rowIndex);
                var scoreForSide = CalculateScore(maxHeights,rowIndex, currentTree.Height, OutsideFirstIndex, false);
                if (!maxHeights.ContainsKey(currentTree.Height))
                {
                    maxHeights.Add(currentTree.Height, rowIndex);
                }
                else
                {
                    maxHeights[currentTree.Height] = rowIndex;
                }
                Trees.First(m => m.Column == columnIndex && m.Row == rowIndex).Score *= scoreForSide;
            }
        }
        
        private void CalculatePointsForTreesBottomToTop(int columnIndex)
        {
            var firstTreeHeight = Trees.First(m => m.Column == columnIndex && m.Row == LastRowIndex).Height;
            var maxHeights = new Dictionary<int, int> { { firstTreeHeight, LastRowIndex } };
            for (var rowIndex = LastRowIndex - 1; rowIndex >= OutsideFirstIndex; rowIndex--)
            {
                var currentTree = Trees.First(m => m.Column == columnIndex && m.Row == rowIndex);
                var scoreForSide = CalculateScore(maxHeights, rowIndex, currentTree.Height, LastRowIndex, true);
                if (!maxHeights.ContainsKey(currentTree.Height))
                {
                    maxHeights.Add(currentTree.Height, rowIndex);
                }
                else
                {
                    maxHeights[currentTree.Height] = rowIndex;
                }

                Trees.First(m => m.Column == columnIndex && m.Row == rowIndex).Score *= scoreForSide;
            }
        }

        private void CalculatePointsForTreesRightToLeft(int rowIndex)
        {
            var firstTreeHeight = Trees.First(m => m.Row == rowIndex && m.Column == LastColumnIndex).Height;
            var maxHeights = new Dictionary<int, int> { { firstTreeHeight, LastColumnIndex } };
            for (var columnIndex = LastColumnIndex - 1; columnIndex >= OutsideFirstIndex; columnIndex--)
            {
                var currentTree = Trees.First(m => m.Column == columnIndex && m.Row == rowIndex);
                var scoreForSide = CalculateScore(maxHeights, columnIndex, currentTree.Height, LastColumnIndex, true);
                if (!maxHeights.ContainsKey(currentTree.Height))
                {
                    maxHeights.Add(currentTree.Height, columnIndex);
                }
                else
                {
                    maxHeights[currentTree.Height] = columnIndex;
                }

                Trees.First(m => m.Column == columnIndex && m.Row == rowIndex).Score *= scoreForSide;
            }
        }

        private void CalculatePointsForTreesLeftToRight(int rowIndex)
        {
            var firstTreeHeight = Trees.First(m => m.Row == rowIndex && m.Column == LastColumnIndex).Height;
            var maxHeights = new Dictionary<int, int> { { firstTreeHeight, OutsideFirstIndex } };

            for (var columnIndex = 1; columnIndex <= LastColumnIndex; columnIndex++)
            {
                var currentTree = Trees.First(m => m.Column == columnIndex && m.Row == rowIndex);
                var scoreForSide = CalculateScore(maxHeights, columnIndex, currentTree.Height, OutsideFirstIndex, false);
                if (!maxHeights.ContainsKey(currentTree.Height))
                {
                    maxHeights.Add(currentTree.Height, columnIndex);
                }
                else
                {
                    maxHeights[currentTree.Height] = columnIndex;
                }

                Trees.First(m => m.Column == columnIndex && m.Row == rowIndex).Score *= scoreForSide;
            }
        }
        private int CalculateScore(Dictionary<int, int> maxHeights, int currentIndex, int currentTreeHeight, int outsideIndex, bool reverseSearch)
        {
            int treeSideScore;
            var foundBiggerTrees = maxHeights.Where(m => m.Key >= currentTreeHeight);

            if (!foundBiggerTrees.Any())
            {
                if (!reverseSearch)
                {
                    treeSideScore =currentIndex - outsideIndex;
                }
                else
                {
                    treeSideScore = outsideIndex - currentIndex;
                }
            }
            else
            {
                if (!reverseSearch)
                {
                    treeSideScore =currentIndex - foundBiggerTrees.Max(m => m.Value);
                }
                else
                {
                    treeSideScore = foundBiggerTrees.Min(m => m.Value) - currentIndex;
                }
            }

            return treeSideScore;
        }

    }
}
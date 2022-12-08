namespace AdventOfCode2022.Days
{
    internal abstract class Day8
    {
        internal List<Tree> Trees;
        internal int LastColumnIndex;
        internal int LastRowIndex;

        internal Day8(string filePath)
        {
            ParseTrees(filePath);
            LastColumnIndex = Trees.Max(m => m.Column);
            LastRowIndex = Trees.Max(m => m.Row);
        }

        private void ParseTrees(string filePath)
        {
            Trees = new List<Tree>();
            var fileData = File.ReadLines(filePath).ToList();
            for (var rowIndex = 0; rowIndex < fileData.Count(); rowIndex++)
            {
                var row = fileData[rowIndex];
                for (var columnIndex = 0; columnIndex < row.Length; columnIndex++)
                {
                    var height = int.Parse(row[columnIndex].ToString());
                    Trees.Add(new Tree(rowIndex, columnIndex, height));
                }
            }
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }

        protected abstract int Calculate();


    }
}
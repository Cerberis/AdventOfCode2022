namespace AdventOfCode2022.Days
{
    internal class Day7Part1 : Day7
    {
        internal Day7Part1(string filePath) : base(filePath)
        {
        }

        protected override int Calculate()
        {
            var folderSum = DataStructure.Where(m => m.FileType ==FileType.Folder && m.Size < 100000).Sum(m => m.Size);
            return folderSum;
        }


    }
}

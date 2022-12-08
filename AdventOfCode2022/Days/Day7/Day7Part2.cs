namespace AdventOfCode2022.Days
{
    internal class Day7Part2 : Day7
    {
        internal Day7Part2(string filePath) : base(filePath)
        {

        }

        protected override int Calculate()
        {
            var rootFolderSum = DataStructure.First().Size;
            var freeSpace = FileCommands.DiskSpace - rootFolderSum;
            var neededDiskSpace = FileCommands.RequiredDiskSpace - freeSpace;
            var foundDirectory = DataStructure.Where(m => m.FileType == FileType.Folder && m.Size > neededDiskSpace).Min(m => m.Size);

            return foundDirectory;
        }
    }
}

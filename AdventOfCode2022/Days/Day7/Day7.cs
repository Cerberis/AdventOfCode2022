using System.ComponentModel.Design;

namespace AdventOfCode2022.Days
{
    internal abstract class Day7
    {
        internal List<FolderInformation> DataStructure { get; set; }

        internal Day7(string filePath)
        {
            GetDataStructure(filePath);
        }

        internal string Execute()
        {

            CalculateFolderSizes();
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }

        private void CalculateFolderSizes()
        {
            var foundFolders = DataStructure.Where(m => m.FileType == FileType.Folder && m.Size == 0);
            while (foundFolders.Any())
            {
                foreach (var foundFolder in foundFolders)
                {
                    var foundInsideFiles = DataStructure.Where(m => m.ParentIndex == foundFolder.Index);
                    if(foundInsideFiles.Any(m=> m.Size == 0))
                        continue;

                    var fileSum = foundInsideFiles.Sum(m => m.Size);
                    DataStructure.First(m => m.Index == foundFolder.Index).Size = fileSum;
                }
                foundFolders = DataStructure.Where(m => m.FileType == FileType.Folder && m.Size == 0);
            }
        }

        protected abstract int Calculate();

        void GetDataStructure(string filePath)
        {
            int currentIndex = FileCommands.RootFolderIndex;
            var latestIndex = FileCommands.RootFolderIndex;
            DataStructure = new List<FolderInformation>
            {
                new(latestIndex, "/", FileType.Folder)
            };
            latestIndex++;

            var rows = File.ReadAllLines(filePath);

            bool isListingFiles = false;
            foreach (var row in rows)
            {

                if (row.Contains(FileCommands.Command_DisplayItems))
                {
                    isListingFiles = true;
                    continue;
                }

                if (row.Contains(FileCommands.Command_SetDirectoryToRootFolder))
                {
                    currentIndex = FileCommands.RootFolderIndex;
                    isListingFiles = false;
                    continue;
                }

                if (row.Contains(FileCommands.Command_ChangeDirectoryToOneHigher))
                {
                    var currentFolder = DataStructure.First(m => m.Index == currentIndex);
                    if (currentFolder.ParentIndex.HasValue)
                    {
                        currentIndex = (int)currentFolder.ParentIndex;
                        isListingFiles = false;
                    }
                    continue;
                }

                if (row.Contains(FileCommands.Command_ChangeDirectory))
                {
                    var fileName = row.Replace(FileCommands.Command_ChangeDirectory, "");
                    var foundFolder = DataStructure.First(m => m.ParentIndex == currentIndex && m.Name == fileName);
                    currentIndex = foundFolder.Index;
                    isListingFiles = false;
                    continue;
                }

                if (!isListingFiles) continue;

                var listedObject = row.Split(" ");


                var foundObjectInDataStructure = DataStructure.FirstOrDefault(m => m.ParentIndex == currentIndex && m.Name == listedObject[1]);
                if (listedObject[0] == FileCommands.DirectoryCode)
                {
                    if (foundObjectInDataStructure != null) continue;
                    DataStructure.Add(new FolderInformation(latestIndex, listedObject[1], FileType.Folder, currentIndex));
                    latestIndex++;
                }
                else
                {
                    if (foundObjectInDataStructure != null) continue;
                    var fileSize = int.Parse(listedObject[0]);
                    DataStructure.Add(new FolderInformation(latestIndex, listedObject[1], FileType.File, currentIndex, fileSize));
                    latestIndex++;
                }
            }
        }
    }
}
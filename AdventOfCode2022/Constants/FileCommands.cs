namespace AdventOfCode2022.Constants
{
    internal class FileCommands
    {
        internal const string Command_DisplayItems = "$ ls";
        internal const string Command_SetDirectoryToRootFolder = "$ cd /";
        internal const string Command_ChangeDirectoryToOneHigher = "$ cd ..";
        internal const string Command_ChangeDirectory = "$ cd ";


        internal const int RootFolderIndex = 1;
        internal const string DirectoryCode = "dir";
        internal const int RequiredDiskSpace = 30000000;
        internal const int DiskSpace = 70000000;
    }
}

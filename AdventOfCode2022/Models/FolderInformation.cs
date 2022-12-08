namespace AdventOfCode2022.Models
{
    internal class FolderInformation
    {
        internal int Index;
        internal string Name;
        internal FileType FileType;
        internal int? ParentIndex;
        internal int Size;


        internal FolderInformation(int index, string name, FileType fileType) : this(index, name, fileType, null, 0)
        {

        }

        internal FolderInformation(int index, string name, FileType fileType, int parentIndex) : this(index, name, fileType, parentIndex, 0)
        {

        }

        internal FolderInformation(int index, string name, FileType fileType, int? parentIndex, int size)
        {
            Index = index;
            Name = name;
            FileType = fileType;
            ParentIndex = parentIndex;
            Size = size;
        }
    }
}

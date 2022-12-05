namespace CommonCode
{
    public static class FileReaders
    {
        public static List<List<int>> ReadDataFileAsIntMatrix(string filePath)
        {
            var result = new List<List<int>>();
            foreach (var line in File.ReadLines(filePath))
            {
                //result.Add(line.Split(' ').ToList());
            }

            return result;
        }

        public static List<List<string>> ReadDataFileAsStringMatrix(string filePath)
        {
            var result = new List<List<string>>();
            foreach (var line in File.ReadLines(filePath))
            {
               result.Add(line.Split(' ').ToList());
            }

            return result;
        }

        public static int[] ReadDataFileAsIntArray(string filePath)
        {
            return null;
        }

        public static List<string> ReadDataFileAsStringList(string filePath)
        {
            return File.ReadLines(filePath).ToList();
        }
    }
}
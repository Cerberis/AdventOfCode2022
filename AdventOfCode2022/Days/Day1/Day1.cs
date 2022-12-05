using System.Linq;

namespace AdventOfCode2022.Days
{
    internal class Day1
    {
        internal List<string> ParsedData { get; }
        internal int NumberOfElfs { get; }
        internal List<int> MaxCaloriesOnElfs { get; set; }

        internal Day1(string filePath, int numberOfElf)
        {
            ParsedData = ReadFile(filePath);
            NumberOfElfs = numberOfElf;
            FillMaxCaloriesOnElfes();
        }

        private void FillMaxCaloriesOnElfes()
        {
            MaxCaloriesOnElfs = new List<int>();
            for (var i = 0; i < NumberOfElfs; i++)
            {
                MaxCaloriesOnElfs.Add(0);
            }
        }

        internal string Execute()
        {
            Calculate();
            var totalCalories = MaxCaloriesOnElfs.Sum().ToString();
            Console.WriteLine($"Max calories: {totalCalories}");
            return totalCalories;
        }


        List<string> ReadFile(string filePath)
        {
            return FileReaders.ReadDataFileAsStringList(filePath);
        }

        void Calculate()
        {
            var currentCalories = 0;
            foreach (var calories in ParsedData)
            {
                if (string.IsNullOrWhiteSpace(calories))
                {
                    CheckMaxCalories(currentCalories);

                    currentCalories = 0;
                    continue;
                }
                currentCalories += calories.ToInt();
            }
            CheckMaxCalories(currentCalories);
        }

        void CheckMaxCalories(int calories)
        {
            if (MaxCaloriesOnElfs.Min() < calories)
            {
                UpdateLowestCalories(calories);
            }
            else if (MaxCaloriesOnElfs.Min() == calories && MaxCaloriesOnElfs.Contains(0))
            {
                UpdateLowestCalories(calories);
            }
        }

        void UpdateLowestCalories(int calories)
        {
            MaxCaloriesOnElfs.RemoveAt(NumberOfElfs - 1);
            MaxCaloriesOnElfs.Add(calories);
            MaxCaloriesOnElfs = MaxCaloriesOnElfs.OrderByDescending(m => m).ToList();
        }
    }
}

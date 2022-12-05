namespace AdventOfCode2022.Days
{
    internal class Day2Part1
    {
        private List<(OpponentsShape, Shape)> ParsedData { get; }
        private int Score = 0;

        private int PointsForLoose = 0;
        private int PointsForDraw = 3;
        private int PointsForWin = 6;

        internal Day2Part1(string filePath)
        {
            ParsedData = ParseData(filePath);
        }

        private List<(OpponentsShape, Shape)> ParseData(string filePath)
        {
            var result = new List<(OpponentsShape, Shape)>();
            foreach (var line in File.ReadLines(filePath))
            {
                var shapes = line.Split(' ').ToList();

                var opponentsShape = (OpponentsShape)Enum.Parse(typeof(OpponentsShape), shapes[0]);
                var myShape = (Shape)Enum.Parse(typeof(Shape), shapes[1]);
                result.Add(new(opponentsShape, myShape));
            }

            return result;
        }

        internal string Execute()
        {
            Calculate();
            Console.WriteLine($"Result: {Score}");
            return Score.ToString();
        }

        internal void Calculate()
        {
            foreach (var parsedData in ParsedData)
            {
                if (CheckIfDraw(parsedData))
                {
                    Score += (int)parsedData.Item2 + PointsForDraw;
                }
                else if (CheckIfWon(parsedData))
                {
                    Score += (int)parsedData.Item2 + PointsForWin;
                }
                else
                {
                    Score += (int)parsedData.Item2 + PointsForLoose;
                }
            }
        }

        private bool CheckIfDraw((OpponentsShape, Shape) parsedData)
        {
            return (int)parsedData.Item1 == (int)parsedData.Item2;
        }

        private bool CheckIfWon((OpponentsShape, Shape) parsedData)
        {
            return (parsedData.Item2 == Shape.X && parsedData.Item1 == OpponentsShape.C)
                   || (parsedData.Item2 == Shape.Y && parsedData.Item1 == OpponentsShape.A)
                   || (parsedData.Item2 == Shape.Z && parsedData.Item1 == OpponentsShape.B);
        }
    }
}

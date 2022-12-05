namespace AdventOfCode2022.Days
{
    internal class Day2Part2
    {
        private List<(OpponentsShape, RoundConclusion)> ParsedData { get; }
        private int Score = 0;

        private int PointsForLoose = 0;
        private int PointsForDraw = 3;
        private int PointsForWin = 6;

        internal Day2Part2(string filePath)
        {
            ParsedData = ParseData(filePath);
        }

        private List<(OpponentsShape, RoundConclusion)> ParseData(string filePath)
        {
            var result = new List<(OpponentsShape, RoundConclusion)>();
            foreach (var line in File.ReadLines(filePath))
            {
                var shapes = line.Split(' ').ToList();

                var opponentsShape = (OpponentsShape)Enum.Parse(typeof(OpponentsShape), shapes[0]);
                var myShape = (RoundConclusion)Enum.Parse(typeof(RoundConclusion), shapes[1]);
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
                (OpponentsShape, Shape) getMyShape = GetMyShape(parsedData);
                if (CheckIfDraw(getMyShape))
                {
                    Score += (int)getMyShape.Item2 + PointsForDraw;
                }
                else if (CheckIfWon(getMyShape))
                {
                    Score += (int)getMyShape.Item2 + PointsForWin;
                }
                else
                {
                    Score += (int)getMyShape.Item2 + PointsForLoose;
                }
            }
        }

        private (OpponentsShape, Shape) GetMyShape((OpponentsShape, RoundConclusion) parsedData)
        {
            var myShape = Shape.X;
            if (parsedData.Item2 == RoundConclusion.Y)
            {

                myShape = (Shape)((int)parsedData.Item1);
            }
            else if (parsedData.Item2 == RoundConclusion.X)
            {
                if (parsedData.Item1 == OpponentsShape.A)
                {
                    myShape = Shape.Z;
                }
                else if (parsedData.Item1 == OpponentsShape.B)
                {
                    myShape = Shape.X;
                }
                else if (parsedData.Item1 == OpponentsShape.C)
                {
                    myShape = Shape.Y;
                }
            }
            else if (parsedData.Item2 == RoundConclusion.Z)
            {
                if (parsedData.Item1 == OpponentsShape.A)
                {
                    myShape = Shape.Y;
                }
                else if (parsedData.Item1 == OpponentsShape.B)
                {
                    myShape = Shape.Z;
                }
                else if (parsedData.Item1 == OpponentsShape.C)
                {
                    myShape = Shape.X;
                }
            }

            return new (parsedData.Item1, myShape);
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
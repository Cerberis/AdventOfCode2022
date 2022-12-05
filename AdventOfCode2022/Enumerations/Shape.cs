using System.ComponentModel;

namespace AdventOfCode2022.Enumerations
{
    internal enum Shape
    {
        [Description("Rock")]
        X = 1,
        [Description("Paper")]
        Y = 2,
        [Description("Scizzors")]
        Z = 3
    }
}

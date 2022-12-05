namespace CommonCode.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string value)
        {
            int.TryParse(value, out int result);
            return result;
        }
    }
}

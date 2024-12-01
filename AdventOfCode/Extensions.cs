namespace AdventOfCode;

public static class Extensions
{
    public static long AsLong(this string input) => long.Parse(input);

    public static IEnumerable<long> AsLongArray(this IEnumerable<string> input) => input.Select(AsLong);
}
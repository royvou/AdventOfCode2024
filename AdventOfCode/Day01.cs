namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new(CalculatePart1(_input).ToString());

    private static long CalculatePart1(string input)
    {
        var parsedInput = ParseInput(input);
        var column1 = parsedInput.Select(x => x.One).OrderBy(x => x);
        var column2 = parsedInput.Select(x => x.Two).OrderBy(x => x);

        return column1.Zip(column2).Select(x => Math.Abs(x.First - x.Second)).Sum();
    }

    private static ( long One, long Two)[] ParseInput(string input)
        => input.Split(Environment.NewLine).Select(x => x.Split("   ")).Select(x => (One: x[0].AsLong(), Two: x[1].AsLong())).ToArray();

    public override ValueTask<string> Solve_2() => new(CalculatePart2(_input).ToString());

    private static long CalculatePart2(string input)
    {
        var parsedInput = ParseInput(input);
        var column2 = parsedInput.Select(x => x.Two).CountBy(x => x).ToDictionary(x => x.Key, y => y.Value);

        return parsedInput.Select(x => x.One * column2.GetValueOrDefault(x.One, 0)).Sum();
    }
}
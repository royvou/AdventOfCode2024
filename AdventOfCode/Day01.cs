namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new(CalculatePart1(_input).ToString());

    private int CalculatePart1(string input)
    {
        var b = input.Split(Environment.NewLine).Select(x => x.Split("   ")).ToArray();
        var column1 = b.Select(x => x[0]).Select(int.Parse).OrderBy(x => x);
        var column2 = b.Select(x => x[1]).Select(int.Parse).OrderBy(x => x);

        return column1.Zip(column2).Select(x => Math.Abs(x.First - x.Second)).Sum();
    }

    public override ValueTask<string> Solve_2() => new(CalculatePart2(_input).ToString());

    private int CalculatePart2(string input)
    {
        var b = input.Split(Environment.NewLine).Select(x => x.Split("   ")).ToArray();
        var column1 = b.Select(x => x[0]).Select(int.Parse).OrderBy(x => x);
        var column2 = b.Select(x => x[1]).Select(int.Parse);

        return column1.Zip(column2).Select(x => x.First * column2.Count(y => y == x.First)).Sum();
    }
}
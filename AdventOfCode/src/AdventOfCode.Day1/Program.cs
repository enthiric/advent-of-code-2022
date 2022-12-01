using Common;


static int Part1(IEnumerable<string> input)
{
    var list = string.Join(" ", Parser.Load())
        .Split("  ")
        .Select(x => x.Split(" "))
        .Select(x => x.Select(int.Parse).Sum()).ToList();
    list.Sort();
    return list.Last();
}

static int Part2(IEnumerable<string> input)
{
    var list = string.Join(" ", Parser.Load())
        .Split("  ")
        .Select(x => x.Split(" "))
        .Select(x => x.Select(int.Parse).Sum()).ToList();
    list.Sort();
    return list.Skip(Math.Max(0, list.Count() - 3)).Sum();
}

var input = Parser.Load();
Runner.Run(input, Part1);
Runner.Run(input, Part2);
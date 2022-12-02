using Common;


static string mapa(string input)
{
    return input switch
    {
        "X" => "A",
        "Y" => "B",
        _ => "C"
    };
}

static string mapb(string opp, string input)
{
    return input switch
    {
        "Y" => opp,
        "X" => opp switch
        {
            "A" => "C",
            "B" => "A",
            _ => "B"
        },
        "Z" => opp switch
        {
            "A" => "B",
            "B" => "C",
            _ => "A"
        },
        _ => ""
    };
}


// a rock x
// b paper y 
// c sciccors z

var input = Parser.Load();

static int Part1(IEnumerable<string> input)
{
    var scores = new Dictionary<string, int>()
    {
        { "A", 1 },
        { "B", 2 },
        { "C", 3 }
    };

    var sum = 0;
    foreach (var game in input)
    {
        var s = game.Split(" ");
        var x = mapa(s[1]);
        var y = s[0];
        var p = scores[x];
        if (y == x)
        {
            p += 3;
        }
        else
            switch (y.ToLower())
            {
                case "a" when x.ToLower() == "b":
                case "b" when x.ToLower() == "c":
                case "c" when x.ToLower() == "a":
                    p += 6;
                    break;
            }

        sum += p;
    }

    return sum;
}

static int Part2(IEnumerable<string> input)
{
    var scores = new Dictionary<string, int>()
    {
        { "A", 1 },
        { "B", 2 },
        { "C", 3 }
    };

    var sum = 0;
    foreach (var game in input)
    {
        var s = game.Split(" ");
        var y = s[0];
        var x = mapb(y, s[1]);
        var p = scores[x];
        if (y == x)
        {
            p += 3;
        }
        else
            switch (y.ToLower())
            {
                case "a" when x.ToLower() == "b":
                case "b" when x.ToLower() == "c":
                case "c" when x.ToLower() == "a":
                    p += 6;
                    break;
            }

        sum += p;
    }

    return sum;
}

Runner.Run(input, Part1);
Runner.Run(input, Part2);
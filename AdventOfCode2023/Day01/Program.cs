void Part01()
{
    var lines = File.ReadAllLines("calibration.txt");
    var sum = 0;

    foreach (var line in lines)
    {
        var firstDigit = "";
        var lastDigit = "";

        for (var i = 0; i < line.Length; i++)
            if (char.IsDigit(line[i]))
            {
                firstDigit = line[i].ToString();
                break;
            }

        for (var i = line.Length - 1; i >= 0; i--)
            if (char.IsDigit(line[i]))
            {
                lastDigit = line[i].ToString();
                break;
            }

        if (!string.IsNullOrEmpty(firstDigit) && !string.IsNullOrEmpty(lastDigit))
            sum += int.Parse(firstDigit + lastDigit);
    }

    Console.WriteLine("The sum of all calibration values is: " + sum);
}

void Part02()
{
    var spelledOutDigits = new Dictionary<string, int>
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 }
    };

    var lines = File.ReadAllLines("calibration.txt");
    var sum = 0;

    foreach (var line in lines)
    {
        var firstDigit = "";
        var lastDigit = "";

        for (var i = 0; i < line.Length; i++)
        {
            if (char.IsDigit(line[i]))
            {
                firstDigit = line[i].ToString();
                break;
            }

            foreach (var spelledOutDigit in spelledOutDigits)
                if (i + spelledOutDigit.Key.Length <= line.Length &&
                    line.Substring(i, spelledOutDigit.Key.Length) == spelledOutDigit.Key)
                {
                    firstDigit = spelledOutDigit.Value.ToString();
                    break;
                }

            if (!string.IsNullOrEmpty(firstDigit))
                break;
        }

        for (var i = line.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(line[i]))
            {
                lastDigit = line[i].ToString();
                break;
            }

            foreach (var spelledOutDigit in spelledOutDigits)
                if (i - spelledOutDigit.Key.Length + 1 >= 0 &&
                    line.Substring(i - spelledOutDigit.Key.Length + 1, spelledOutDigit.Key.Length) == spelledOutDigit.Key)
                {
                    lastDigit = spelledOutDigit.Value.ToString();
                    break;
                }

            if (!string.IsNullOrEmpty(lastDigit))
                break;
        }

        if (!string.IsNullOrEmpty(firstDigit) && !string.IsNullOrEmpty(lastDigit))
            sum += int.Parse(firstDigit + lastDigit);
    }

    Console.WriteLine("The sum of all calibration values is: " + sum);
}

Part01();
Part02();
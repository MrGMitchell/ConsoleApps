int start = 0; 
int end = 0;
string series = string.Empty;

Console.WriteLine("DigitCounter in C#\r");
Console.WriteLine("------------------------\n");

Console.WriteLine("Type a number for the start of the number series, and then press Enter");
start = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("\nType another number for the end of the number series, and then press Enter");
end = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("\nType a comma delimited list of digits. Each digit must be a number greater than 0 and less than 10, and then press Enter");
series = Console.ReadLine();

if (start > end)
{
    Console.WriteLine($"The start number must be less than or equal to the end number. Please try again.");
    Console.ReadKey();
}
else if (!string.IsNullOrEmpty(series))
{
    var digits = series.Split(',');


    foreach (var digit in digits)
    {
        var num = int.Parse(digit);
        var occurances = 0;

        if (num < 0 || num >= 10) {
            Console.WriteLine($"Number {num} will be skipped as it must be greater than zero and less than 10.");
            continue;
        }

        if (num * 11 >= start && num * 11 <= end)
        {
            occurances++;
        }

        while (num <= end)
        {
            if (num >= start && num <= end)
                occurances++;
            num += 10;
        }

        Console.WriteLine($"{digit} occurs {occurances} time(s)");
    }
}
else {
    Console.WriteLine($"Must enter a series of numbers to count. Please try again.");
    Console.ReadKey();
}

Console.Write("Press any key to close the DigitCounter console app...");
Console.ReadKey();
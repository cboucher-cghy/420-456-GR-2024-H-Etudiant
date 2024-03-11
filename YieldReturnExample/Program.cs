// Mettre un Breakpoint aux lignes: 3-6-14-16-19-27 et vérifier le comportement.
int i = 1;
IEnumerable<string> values = GetStrings().Take(10);
Console.WriteLine("Starting...");
foreach (string value in values)
{
    Console.WriteLine($"Writing #{i++,3} : {value}");
}
Console.WriteLine("Terminated...");
Console.ReadLine();

static IEnumerable<string> GetStrings()
{
    Console.WriteLine("Getting values of Strings");
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine($"Getting values #{i}");
        Thread.Sleep(1000);
        yield return GetString();
    }
}

static string GetString()
{
    Thread.Sleep(500);
    string value = Random.Shared.Next(0, 100).ToString();
    Console.WriteLine($"Value is {value}");

    return value;
}

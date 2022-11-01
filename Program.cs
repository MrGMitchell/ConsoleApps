using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();

Dictionary<string, int> words = new Dictionary<string, int>();

var exclude = new List<string> { "of", "the", "to", "and", "for" };

using (var stream = assembly.GetManifestResourceStream("Question1.Files.DeclarationIndependance.txt"))

using (StreamReader file = new StreamReader(stream))
{
    string ln;

    while ((ln = file.ReadLine()) != null)
    {
        var line = ln.Split(' ');

        for (int i = 0; i<line.Count(); i++) {
            var word = line[i].Replace(",", "").Replace(".", "").Replace("-", "").ToLower();

            if (exclude.Contains(word)) {
                continue;
            }

            if (words.ContainsKey(word))
            {
                words[word] = (int)words[word] + 1;
            }
            else { 
                words.Add(word, 1);
            }
        }
    }
    file.Close();
}

var sortedDict = from entry in words orderby entry.Value descending,entry.Key select entry;

int count = 100;

foreach (var kvp in sortedDict) {
    if (count == 0) {
        break;
    }
    count--;
    Console.WriteLine($"{kvp.Value} , {kvp.Key}");
}
Console.ReadKey();
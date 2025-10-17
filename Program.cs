Console.Clear();
Console.Write("let's encode your message: ");
string? decodedMessage = Console.ReadLine();
if (decodedMessage == null)
    Console.WriteLine("Invalid message.");
//using the pragma warning disable so VS code stops yelling at me.
#pragma warning disable CS8602
//split message into words.
var words = decodedMessage.Split([' '], StringSplitOptions.RemoveEmptyEntries).ToList();
//convert each word to pig latin.
for (int i = 0; i < words.Count; i++)
{
    string w = words[i];
    int i2 = 0;
    var vowels = "aeiouAEIOU";
    while (i2 < w.Length && !vowels.Contains(w[i2])) i2++;
        int t = w.Length; while (t > 0 && char.IsPunctuation(w[t - 1])) t--;
        var core = w[..t];
        var tail = w[t..];
        words[i] = (i2 == 0) ? core + "way" + tail : string.Concat(core.AsSpan(i2), core.AsSpan(0, i2), "ay") + tail;
}
//make output all lowercase.
words = words.ConvertAll(w => w.ToLowerInvariant());
var pigLatin = string.Join(' ', words);
Console.WriteLine("here is the message in Pig Latin: " + pigLatin);
//cryptogram encoding.
var enc = new System.Text.StringBuilder(pigLatin.Length);
int shift = 5;
foreach (var ch in pigLatin)
{
    if (char.IsLower(ch))
        enc.Append((char)('a' + ((ch - 'a' + shift) % 26 + 26) % 26));
    else
        enc.Append(ch);
} 
Console.WriteLine("here is the encrypted message: " + enc.ToString());
#pragma warning restore CS8602
// Input in terminal
// Event handler to listen input
// Make class to process input


Console.Write("Tell me what you want to say: ");
string? input = Console.ReadLine();

Cowsay cowsay = new Cowsay();
cowsay.say += onSay;
cowsay.Cow(input);

static void onSay() {
    System.Console.WriteLine("Testing");
}



using System.Diagnostics;

Console.Write("Enter a message:");
string input = Console.ReadLine();

ProcessStartInfo psi = new()
{
    FileName = "/bin/zsh",
    Arguments = $"-c \"cowsay '{input}'\"",
    RedirectStandardOutput = true,
    RedirectStandardInput = true,
    RedirectStandardError = true,
    UseShellExecute = false,
    CreateNoWindow = true
};

using Process process = new()
{
    StartInfo = psi
};
process.Start();

string output = await process.StandardOutput.ReadToEndAsync();

Console.WriteLine(output);

string error = await process.StandardError.ReadToEndAsync();
if (!string.IsNullOrEmpty(error))
{
    Console.WriteLine($"Error: {error}");
}

await process.WaitForExitAsync();


using System.Diagnostics;
public class Cowsay
{
    public event EventHandler<CowsayEventArgs>? CowsayEvent;

    public void InvokeCowsay(string? input)
    {
        string output = Say(input);  // Call the Say method to get the output
        CowsayEventArgs cowsayEventArgs = new CowsayEventArgs { Output = output };
        CowsayEvent?.Invoke(this, cowsayEventArgs);
    }

    private string Say(string? input)
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "/bin/zsh",
            Arguments = $"-c \"cowsay '{input}'\"",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using Process process = new Process();
        process.StartInfo = psi;
        process.Start();
        string output = process.StandardOutput.ReadToEnd();

        string error = process.StandardError.ReadToEnd();

        if (!string.IsNullOrEmpty(error))
        {
            Console.WriteLine($"Error: {error}");
        }

        process.WaitForExit();
        return output;
    }
}
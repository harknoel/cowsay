using System.Diagnostics;
public class CowsayEventArgs : EventArgs
{
    public string? Output { get; set;}

    public void Say(string? Input)
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "/bin/zsh",
            Arguments = $"-c \"cowsay '{Input}'\"",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using Process process = new();
        process.StartInfo = psi;
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        Output = output;

        string error = process.StandardError.ReadToEnd();

        if (!string.IsNullOrEmpty(error))
        {
            Console.WriteLine($"Error: {error}");
        }

        process.WaitForExit();
    }
}
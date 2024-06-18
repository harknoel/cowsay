public class Cowsay {
    public event Action? say;

    public void Cow(string word) {
        if (word == "hello") {
            say?.Invoke();
        }
        System.Console.WriteLine("no hello");
    }
}
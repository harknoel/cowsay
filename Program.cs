Cowsay cowsay = new Cowsay();
cowsay.CowsayEvent += OnCowsayEvent;

Console.Write("Tell me what you want to say: ");
string? input = Console.ReadLine();

cowsay.InvokeCowsay(input);

static void OnCowsayEvent(object? sender, CowsayEventArgs e)
{
    Console.WriteLine(e.Output);
}
using System.Diagnostics;
public class Cowsay
{
    public event EventHandler<CowsayEventArgs>? CowsayEvent;

    public void InvokeCowsay(string? input)
    {
        CowsayEventArgs cowsayEventArgs = new CowsayEventArgs();
        cowsayEventArgs.Say(input);
        CowsayEvent?.Invoke(this, cowsayEventArgs);
    }
}

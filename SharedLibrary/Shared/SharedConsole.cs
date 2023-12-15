namespace SharedLibrary;
public class SharedConsole : ISharedConsole
{
    public void WriteLine(string message) => 
		Console.WriteLine(message);
	public string? ReadLine() => 
		Console.ReadLine();
}
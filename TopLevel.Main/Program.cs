namespace TopLevel.Main;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        await Task.Yield();
        return 0;
    }
}

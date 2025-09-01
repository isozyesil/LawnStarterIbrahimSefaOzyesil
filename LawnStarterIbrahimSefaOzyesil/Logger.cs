public static class Logger
{
    public static void Info(string message)
    {
        TestContext.WriteLine($"[INFO] {DateTime.Now:HH:mm:ss} - {message}");
    }
    public static void Error(string message)
    {
        TestContext.WriteLine($"[ERROR] {DateTime.Now:HH:mm:ss} - {message}");
    }
}
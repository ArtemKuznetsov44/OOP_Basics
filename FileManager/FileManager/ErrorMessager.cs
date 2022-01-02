namespace FileManager
{
    internal static class ErrorMessager
    {
        public static void Message(string message)
        {
            Console.SetCursorPosition(1, Console.WindowHeight - 9);
            Console.Write(message);
        }
    }
}

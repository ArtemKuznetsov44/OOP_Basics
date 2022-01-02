namespace FileManager
{
    internal static class InfoPrinter
    {
        public static void PrintDirInfo(DirectoryInfo directory, double dirSize)
        {
            Console.SetCursorPosition(1, Console.WindowHeight - 7);
            Console.Write($"Dir full name: {directory.FullName}");
            Console.SetCursorPosition(1, Console.WindowHeight - 6);
            Console.Write($"Directory size: {(dirSize > 0 ? dirSize + " bytes" : "Error in getting directory size")}");
            Console.SetCursorPosition(1, Console.WindowHeight - 5);
            Console.Write($"Creation time: {directory.CreationTime}");
            Console.SetCursorPosition(1, Console.WindowHeight - 4);
            Console.Write($"Root directory: {directory.Root}");
        }
        public static void PrintFileInfo(FileInfo file)
        {
            Console.SetCursorPosition(1, Console.WindowHeight - 7);
            Console.Write($"File name: {file.FullName}");
            Console.SetCursorPosition(1, Console.WindowHeight - 6);
            Console.Write($"Creation time: {file.CreationTime}");
            Console.SetCursorPosition(1, Console.WindowHeight - 5);
            Console.Write($"Extension: {file.Extension}");
            Console.SetCursorPosition(1, Console.WindowHeight - 4);
            Console.Write($"Size: {file.Length + " bytes"}");
        }
    }
}

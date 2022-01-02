namespace FileManager
{
    internal static class CommandsData
    {
        public static void ShowCmdList()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 + 21, 3);
            Console.Write("Command list:");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 4);
            Console.Write("+ cd [path] - move between dirs.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 5);
            Console.Write("+ create -d [newDirName] - create dir.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 6);
            Console.Write("+ create -f [newFileName] - create file.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 7);
            Console.Write("+ delete -d [path] - delete dir.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 8);
            Console.Write("+ delete -f [path] - delete file.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 9);
            Console.Write("+ rename - d [currentDirName] [newDirName] - rename dir.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 10);
            Console.Write("+ rename -f [currentFileName] [newFileName] - rename file.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 11);
            Console.Write("+ copy -d [sourceDirName] [nameForCopiedDir]- copy dir.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 12);
            Console.Write("+ copy -f [sourceFileName] [nameForCopiedFile]- copy file.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 13);
            Console.Write("+ move -d [dirName] [newFullPath] - move dir."); 
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 14);
            Console.Write("+ move -f [fileName] [newFullPath] - move file."); 
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 15);
            Console.Write("+ info -d [dirName] - get info about dir.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 16);
            Console.Write("+ info -f [fileName] - get info about file.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 17);
            Console.Write("+ next -d - move to the next page with dirs.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 18);
            Console.Write("+ next -f - move to the next page with files.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 19);
            Console.Write("+ prev -d - move to the next page with dirs.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 20);
            Console.Write("+ prev -f - move to the next page with files.");
        }
    }
}

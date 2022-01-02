namespace FileManager
{
    // Класс предназначен для работы с дисками.
    internal static class DriveWorker
    {
        public static void PrintDrives() // Метод вывода дисков.
        {
            // Получение всех дисков.
            DriveInfo[] drives = DriveInfo.GetDrives();

            Console.SetCursorPosition(1, 3);
            Console.WriteLine("Drives:");

            int counter = 4; // Счетчик для установки курсора.

            // Цикл вывода дисков.
            foreach (DriveInfo drive in drives)
            {
                Console.SetCursorPosition(1, counter++);
                Console.WriteLine($"{(char)91}{(char)26} {drive.Name}");
            }
        } 
        public static void GetDriveInfo(string driveFullName) // Метод вывода инфорамции о диске.
        {
            driveFullName = driveFullName.Trim();

            DriveInfo driveInfo = new(driveFullName);

            if(driveInfo.IsReady) 
            {
                Console.SetCursorPosition(1, Console.WindowHeight - 7);
                Console.Write($"Drive name: {driveInfo.Name}");
                Console.SetCursorPosition(1, Console.WindowHeight - 6);
                Console.Write($"Drive type: {driveInfo.DriveType}");
                Console.SetCursorPosition(1, Console.WindowHeight - 5);
                Console.Write($"Drive capacity: {driveInfo.TotalSize + " bytes"}");
                Console.SetCursorPosition(1, Console.WindowHeight - 4);
                Console.Write($"Drive free space: {driveInfo.TotalFreeSpace + " bytes"}");
            }
        }
    }
}

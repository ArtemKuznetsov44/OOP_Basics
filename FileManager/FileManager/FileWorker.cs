namespace FileManager
{
    // Класс предназначен для работы с файлами.
    internal static class FileWorker
    {
        private static FileInfo[] files;
        private static string currentDir = String.Empty;
        private static int pages;
        private static int currentPage = 1;
        private static int offset;
        private static int totalNumberOfElements;
        public static int numberOfFilesForPrint;

        public static void PrintFiles(string path) // Простой вывод файлов по указанному пути.
        {
            // Получение всех файлов.
            if (currentDir != path)
            {
                files = new DirectoryInfo(path).GetFiles();
                totalNumberOfElements = files.Length;
                currentDir = path;
            }

            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 3);
            Console.WriteLine("Files:");

            int counter = 4;         // Счетчик для установки позиции курсора.
            int printedElements = 0; // Кол-во отображенных элементов.

            // Цикл вывода файлов.
            for (int i = offset != 0 ? offset : 0; i < files.Length; i++)
            {
                printedElements++;
                Console.SetCursorPosition(Console.WindowWidth / 2 + 1, counter++);
                Console.WriteLine($"{(char)91}{(char)26} {files[i].Name}");
                if (printedElements == numberOfFilesForPrint) break;
            }

            if (totalNumberOfElements < numberOfFilesForPrint)
                return;
                  
            PagesCount();       // Кол-во доступных страниц.
            ShowPageInfo();     // Выовод инфорамации.
        }
        public static void CreateFile(string name) // Создание файла.
        {
            name = name.Trim();
            FileInfo newFileInfo = new(currentDir + "\\" + name);
            if (!files.Contains(newFileInfo))
            {
                newFileInfo.Create();
                files = new DirectoryInfo(currentDir).GetFiles();
            }
            else ErrorMessager.Message("Such file already exist!");
        }
        public static void DeleteFile(string fileName) // Удалние файла.
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                files = new DirectoryInfo(currentDir).GetFiles();
            }
            else if (File.Exists(currentDir + "\\" + fileName))
            {
                File.Delete(currentDir + "\\" + fileName);
                files = new DirectoryInfo(currentDir).GetFiles();
            }
            else ErrorMessager.Message("Such file does not exist!");
        }
        public static void RenameFile(string fileNames) // Переименование файла.
        {
            fileNames = fileNames.Trim();
            string[] names = fileNames.Split();

            //FileInfo[] files = new DirectoryInfo(pathToView).GetFiles();
            FileInfo currentFileName = new(currentDir+ "\\" + names[0]);
            FileInfo newFileName = new(currentDir + "\\" + names[1]);

            if (currentFileName.Exists)
            {
                if (!files.Contains(newFileName)) 
                {
                    currentFileName.MoveTo(newFileName.FullName);
                    files = new DirectoryInfo(currentDir).GetFiles(); 
                }
                else ErrorMessager.Message("Name needs to be changed!");
            }
            else ErrorMessager.Message("Such file does not exist!");
        }
        public static void CopyFile(string fileNames) // Копирование файла.
        {
            fileNames = fileNames.Trim();
            string[] names = fileNames.Split();
            if (File.Exists(currentDir + "\\" + names[0]) && names[0] != names[1]) 
            {
                File.Copy(currentDir + "\\" + names[0], currentDir + "\\" + names[1]);
                files = new DirectoryInfo(currentDir).GetFiles(); 
            }
            else ErrorMessager.Message("Such a file does not exist or names must be different!");
        }
        public static void MoveFile(string path) // Перемещение файла.
        {
            path = path.Trim();
            string[] pathes = path.Split();

            FileInfo choosedFileInfo = new(currentDir + "\\" + pathes[0]);

            if (!pathes[1].Contains('\\'))
            {
                if (choosedFileInfo.Exists)
                {
                    if (Directory.Exists(currentDir + "\\" + pathes[1]))
                    {
                        try
                        {
                            choosedFileInfo.MoveTo(currentDir + "\\" + pathes[1] + "\\" + choosedFileInfo.Name);
                        }
                        catch (Exception ex) { ErrorMessager.Message(ex.Message); }
                    }
                    else ErrorMessager.Message("Destination directory does not exist!");
                }
                else ErrorMessager.Message("File for move does not exist!");
            }
            else if (pathes[1].Contains('\\'))
            {
                if (choosedFileInfo.Exists)
                {
                    if (Directory.Exists(pathes[1]))
                    {
                        try
                        {
                            choosedFileInfo.MoveTo(pathes[1] + "\\" + choosedFileInfo.Name);
                        }
                        catch (Exception ex) { ErrorMessager.Message(ex.Message); }
                    }
                    else ErrorMessager.Message("Destination directory does not exist!");
                }
                else ErrorMessager.Message("File for move does not exist!");
            }
        }
        public static void PrintNextPage() // Вывод следующей страниции файлов..
        {
            if (pages > 1 && currentPage < pages)
            {
                offset += numberOfFilesForPrint;
                currentPage++;
                PrintFiles(currentDir);
            }
            else
            {
                offset = 0;
                currentPage = 1;
                PrintFiles(currentDir);
            }
        }
        public static void PrintPrevPage() // Вывод предыдущей страницы файлов.
        {
            if (pages > 1 && currentPage > 1)
            {
                offset -= numberOfFilesForPrint;
                currentPage--;
                PrintFiles(currentDir);
            }
            else
            {
                offset = 0;
                currentPage = 1;
                PrintFiles(currentDir);
            }
        }
        public static void PrintFileInfo(string path)  // Вывод инфорамации о файле.
        {
            // Если путь был указан полностью.
            if (File.Exists(path))
            {
                FileInfo fileInfo = new(path);
                InfoPrinter.PrintFileInfo(fileInfo);

                if (fileInfo.Extension == ".txt")
                {
                    TextWorker.GetTextInfo(fileInfo);
                    TextWorker.PrintInfo();
                }
            }
            else // Если было указано лишь имя.
            {
                if (File.Exists(currentDir + "\\" + path))
                {
                    FileInfo fileInfo = new(currentDir + "\\" + path);
                    InfoPrinter.PrintFileInfo(fileInfo);

                    if (fileInfo.Extension == ".txt")
                    {
                        TextWorker.GetTextInfo(fileInfo);
                        TextWorker.PrintInfo(); 
                    }
                }
                else ErrorMessager.Message("Such file does not exist!");
            }
        }
        private static void PagesCount() // Подсчет общего кол-ва страниц доступных для отображения.
        {
            pages = totalNumberOfElements / numberOfFilesForPrint;
            if (totalNumberOfElements % numberOfFilesForPrint != 0) pages++;
        }
        private static void ShowPageInfo() // Вывод информации о страницах/кол-ве файлов.
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, Console.WindowHeight - 10);
            Console.Write($"Page {currentPage} of {pages}");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, Console.WindowHeight - 9);
            Console.Write($"The total number of files along this path: {totalNumberOfElements}");
        }
        public static void BringDef() // Сброс до дефолтных значений.
        {
            offset = 0;
            pages = 0;
            totalNumberOfElements = 0;
            currentPage = 1;
        }
    }
}
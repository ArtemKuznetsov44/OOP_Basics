namespace FileManager
{
    internal static class DirWorker
    {
        private static DirectoryInfo[] directories;
        private static string currentDir = String.Empty; 
        private static int pages;
        private static int currentPage = 1;
        private static int offset;
        private static int totalNumberOfElements;
        public static int numberOfDirectoriesForPrint; 

        public static void PrintDirs(string path) // Вывод списка дирректорий.
        {
            // Получение всех дирректорий.
            if(currentDir != path)
            {
                directories = new DirectoryInfo(path).GetDirectories();
                totalNumberOfElements = directories.Length;
                currentDir = path;
            }
           
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("Directories:");

            int counter = 4;         // Счетчик для установки курсора.
            int printedElements = 0; // Кол-во отображенных дирректорий.

            // Цикл вывода дирректорий.
            for (int i = offset != 0 ? offset : 0; i < directories.Length; i++)
            {
                printedElements++;
                Console.SetCursorPosition(1, counter++);
                Console.WriteLine($"{(char)91}{(char)26} {directories[i].Name}");
                if (printedElements == numberOfDirectoriesForPrint)
                    break;
            }
            // Если кол-во полученных дирреторий больше, чем кол-во элементов доступных для отображения.
            if (totalNumberOfElements < numberOfDirectoriesForPrint)
                return;

            PagesCount();       // Кол-во доступных страниц.
            ShowPageInfo();     // Выовод инфорамации.
        }
        public static void CreateDir(string directoryName) // Создание дирректории.
        {
            directoryName = directoryName.Trim();
            DirectoryInfo newDirectoryInfo = new(currentDir + "\\" + directoryName);
            if (!directories.Contains(newDirectoryInfo))
            {
                newDirectoryInfo.Create();
                directories = new DirectoryInfo(currentDir).GetDirectories();
            }
            else ErrorMessager.Message("Such directory alerady exist! Please, change the name.");
        }
        public static void DeleteDir(string directoryName)  // Удаление дирректории.
        {
            if (Directory.Exists(directoryName))
            {
                Directory.Delete(directoryName, true);
                directories = new DirectoryInfo(currentDir).GetDirectories();
            }
            else if (Directory.Exists(currentDir + "\\" + directoryName)) 
            {
                Directory.Delete(currentDir + "\\" + directoryName, true);
                directories = new DirectoryInfo(currentDir).GetDirectories(); 
            }
            else ErrorMessager.Message("Such directory does not exist!");
        }
        public static void RenameDir(string dirNames) // Переименование дирректории.
        {
            dirNames = dirNames.Trim();
            string[] names = dirNames.Split();

            DirectoryInfo currentDirInfo = new(currentDir + "\\" + names[0]);
            DirectoryInfo newDirInfo = new(currentDir + "\\" + names[1]);
           
            if (currentDirInfo.Exists)
            {
                if (!directories.Contains(newDirInfo)) 
                {
                    currentDirInfo.MoveTo(newDirInfo.FullName);
                    directories = new DirectoryInfo(currentDir).GetDirectories(); 
                }    
                else ErrorMessager.Message("Name needs to be changed!");
            }
            else ErrorMessager.Message("Such directory does not exist!");
        }
        public static void CopyDir(string dirsNames) // Копирование дирректории.
        {
            dirsNames = dirsNames.Trim();
            string[] names = dirsNames.Split();

            if (Directory.Exists(currentDir + "\\" + names[0]) && names[0] != names[1])
            {
                try
                {
                    DirectoryInfo sourdceDirInfo = new(currentDir + "\\" + names[0]);
                    DirectoryInfo destDirInfo = new(currentDir + "\\" + names[1]);
                    CopyDirectoryOperation(sourdceDirInfo, destDirInfo);
                    directories = new DirectoryInfo(currentDir).GetDirectories(); 
                }
                catch (Exception ex) { ErrorMessager.Message(ex.Message); }
            }
            else ErrorMessager.Message("Such directory does not exist or names must be different!");
        }
        public static void MoveDir(string path) // Перемещение дирректории.
        {
            path = path.Trim();
            string[] pathes = path.Split();

            DirectoryInfo choosedDirInfo = new(currentDir + "\\" + pathes[0]);

            if (!pathes[1].Contains('\\'))
            {
                if (choosedDirInfo.Exists)
                {
                    if (Directory.Exists(currentDir + "\\" + pathes[1]))
                    {
                        try
                        {
                            choosedDirInfo.MoveTo(currentDir + "\\" + pathes[1] + "\\" + choosedDirInfo.Name);
                            directories = new DirectoryInfo(currentDir).GetDirectories(); 
                        }
                        catch (Exception ex) { ErrorMessager.Message(ex.Message); }
                    }
                    else ErrorMessager.Message("Destination directory does not exist!");
                }
                else ErrorMessager.Message("Directory for move does not exist!");
            }
            else if (pathes[1].Contains('\\'))
            {
                if (choosedDirInfo.Exists)
                {
                    if (Directory.Exists(pathes[1]))
                    {
                        try
                        {
                            choosedDirInfo.MoveTo(pathes[1] + "\\" + choosedDirInfo.Name);
                            directories = new DirectoryInfo(currentDir).GetDirectories();
                        }
                        catch (Exception ex) { ErrorMessager.Message(ex.Message); }
                    }
                    else ErrorMessager.Message("Destination directory does not exist!");
                }
                else ErrorMessager.Message("Directory for move does not exist!");
            }
        }
        public static void PrintNextPage() // Отображение следующей страницы дирректорий.
        {
            if (pages > 1 && currentPage < pages)
            {
                offset += numberOfDirectoriesForPrint; 
                currentPage++;
                PrintDirs(currentDir);
            }
            else
            {
                offset = 0;
                currentPage = 1;
                PrintDirs(currentDir);
            }
        }
        public static void PrintPrevPage() // Отображание предыдущей страницы дирректорий.
        {
            if (pages > 1 && currentPage > 1)
            {
                offset -= numberOfDirectoriesForPrint;
                currentPage--;
                PrintDirs(currentDir);
            }
            else
            {
                offset = 0;
                currentPage = 1;
                PrintDirs(currentDir);
            }
        }
        public static void PrintDirInfo(string path) // Вывод информации о дирректории.
        {
            double dirSize  = default;
            // Если путь был указан полностью.
            if (Directory.Exists(path)) 
            {
                dirSize = GetDirSize(currentDir + "\\" + path, dirSize);
                DirectoryInfo directoryInfo = new(path);
                InfoPrinter.PrintDirInfo(directoryInfo, dirSize);
            }
            else // Если было указано лишь имя.
            {
                if (Directory.Exists(currentDir + "\\" + path)) 
                {
                    dirSize = GetDirSize(currentDir + "\\" + path, dirSize); 
                    DirectoryInfo directoryInfo = new(currentDir + "\\" + path);
                    InfoPrinter.PrintDirInfo(directoryInfo, dirSize);
                }
                else ErrorMessager.Message("Such directory does not exist!");
            }
        }
        private static void CopyDirectoryOperation(DirectoryInfo source, DirectoryInfo destination)
        {
            if (!destination.Exists) destination.Create();

            FileInfo[] files = source.GetFiles();
            foreach (FileInfo file in files) // Копирование всех файлов ресурса в новый каталог.
            {
                file.CopyTo(Path.Combine(destination.FullName, file.Name));
            }

            DirectoryInfo[] dirs = source.GetDirectories();
            foreach (DirectoryInfo dir in dirs) // Копирование всех подкаталогов из ресурса в новый каталог.
            {
                string destinationDir = Path.Combine(destination.FullName, dir.Name); // Создание пути до нового каталога.
                CopyDirectoryOperation(dir, new DirectoryInfo(destinationDir)); // Вызов метода рекурсивно!
            }
        } // Основная логика копирования.
        private static double GetDirSize(string path, double dirSize)
        {
            try
            {
                DirectoryInfo directoryInfo = new(path);
                DirectoryInfo[] directories = directoryInfo.GetDirectories();
                FileInfo[] files = directoryInfo.GetFiles();
                //В цикле пробегаемся по всем файлам директории  и складываем их размеры
                foreach (FileInfo file in files)
                {
                    //Записываем размер файла в байтах
                    dirSize += file.Length;
                }
                //В цикле пробегаемся по всем вложенным директориям директории di 
                foreach (DirectoryInfo dir in directories)
                {
                    //рекурсивно вызываем наш метод
                    GetDirSize(dir.FullName, dirSize);
                }
                return dirSize;
            }
            catch (Exception) { return -1; }
        }
        private static void PagesCount() // Подсчет кол-ва страниц доступных для отображения.
        {
            pages = totalNumberOfElements / numberOfDirectoriesForPrint;
            if (totalNumberOfElements % numberOfDirectoriesForPrint != 0) pages++;
        }
        private static void ShowPageInfo() // Вывод информации о страницах/кол-ве дирректорий.
        {
            Console.SetCursorPosition(1, Console.WindowHeight - 10);
            Console.Write($"Page {currentPage} of {pages}");
            Console.SetCursorPosition(1, Console.WindowHeight - 9);
            Console.Write($"The total number of directories along this path: {totalNumberOfElements}");
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
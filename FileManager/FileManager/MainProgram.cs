using FileManager;

// Создание необходимой дирректории в случаее её отсутствия.
if (!Directory.Exists(@"..\..\..\errors")) Directory.CreateDirectory(@"..\..\..\errors");

// Сохраняем путь к файлу, в котором будут записываться непредвиденные ошибки.
string exceptionFile = @"..\..\..\errors\exceptions.txt";

Console.Title = "StupidFileMager beta V0.2";

PathQualifier PathQualifier = new();
Stack<string> stackOfPathes = new();

Commands command;                   // Обявление переменной типа перечисление.
int numberOfElements = 15;          // Кол-во элементов для отображения на одной странице.
string pathToView = String.Empty;   // Строка для отображение текущего пути.

FileWorker.numberOfFilesForPrint = numberOfElements;
DirWorker.numberOfDirectoriesForPrint = numberOfElements;

do
{
    try
    {
        // Вывод инфорации о дисках.
        if (pathToView == String.Empty) DriveWorker.PrintDrives();

        // Оформление консольного окна
        MainWindow.PrintMarkup();

        // Отображение "действующего" пути.
        Console.SetCursorPosition(1, 1);
        Console.Write($"Current path: {pathToView}");

        // Строка ввода пользователя.
        Console.SetCursorPosition(1, Console.WindowHeight - 2);
        string? input = Console.ReadLine();

        // Небольшая проверка.
        if (input == null)
        {
            command = Commands.UNKNOWN;
            input = String.Empty;
        }
        else command = CommandQualifier.Define(input);

        if (command == Commands.SWITCH)                 // Переключение между каталогами.
        {
            Console.Clear();
            PathQualifier.GetPath(input, command);

            // Сброс до дефолтных значений.
            DirWorker.BringDef();
            FileWorker.BringDef();

            // Если путь был введел полностью
            if (Directory.Exists(PathQualifier.Path))
            {
                // Работа с полученным путем.
                stackOfPathes.Push(pathToView);
                pathToView = PathQualifier.Path;

                DirWorker.PrintDirs(pathToView);
                FileWorker.PrintFiles(pathToView);
            }
            else
            {
                if (PathQualifier.Check(PathQualifier.Path, pathToView))
                {
                    // Работа с полученным путем
                    stackOfPathes.Push(pathToView);
                    pathToView += (PathQualifier.Path.StartsWith("\\") ? PathQualifier.Path : "\\" + PathQualifier.Path);
                    if (pathToView.Contains("\\\\")) pathToView = pathToView.Replace("\\\\", "\\");

                    DirWorker.PrintDirs(pathToView);
                    FileWorker.PrintFiles(pathToView);
                }
                else
                {
                    if(pathToView != String.Empty) 
                    {
                        DirWorker.PrintDirs(pathToView);
                        FileWorker.PrintFiles(pathToView);
                    }
                    ErrorMessager.Message("Incorrect path"); 
                }
            }
        }
        else if (command == Commands.CREATE_DIR)         // Создание дирректории.
        {
            Console.Clear();
            PathQualifier.GetPath(input, command);
            DirWorker.CreateDir(PathQualifier.Path);
            DirWorker.PrintDirs(pathToView);
            FileWorker.PrintFiles(pathToView);
        }
        else if (command == Commands.CREATE_FILE)        // Создание файла.
        {
            Console.Clear();
            PathQualifier.GetPath(input, command);
            FileWorker.CreateFile(PathQualifier.Path);
            DirWorker.PrintDirs(pathToView);
            FileWorker.PrintFiles(pathToView);
        }
        else if (command == Commands.DELETE_DIR)        // Удаление дирректории.
        {
            Console.Clear();
            PathQualifier.GetPath(input, command);
            DirWorker.DeleteDir(PathQualifier.Path);
            DirWorker.PrintDirs(pathToView);
            FileWorker.PrintFiles(pathToView);
        }
        else if (command == Commands.DELETE_FILE)       // Удаление файла.
        {
            Console.Clear();
            PathQualifier.GetPath(input, command);
            FileWorker.DeleteFile(PathQualifier.Path);
            DirWorker.PrintDirs(pathToView);
            FileWorker.PrintFiles(pathToView);
        }
        else if (command == Commands.RENAME_DIR)        // Переименование дирректории.
        {
            Console.Clear();
            PathQualifier.GetPath(input, command);
            DirWorker.RenameDir(PathQualifier.Path);
            DirWorker.PrintDirs(pathToView);
            FileWorker.PrintFiles(pathToView);
        }
        else if (command == Commands.RENAME_FILE)       // Переименование файла.
        {
            Console.Clear();
            PathQualifier.GetPath(input, command);
            FileWorker.RenameFile(PathQualifier.Path);
            DirWorker.PrintDirs(pathToView);
            FileWorker.PrintFiles(pathToView);
        }
        else if (command == Commands.COPY_FILE)         // Копирование файла.
        {
            Console.Clear();
            PathQualifier.GetPath(input, command);
            FileWorker.CopyFile(PathQualifier.Path);
            DirWorker.PrintDirs(pathToView);
            FileWorker.PrintFiles(pathToView);
        }
        else if (command == Commands.COPY_DIR)          // Копирование дирректории.
        {
            Console.Clear();
            PathQualifier.GetPath(input, command);
            DirWorker.CopyDir(PathQualifier.Path);
            DirWorker.PrintDirs(pathToView);
            FileWorker.PrintFiles(pathToView);
        }
        else if (command == Commands.MOVE_DIR)           // Перемещение дирретории.
        {
            Console.Clear();
            PathQualifier.GetPath(input, command);
            DirWorker.MoveDir(PathQualifier.Path);
            DirWorker.PrintDirs(pathToView);
            FileWorker.PrintFiles(pathToView);
        }
        else if (command == Commands.MOVE_FILE)          // Перемещение файла.
        {
            Console.Clear();
            PathQualifier.GetPath(input, command);
            FileWorker.MoveFile(PathQualifier.Path);
            DirWorker.PrintDirs(pathToView);
            FileWorker.PrintFiles(pathToView);
        }
        else if (command == Commands.GET_FILE_INFO)     // Получение информации о файле.
        {
            Console.Clear();
            PathQualifier.GetPath(input, command);
            FileWorker.PrintFileInfo(PathQualifier.Path);
            DirWorker.PrintDirs(pathToView);
            FileWorker.PrintFiles(pathToView);
        }
        else if (command == Commands.GET_DIR_INFO)      // Получение информации о калоге.
        {
            Console.Clear();
            PathQualifier.GetPath(input, command);
            DirWorker.PrintDirInfo(PathQualifier.Path);
            DirWorker.PrintDirs(pathToView);
            FileWorker.PrintFiles(pathToView);
        }
        else if (command == Commands.GET_DRIVE_INFO)    // Получение информации о диске.
        {
            Console.Clear();
            PathQualifier.GetPath(input, command);
            DriveWorker.GetDriveInfo(PathQualifier.Path);
        }
        else if (command == Commands.NEXT_DIR_PAGE)     // Вывод следующей страницы дирректорий.
        {
            Console.Clear();
            DirWorker.PrintNextPage();
            FileWorker.PrintFiles(pathToView);
        }
        else if (command == Commands.PREV_DIR_PAGE)     // Вывод предыдущей страницы дирректорий..
        {
            Console.Clear();
            DirWorker.PrintPrevPage();
            FileWorker.PrintFiles(pathToView);
        }
        else if (command == Commands.NEXT_FILE_PAGE)    // Вывод следующей страницы файлов.
        {
            Console.Clear();
            DirWorker.PrintDirs(pathToView);
            FileWorker.PrintNextPage();
        }
        else if (command == Commands.PREV_FILE_PAGE)    // Вывод предыдущей страницы файлов.
        {
            Console.Clear();
            DirWorker.PrintDirs(pathToView);
            FileWorker.PrintPrevPage();
        }

        else if (command == Commands.COMMANDS_LIST)     // Вывод спика всех доступных команд. 
        {
            Console.Clear();
            CommandsData.ShowCmdList();
        }
        else if (command == Commands.GO_BACK)           // Возвращение на одну дирректорию выше.
        {
            Console.Clear();
            if (stackOfPathes.Count > 0)
                pathToView = stackOfPathes.Pop();
            DirWorker.PrintDirs(pathToView);
            FileWorker.PrintFiles(pathToView);
        }
        else if (command == Commands.UNKNOWN)           // Не удалось распознать комманду.
        {
            Console.Clear();
            DirWorker.PrintDirs(pathToView);
            FileWorker.PrintFiles(pathToView);
        }
    }
    catch (Exception ex)                                // В случаее возникнования ошибки. 
    {
        using (StreamWriter sw = new(exceptionFile, true, System.Text.Encoding.Default))
        {
            sw.WriteLine(ex.ToString());
        }
    }
} while (true);
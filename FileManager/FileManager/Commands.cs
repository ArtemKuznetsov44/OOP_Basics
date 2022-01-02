namespace FileManager
{
    internal enum Commands
    {
        SWITCH,         // Переключение между дирректориями. (cd [path])
        CREATE_DIR,     // Создание дирректории. (create -d [dirName])
        CREATE_FILE,    // Создание файла. (create -f [fileName])
        DELETE_DIR,     // Удаление дирректории. (delete -d [dirName])
        DELETE_FILE,    // Удаление файла. (delete -f [fileName])
        RENAME_DIR,     // Переименование дирректории. (rename -d [currentDirName] [newDirName])
        RENAME_FILE,    // Преименование файла. (rename -f [currentFileName] [newFileName])
        COPY_DIR,       // Копирование дирректории. [copy -d [sourceDirName] [nameForCopiedDir])
        COPY_FILE,      // Копирование файла. (copy -f [sourceFileName] [nameForCopiedFile])
        MOVE_DIR,       // Перемещение папки. (move -d [dirName] [newFullPath])
        MOVE_FILE,      // Перемещение файла. (move -f [fileName] [newFullPath])
        GET_DRIVE_INFO, // Получение информации о диске. (info -D [driveName])
        GET_DIR_INFO,   // Получение информации о дирректории. (info -d [dirName])
        GET_FILE_INFO,  // Получение информации о файле. (info -f [fileName])
        NEXT_DIR_PAGE,  // Отображение следующей страницы с дирректориями. (next -d)
        PREV_DIR_PAGE,  // Отображение предыдущей страницы с дирректориями. (prev -d)
        NEXT_FILE_PAGE, // Отображение слудующей страницы с файлами. (next -f)
        PREV_FILE_PAGE, // Отображение предыдущей страницы с файлами. (prev -f)
        COMMANDS_LIST,  // Отображение списка всех доступных коммант. (cmd -list)
        GO_BACK,        // Переход на одну директорию выше. (cd ..)cd 
        UNKNOWN
    }
}

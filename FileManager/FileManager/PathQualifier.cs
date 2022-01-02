namespace FileManager
{
    // Класс предназначен для получение путей/названиий дирректорий/файлов.
    internal sealed class PathQualifier
    {
        private string _path = String.Empty;

        // Метод для возращение путей/названий дирреторий/файов.
        public void GetPath(string input, Commands command)
        {
            if (command == Commands.SWITCH)
            {
                input = input.Trim();
                input = input.Replace("cd ", "");
                Path = input;
            }
            else if (command == Commands.CREATE_DIR)
            {
                input = input.Trim();
                input = input.Replace("create -d ", "");
                Path = input;
            }
            else if (command == Commands.CREATE_FILE)
            {
                input = input.Trim();
                input = input.Replace("create -f ", "");
                Path = input;
            }
            else if (command == Commands.DELETE_DIR)
            {
                input = input.Trim();
                input = input.Replace("delete -d ", "");
                Path = input;
            }
            else if (command == Commands.DELETE_FILE)
            {
                input = input.Trim();
                input = input.Replace("delete -f ", "");
                Path = input;
            }
            else if (command == Commands.RENAME_DIR)
            {
                input = input.Trim();
                input = input.Replace("rename -d ", "");
                Path = input;
            }
            else if (command == Commands.RENAME_FILE)
            {
                input = input.Trim();
                input = input.Replace("rename -f ", "");
                Path = input;
            }
            else if (command == Commands.COPY_DIR)
            {
                input = input.Trim();
                input = input.Replace("copy -d ", "");
                Path = input;
            }
            else if (command == Commands.COPY_FILE)
            {
                input = input.Trim();
                input = input.Replace("copy -f ", "");
                Path = input;
            }
            else if (command == Commands.MOVE_DIR)
            {
                input = input.Trim();
                input = input.Replace("move -d ", "");
                Path = input;
            }
            else if (command == Commands.MOVE_FILE)
            {
                input = input.Trim();
                input = input.Replace("move -f ", "");
                Path = input;
            }
            else if (command == Commands.GET_DIR_INFO)
            {
                input = input.Trim();
                input = input.Replace("info -d ", "");
                Path = input;
            }
            else if (command == Commands.GET_FILE_INFO)
            {
                input = input.Trim();
                input = input.Replace("info -f ", "");
                Path = input;
            }
            else if (command == Commands.GET_DRIVE_INFO)
            {
                input = input.Trim();
                input = input.Replace("info -D ", "");
                Path = input;
            }
            else ErrorMessager.Message("Unknown command!");
        } 

        // Меотод проверки существование дирректории в зависимости от указанного пользователем пути.
        public static bool Check(string path, string pathToView)
        {
            if (path.StartsWith("\\"))
            {
                if (Directory.Exists(pathToView + path)) return true;
                else return false;
            }
            else if (path.StartsWith(""))
            {
                if (Directory.Exists(pathToView + "\\" + path)) return true;
                else return false;
            }
            else return false;
        }
        public string Path { get { return _path; } private set { _path = value; } }
    }
}

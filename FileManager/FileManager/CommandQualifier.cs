namespace FileManager
{
    internal static class CommandQualifier 
    {
        // Распознование введнной пользоваетелем команды.
        public static Commands Define(string s)
        {
            if (s.Contains("cd") && !s.Contains("..")) return Commands.SWITCH;
            else if (s.Contains("create -d")) return Commands.CREATE_DIR;
            else if (s.Contains("create -f")) return Commands.CREATE_FILE;
            else if (s.Contains("delete -d")) return Commands.DELETE_DIR;
            else if (s.Contains("delete -f")) return Commands.DELETE_FILE;
            else if (s.Contains("rename -d")) return Commands.RENAME_DIR;
            else if (s.Contains("rename -f")) return Commands.RENAME_FILE;
            else if (s.Contains("copy -d")) return Commands.COPY_DIR;
            else if (s.Contains("copy -f")) return Commands.COPY_FILE;
            else if (s.Contains("move -d")) return Commands.MOVE_DIR;
            else if (s.Contains("move -f")) return Commands.MOVE_FILE;
            else if (s.Contains("info -d")) return Commands.GET_DIR_INFO;
            else if (s.Contains("info -f")) return Commands.GET_FILE_INFO;
            else if (s.Contains("info -D")) return Commands.GET_DRIVE_INFO;
            else if (s.Contains("next -d")) return Commands.NEXT_DIR_PAGE;
            else if (s.Contains("prev -d")) return Commands.PREV_DIR_PAGE;
            else if (s.Contains("next -f")) return Commands.NEXT_FILE_PAGE;
            else if (s.Contains("prev -f")) return Commands.PREV_FILE_PAGE;
            else if (s.Contains("cmd -list")) return Commands.COMMANDS_LIST;
            else if (s.Contains("cd") && s.Contains("..")) return Commands.GO_BACK; 
            else return Commands.UNKNOWN; 
        }
    }
}

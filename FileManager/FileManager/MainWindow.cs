namespace FileManager
{
    // Класс предназначен для разметки окна консоли.
    internal static class MainWindow
    {
        public static void PrintMarkup() // Метод вывода разментки.
        {
            // Создание линий.
            HorizontalLine h_line_up = new(0, Console.WindowWidth - 1, 0, '=');
            HorizontalLine h_line_down = new(0, Console.WindowWidth - 1, Console.WindowHeight - 1, '=');
            HorizontalLine h_line_path_down = new(0, Console.WindowWidth - 1, 2, '=');
            HorizontalLine h_line_before_inform = new(0, Console.WindowWidth - 1, Console.WindowHeight - 8, '=');
            HorizontalLine h_line_after_intorm = new(0, Console.WindowWidth - 1, Console.WindowHeight - 3, '=');
            VerticalLine v_line_center = new((Console.WindowWidth - 1) / 2, 3, Console.WindowHeight - 9, '|');
            VerticalLine v_line_left = new(0, 1, Console.WindowHeight - 2, '|');
            VerticalLine v_line_right = new(Console.WindowWidth - 1, 1, Console.WindowHeight - 2, '|');

            // Отображение линий.
            h_line_up.Draw();
            h_line_down.Draw();
            h_line_path_down.Draw();
            h_line_before_inform.Draw();
            h_line_after_intorm.Draw();
            v_line_center.Draw();
            v_line_left.Draw();
            v_line_right.Draw();
        }
    }
}

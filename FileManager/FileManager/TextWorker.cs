namespace FileManager
{
    internal static class TextWorker
    {
        public static int wordsNumber;
        public static int linesNumber;
        public static int paragraphsNumber;
        public static int spacesNumber;
  
        public static void GetTextInfo(FileInfo file)
        {
            string text = String.Empty; 
            using (StreamReader sr = new StreamReader(file.FullName))
            {
                text = sr.ReadToEnd();
            }
            GetWordsNumber(text);
            GetLinesNumber(text);
            GetParagraphsNumber(text);
            GetSpacesNumber(text);
        }
        private static void GetWordsNumber(string str) 
        {
            string[] words = str.Split(' ');
            wordsNumber = words.Length;
        }
        private static void GetLinesNumber(string str)
        {
            string[] lines = str.Split('\n'); 
            linesNumber = lines.Length;
        }
        private static void GetParagraphsNumber(string str)
        {
            string[] paragraphs = str.Split("\r\n\t"); 
            paragraphsNumber = paragraphs.Length;
        }
        private static void GetSpacesNumber(string str)
        {
            int counter = 0;
            foreach(char c in str)
            {
                if(c == ' ')
                    counter++;
            }
            spacesNumber = counter;
        }
        public static void PrintInfo()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, Console.WindowHeight - 7);
            Console.Write($"Number of words: {TextWorker.wordsNumber}");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, Console.WindowHeight - 6);
            Console.Write($"Number of lines: {TextWorker.linesNumber}");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, Console.WindowHeight - 5);
            Console.Write($"Number of paragraphs: {TextWorker.paragraphsNumber}");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, Console.WindowHeight - 4);
            Console.Write($"Number of spaces: {TextWorker.spacesNumber}");
        }
    }
}

namespace HomeTask_7
{
    internal sealed class Acoder : ICoder
    {
        // Шифрование строки посредством сдвига каждого символа на одну "алфавитную"
        // позицию выше.

        private static int _offset = 1; // Величина сдвига. 
        public string Encode(string input) // Метод кодирования.
        {
            input = input.Trim();
            string result = String.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (Data.NotForChange.Contains(input[i]))
                    result += input[i];
                else
                    result += (char)(input[i] + OffSet);
            }
            return result;
        }
        public string Decode(string input) // Метод декодирования.
        {
            input = input.Trim();
            string result = String.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (Data.NotForChange.Contains(input[i]))
                    result += input[i];
                else
                    result += (char)(input[i] - OffSet);
            }
            return result;
        }
        public static int OffSet { get { return _offset; } set { _offset = value; } }
    }
}

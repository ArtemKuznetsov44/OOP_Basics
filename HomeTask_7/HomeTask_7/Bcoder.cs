namespace HomeTask_7
{
    internal sealed class Bcoder : ICoder
    {
        // Шифрование строки посредством замены каждой буквы, стоящей в алфавите на i-ой
        // позиции, на букву того же регистра, расположенную в алфавите на i-ой позиции
        // с конца алфавита.

        public string Encode(string input) // Метод кодирования.
        {
            int startPosInArray;
            int finalPosInArray;
            string result = String.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (Data.NotForChange.Contains(input[i])) { result += input[i]; }
                else if (Data.EnUpChars.Contains(input[i]))
                {
                    startPosInArray = Array.IndexOf(Data.EnUpChars, input[i]);
                    finalPosInArray = Data.MaxIndexInEnArray - startPosInArray;
                    result += Data.EnUpChars[finalPosInArray];
                }
                else if (Data.EnLowChars.Contains(input[i]))
                {
                    startPosInArray = Array.IndexOf(Data.EnLowChars, input[i]);
                    finalPosInArray = Data.MaxIndexInEnArray - startPosInArray;
                    result += Data.EnLowChars[finalPosInArray];
                }
                else if (Data.RusUpChars.Contains(input[i]))
                {
                    startPosInArray = Array.IndexOf(Data.RusUpChars, input[i]);
                    finalPosInArray = Data.MaxIndexInRussArray - startPosInArray;
                    result += Data.RusUpChars[finalPosInArray];
                }
                else if (Data.RusLowChars.Contains(input[i]))
                {
                    startPosInArray = Array.IndexOf(Data.RusLowChars, input[i]);
                    finalPosInArray = Data.MaxIndexInRussArray - startPosInArray;
                    result += Data.RusLowChars[finalPosInArray];
                }
            }
            return result;
        }
        public string Decode(string input) { return Encode(input); } // Метод декодирования получился полностью идентичным, поэтому решил написать вот так )
    }
}

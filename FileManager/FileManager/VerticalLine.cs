namespace FileManager
{
    internal sealed class VerticalLine : Figure
    {
        public VerticalLine(int x, int yStart, int yEnd, char symbol)
        {
            for (int y = yStart; y <= yEnd; y++)
            {
                Point point = new Point(x, y, symbol);
                pList.Add(point);
            }
        }
    }
}

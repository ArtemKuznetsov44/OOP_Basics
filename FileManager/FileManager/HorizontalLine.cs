namespace FileManager
{
    internal sealed class HorizontalLine : Figure
    {
        public HorizontalLine(int xStart, int xEnd, int y, char symbol)
        {
            for (int x = xStart; x <= xEnd; x++)
            {
                Point point = new Point(x, y, symbol);
                pList.Add(point);
            }
        }
    }
}

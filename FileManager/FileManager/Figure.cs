namespace FileManager
{
    internal class Figure
    {
        protected List<Point> pList = new();
        public void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }
    }
}

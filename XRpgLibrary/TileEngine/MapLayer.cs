namespace XRpgLibrary.TileEngine
{
    public class MapLayer
    {
        private Tile[,] Map { get; }

        public int Width => Map.GetLength(1);

        public int Height => Map.GetLength(0);

        public MapLayer(Tile[,] map)
        {
            Map = (Tile[,])map.Clone();
        }

        public MapLayer(int width, int height)
        {
            Map = new Tile[height, width];

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                    Map[y, x] = new Tile(0, 0);
            }
        }

        public Tile GetTile(int x, int y)
        {
            return Map[y, x];
        }

        public void SetTile(int x, int y, Tile tile)
        {
            Map[y, x] = tile;
        }

        public void SetTile(int x, int y, int tileIndex, int tileset)
        {
            Map[y, x] = new Tile(tileIndex, tileset);
        }
    }
}

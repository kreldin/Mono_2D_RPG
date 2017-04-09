namespace XRpgLibrary.TileEngine
{
    public class Tile
    {
        public int TileIndex { get; }

        public int Tileset { get; }

        public Tile(int tileIndex, int tileset)
        {
            TileIndex = tileIndex;
            Tileset = tileset;
        }
    }
}

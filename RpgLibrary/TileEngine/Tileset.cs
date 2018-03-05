using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RpgLibrary.TileEngine
{
    public class Tileset
    {
        private readonly Rectangle[] _sourceRectangles;

        public Texture2D Texture { get; }

        public int TileWidth { get; }

        public int TileHeight { get; }

        public int TilesWide { get; }

        public int TilesHigh { get; }

        public Rectangle[] SourceRectangles => (Rectangle[]) _sourceRectangles.Clone();

        public Tileset(Texture2D texture, int tilesWide, int tilesHigh, int tileWidth, int tileHeight)
        {
            Texture = texture;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            TilesWide = tilesWide;
            TilesHigh = tilesHigh;

            var tiles = TilesWide * TilesHigh;
            _sourceRectangles = new Rectangle[tiles];

            var tile = 0;

            for (var y = 0; y < TilesHigh; y++)
            {
                for (var x = 0; x < TilesWide; x++)
                {
                    _sourceRectangles[tile] = new Rectangle(
                        x * TileWidth,
                        y * TileHeight,
                        tileWidth,
                        tileHeight);

                    tile++;
                }
            }
        }
    }
}

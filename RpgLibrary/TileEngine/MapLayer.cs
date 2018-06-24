using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RpgLibrary.TileEngine
{
    public class MapLayer : ILayer
    {
        private Tile[,] Layer { get; }

        public int Width => Layer.GetLength(1);

        public int Height => Layer.GetLength(0);

        public MapLayer(Tile[,] map)
        {
            Layer = (Tile[,])map.Clone();
        }

        public MapLayer(int width, int height)
        {
            Layer = new Tile[height, width];

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                    Layer[y, x] = new Tile(0, 0);
            }
        }

        public Tile GetTile(int x, int y)
        {
            return Layer[y, x];
        }

        public void SetTile(int x, int y, Tile tile)
        {
            Layer[y, x] = tile;
        }

        public void SetTile(int x, int y, int tileIndex, int tileset)
        {
            Layer[y, x] = new Tile(tileIndex, tileset);
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, List<Tileset> tilesets)
        {
            var cameraPoint = Engine.VectorToCell(camera.Position * (1 / camera.Zoom));
            var viewPoint = Engine.VectorToCell(
                new Vector2(
                    (camera.Position.X + camera.ViewportRectangle.Width) * (1 / camera.Zoom),
                    (camera.Position.Y + camera.ViewportRectangle.Height) * (1 / camera.Zoom)));

            var min = new Point();
            var max = new Point();

            min.X = MathHelper.Max(0, cameraPoint.X - 1);
            min.Y = MathHelper.Max(0, cameraPoint.Y - 1);
            max.X = MathHelper.Min(viewPoint.X + 1, Width);
            max.Y = MathHelper.Min(viewPoint.Y + 1, Height);

            var destination = new Rectangle(0, 0, Engine.TileWidth, Engine.TileHeight);

            for (var y = min.Y; y < max.Y; ++y)
            {
                destination.Y = y * Engine.TileHeight;

                for (var x = min.X; x < max.X; x++)
                {
                    var tile = GetTile(x, y);

                    if ((tile.TileIndex == -1) || (tile.Tileset == -1)) continue;

                    destination.X = x * Engine.TileWidth;

                    spriteBatch.Draw(
                        tilesets[tile.Tileset].Texture,
                        destination,
                        tilesets[tile.Tileset].SourceRectangles[tile.TileIndex],
                        Color.White);
                }
            }
        }
    }
}

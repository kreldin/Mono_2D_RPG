
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XRpgLibrary.TileEngine
{
    public class TileMap
    {
        private static int MapWidth { get; set; }

        private static int MapHeight { get; set; }

        public static int MapWidthInPixels => MapWidth * Engine.TileWidth;

        public static int MapHeightInPixels => MapHeight * Engine.TileHeight;

        private List<Tileset> Tilesets { get; }

        private List<MapLayer> MapLayers { get; }

        public TileMap(List<Tileset> tilesets, List<MapLayer> layers)
        {
            Tilesets = tilesets;
            MapLayers = layers;

            MapWidth = MapLayers[0].Width;
            MapHeight = MapLayers[0].Height;

            for (var i = 1; i < MapLayers.Count; i++)
            {
                if ((MapWidth != MapLayers[i].Width) || (MapHeight != MapLayers[i].Height))
                    throw new Exception("Map layer size exception");
            }
        }

        public TileMap(Tileset tileset, MapLayer layer)
        {
            Tilesets = new List<Tileset> {tileset};

            MapLayers = new List<MapLayer> {layer};

            MapWidth = MapLayers[0].Width;
            MapHeight = MapLayers[0].Height;
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            var cameraPoint = Engine.VectorToCell(camera.Position * (1f / camera.Zoom));
            var viewPoint = Engine.VectorToCell(new Vector2(
                (camera.Position.X + camera.ViewportRectangle.Width) * (1f / camera.Zoom),
                (camera.Position.Y + camera.ViewportRectangle.Height) * (1f / camera.Zoom)));

            var min = new Point();
            var max = new Point();

            min.X = Math.Max(0, cameraPoint.X - 1);
            min.Y = Math.Max(0, cameraPoint.Y - 1);
            max.X = Math.Min(viewPoint.X + 1, MapWidth);
            max.Y = Math.Min(viewPoint.Y + 1, MapHeight);

            var destination = new Rectangle(
                0,
                0,
                Engine.TileWidth,
                Engine.TileHeight);

            foreach (var layer in MapLayers)
            {
                for (var y = min.Y; y < max.Y; y++)
                {
                    destination.Y = y * Engine.TileHeight;

                    for (var x = min.X; x < max.X; x++)
                    {
                        var tile = layer.GetTile(x, y);

                        if ((tile.TileIndex < 0) || (tile.Tileset < 0))
                            continue;

                        destination.X = x * Engine.TileWidth;

                        spriteBatch.Draw(
                            Tilesets[tile.Tileset].Texture,
                            destination,
                            Tilesets[tile.Tileset].SourceRectangles[tile.TileIndex],
                            Color.White);
                    }
                }
            }
        }

        public void AddLayer(MapLayer layer)
        {
            if ((layer.Width != MapWidth) && (layer.Height != MapHeight))
                throw new Exception("Map layer size exception");

            MapLayers.Add(layer);
        }
    }
}

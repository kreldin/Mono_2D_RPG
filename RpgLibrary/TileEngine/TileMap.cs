
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RpgLibrary.TileEngine
{
    public class TileMap
    {
        private static int MapWidth { get; set; }

        private static int MapHeight { get; set; }

        public static int MapWidthInPixels => MapWidth * Engine.TileWidth;

        public static int MapHeightInPixels => MapHeight * Engine.TileHeight;

        private List<Tileset> Tilesets { get; }

        private List<ILayer> MapLayers { get; }

        public TileMap(List<Tileset> tilesets, MapLayer baseLayer, MapLayer buildingLayer, MapLayer splatterLayer)
        {
            Tilesets = tilesets;
            MapLayers = new List<ILayer> { baseLayer };

            AddLayer(buildingLayer);
            AddLayer(splatterLayer);

            MapWidth = baseLayer.Width;
            MapHeight = baseLayer.Height;
        }

        public TileMap(Tileset tileset, MapLayer baseLayer)
        {
            Tilesets = new List<Tileset> {tileset};

            MapLayers = new List<ILayer> {baseLayer};

            MapWidth = baseLayer.Width;
            MapHeight = baseLayer.Height;
        }

        public void AddLayer(ILayer layer)
        {
            var mapLayer = layer as MapLayer;
            if (mapLayer != null)
            {
                if ((mapLayer.Width != MapWidth) && (mapLayer.Height != MapHeight))
                    throw new Exception("Map layer size exception");
            }
            MapLayers.Add(layer);
        }

        public void AddTileset(Tileset tileset)
        {
            Tilesets.Add(tileset);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var layer in MapLayers)
            {
                layer.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (var layer in MapLayers)
            {
                layer.Draw(spriteBatch, camera, Tilesets);
            }
        }
    }
}

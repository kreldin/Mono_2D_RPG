using Microsoft.Xna.Framework;

namespace RpgLibrary.TileEngine
{
    public static class Engine
    {
        public static int TileWidth { get; } = 32;

        public static int TileHeight { get; }  = 32;

        public static Point VectorToCell(Vector2 position)
        {
            return new Point((int)position.X / TileWidth, (int)position.Y / TileHeight);
        }
    }
}

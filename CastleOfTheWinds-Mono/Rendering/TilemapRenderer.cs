using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleOfTheWinds
{
    /// <summary>
    /// A renderer containing a texture atlas and configuration that can render any tilemap containing
    /// tiles with IDs corresponding to the texture atlas
    /// </summary>
    public class TilemapRenderer
    {
        private Texture2D _textureAtlas;
        private int _tilesPerRow;
        private int _sourceTileSize;
        private int _displayTileSize;

        public TilemapRenderer(Texture2D textureAtlas, int tilesPerRow, int sourceTileSize, int displayTileSize)
        {
            _textureAtlas = textureAtlas;
            _tilesPerRow = tilesPerRow;
            _sourceTileSize = sourceTileSize;
            _displayTileSize = displayTileSize;
        }

        public void Render(SpriteBatch spriteBatch, Tilemap map, Vector2 offset)
        {
            foreach (var tile in map.Tiles)
            {
                Rectangle dest = new Rectangle(
                    (int)tile.Key.X * _displayTileSize + (int)offset.X,
                    (int)tile.Key.Y * _displayTileSize + (int)offset.Y,
                    _displayTileSize,
                    _displayTileSize);
                int x = tile.Value % _tilesPerRow;
                int y = tile.Value / _tilesPerRow;
                Rectangle source = new Rectangle(
                    x * _sourceTileSize,
                    y * _sourceTileSize,
                    _sourceTileSize,
                    _sourceTileSize);

                spriteBatch.Draw(_textureAtlas, dest, source, Color.White);
            }
        }
    }
}

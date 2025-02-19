using CastleOfTheWinds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CastleOfTheWinds
{
    public class GridRenderer
    {
        private readonly Grid grid;
        private readonly GraphicsDevice graphicsDevice;
        private Texture2D cellTexture;
        private Texture2D lineTexture;

        public GridRenderer(Grid grid, GraphicsDevice graphicsDevice)
        {
            this.grid = grid;
            this.graphicsDevice = graphicsDevice;
            Initialize();
        }

        private void Initialize()
        {
            // Create a 1x1 white texture for drawing cells
            cellTexture = new Texture2D(graphicsDevice, 1, 1);
            cellTexture.SetData(new[] { Color.White });

            // Create a 1x1 white texture for drawing grid lines
            lineTexture = new Texture2D(graphicsDevice, 1, 1);
            lineTexture.SetData(new[] { Color.White });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw cells
            for (int x = 0; x < grid.Width; x++)
            {
                for (int y = 0; y < grid.Height; y++)
                {
                    var cell = grid.GetCell(x, y);
                    var position = grid.GetWorldPosition(x, y);
                    var cellSize = grid.CellSize;

                    // Draw cell background
                    spriteBatch.Draw(
                        cellTexture,
                        new Rectangle((int)position.X, (int)position.Y, cellSize - 1, cellSize - 1),
                        Color.AntiqueWhite);
                }
            }

            // Draw grid lines
            for (int x = 0; x <= grid.Width; x++)
            {
                spriteBatch.Draw(
                    lineTexture,
                    new Rectangle(x * grid.CellSize, 0, 1, grid.Height * grid.CellSize),
                    Color.Gray);
            }

            for (int y = 0; y <= grid.Height; y++)
            {
                spriteBatch.Draw(
                    lineTexture,
                    new Rectangle(0, y * grid.CellSize, grid.Width * grid.CellSize, 1),
                    Color.Gray);
            }
        }

        public void Dispose()
        {
            cellTexture?.Dispose();
            lineTexture?.Dispose();
        }
    }
}
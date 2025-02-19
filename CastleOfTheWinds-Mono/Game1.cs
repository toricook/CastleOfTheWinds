using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace CastleOfTheWinds
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Game grid singleton
        private Grid _grid;

        // Custom rendering
        private GridRenderer _gridRenderer;

        // Tilemap stuff
        private Tilemap _tilemap;
        private TilemapRenderer _tilemapRenderer;

        private List<Rectangle> _textureStore;
        private Texture2D _textureAtlas;

        // camera
        private Vector2 _camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


            _tilemap = Tilemap.FromCsv("../../../Data/tiled_test_graphics.csv");

            _camera = Vector2.Zero;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            _grid = new Grid(50, 50, 32);
            _gridRenderer = new GridRenderer(_grid, GraphicsDevice);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            FileStream fileStream = new FileStream("../../../Content/cotw-textureatlas.png", FileMode.Open);
            _textureAtlas = Texture2D.FromStream(GraphicsDevice, fileStream);
            fileStream.Dispose();

            _tilemapRenderer = new TilemapRenderer(_textureAtlas, 4, 32, 32);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _camera.X -= 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                _camera.Y += 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _camera.X += 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _camera.Y -= 5;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _gridRenderer.Draw(_spriteBatch);

            _tilemapRenderer.Render(_spriteBatch, _tilemap, _camera);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            _gridRenderer?.Dispose(); // Only dispose when cleaning up
            base.UnloadContent();
        }
    }
}

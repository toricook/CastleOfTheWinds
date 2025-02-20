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

        private Tilemap _tilemap;
        private TilemapRenderer _tilemapRenderer;

        private Vector2 _viewport;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


            _tilemap = Tilemap.FromCsv("../../../Data/town.csv");
            _viewport = Vector2.Zero;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 480;

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            FileStream fileStream = new FileStream("../../../Content/cotw-tiles-proj.png", FileMode.Open);
            var textures = Texture2D.FromStream(GraphicsDevice, fileStream);
            fileStream.Dispose();

            _tilemapRenderer = new TilemapRenderer(textures, 3, 32, 32);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _viewport.X -= 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                _viewport.Y += 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _viewport.X += 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _viewport.Y -= 5;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _tilemapRenderer.Render(_spriteBatch, _tilemap, _viewport);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
    }
}

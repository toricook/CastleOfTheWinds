using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CastleOfTheWinds
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private TilemapRenderer _tilemapRenderer;

        private Vector2 _viewport;

        private Dictionary<string, Texture2D> _spriteSheets = new();

        Scene _activeScene;
        RenderingSystem _renderingSystem;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _activeScene = new Scene("../../../Data/town.csv", "../../../Data/town_sprites.csv");
            
        }

        public void CreateSprites(string filepath)
        {
            StreamReader sr = new StreamReader(filepath);
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                var texture = _spriteSheets[data[0]];
                var source = new Rectangle(int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]));
                var dest = new Rectangle(int.Parse(data[5]), int.Parse(data[6]), source.Width, source.Height);
                new Sprite(texture, source, dest);

            }
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

            // Create Tilemap Renderer
            var tileTextures = Content.Load<Texture2D>("cotw-tiles-proj");
            _tilemapRenderer = new TilemapRenderer(tileTextures, 3, 32, 32);

            // Load sprite sheets
            var contentFiles = Directory.EnumerateFiles("../../../Content/Spritesheets", "*png");
            foreach ( var contentFile in contentFiles)
            {
                var name = Path.GetFileNameWithoutExtension(contentFile);
                _spriteSheets[name] = Content.Load<Texture2D>(Path.Combine("Spritesheets", name));
            }

            // Load active scene
            _activeScene.Load(_spriteSheets);

            // Create systems
            _renderingSystem = new RenderingSystem();

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

            _spriteBatch.Begin();

            // Render tilemap -- TODO move to system?
            _tilemapRenderer.Render(_spriteBatch, _activeScene.Tilemap, _viewport);

            // System calls
            _renderingSystem.Draw(_spriteBatch, _viewport);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
    }
}

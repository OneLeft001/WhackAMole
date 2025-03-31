using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;


namespace WhackAMole
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private LevelManager _levelManager;

        public Game1()
        {

           _levelManager = LevelManager.Instance;

            

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            _levelManager.initilize(GraphicsDevice);

            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //_levelManager.setHoleTexture(Content.Load<Texture2D>("Hole"));
            _levelManager.loadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Quit();
                Exit();
            }
            fullScreen();

            // TODO: Add your update logic here
            _levelManager.update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGreen);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _levelManager.draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Quit()
        {
            this.Exit();
        }

        private void fullScreen()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.D0))
            {

                _graphics.IsFullScreen = true;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.D9))
            {

                _graphics.IsFullScreen = false;

            }

            _graphics.ApplyChanges();

        }

    }
}

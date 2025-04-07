using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace WhackAMole.Objects
{
    class PlayerHealth
    {

        private Texture2D _hammerTextureOne;
        private Texture2D _hammerTextureTwo;
        private Texture2D _hammerTextureThree;

        private Texture2D[] _hammerTextures;

        private static float screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        private static float screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        public PlayerHealth() { }

        public void loadContent(ContentManager content)
        {

            _hammerTextures = new Texture2D[3];

            for (int i = 0; i < _hammerTextures.Length; i++) {

                _hammerTextures[i] = content.Load<Texture2D>("Hammer");

            }


        }

        public void update(GameTime gameTime)
        {



        }

        public void draw(SpriteBatch spriteBatch)
        {

            if (_hammerTextures != null)
            {
                spriteBatch.Draw(_hammerTextures[0], new Rectangle((int)screenWidth - ((int)screenWidth / 5), ((int)screenHeight / 2) - 400, _hammerTextures[0].Width / 2, _hammerTextures[0].Height / 2), Color.White);
                spriteBatch.Draw(_hammerTextures[1], new Rectangle((int)screenWidth - ((int)screenWidth / 5), ((int)screenHeight / 2) - 200, _hammerTextures[1].Width / 2, _hammerTextures[1].Height / 2), Color.White);
                spriteBatch.Draw(_hammerTextures[2], new Rectangle((int)screenWidth - ((int)screenWidth / 5), ((int)screenHeight / 2), _hammerTextures[2].Width / 2, _hammerTextures[2].Height / 2), Color.White);
            }

        }

    }

}

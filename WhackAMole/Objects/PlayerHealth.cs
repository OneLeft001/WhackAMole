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
        private Rectangle[] _hammerBounds;

        private static float screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        private static float screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        public PlayerHealth() { }

        public void loadContent(ContentManager content)
        {

            _hammerTextures = new Texture2D[3];
            _hammerBounds = new Rectangle[3];

            

            for (int i = 0; i < _hammerTextures.Length; i++) {

                _hammerTextures[i] = content.Load<Texture2D>("Hammer");

            }

            _hammerBounds[0] = new Rectangle((int)screenWidth - ((int)screenWidth / 5), ((int)screenHeight / 2) - 400, _hammerTextures[0].Width / 2, _hammerTextures[0].Height / 2);
            _hammerBounds[1] = new Rectangle((int)screenWidth - ((int)screenWidth / 5), ((int)screenHeight / 2) - 200, _hammerTextures[1].Width / 2, _hammerTextures[1].Height / 2);
            _hammerBounds[2] = new Rectangle((int)screenWidth - ((int)screenWidth / 5), ((int)screenHeight / 2), _hammerTextures[2].Width / 2, _hammerTextures[2].Height / 2);
            

        }

        public void update(GameTime gameTime)
        {



        }

        public void draw(SpriteBatch spriteBatch)
        {

            if (_hammerTextures != null)
            {
                /*spriteBatch.Draw(_hammerTextures[0], new Rectangle((int)screenWidth - ((int)screenWidth / 5), ((int)screenHeight / 2) - 400, _hammerTextures[0].Width / 2, _hammerTextures[0].Height / 2), Color.White);
                spriteBatch.Draw(_hammerTextures[1], new Rectangle((int)screenWidth - ((int)screenWidth / 5), ((int)screenHeight / 2) - 200, _hammerTextures[1].Width / 2, _hammerTextures[1].Height / 2), Color.White);
                spriteBatch.Draw(_hammerTextures[2], new Rectangle((int)screenWidth - ((int)screenWidth / 5), ((int)screenHeight / 2), _hammerTextures[2].Width / 2, _hammerTextures[2].Height / 2), Color.White);
                */
                for (int i = 0; i < _hammerTextures.Length; i++) 
                {

                    spriteBatch.Draw(_hammerTextures[i], _hammerBounds[i], Color.White);

                }

            }

        }

        public void looseHealth()
        {

            _hammerTextures[2] = null;

        }


    }

}

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

        private Texture2D _hammerTexture;

        public PlayerHealth() { }

        public void loadContent(ContentManager content)
        {

            _hammerTexture = content.Load<Texture2D>("Hammer");

        }

        public void update(GameTime gameTime)
        {



        }

        public void draw(SpriteBatch spriteBatch)
        {

            if (_hammerTexture != null)
            {
                spriteBatch.Draw(_hammerTexture, new Vector2(10, 10), Color.White);
            }

        }

    }

}

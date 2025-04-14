using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackAMole.Objects
{
    class Bullet
    {

        private Texture2D _bulletTexture;
        private Rectangle _bulletRectangle;

        private Vector2 _position;

        public Bullet(Texture2D texture) 
        {

            _bulletTexture = texture;
            

        }

        public void update(GameTime gameTime)
        {

            // Needs to damage player when collided with the cursor.
            // And goes back to being inactive in BulletPool.
            // Also become inactive if it goes off screen.

        }

        public void draw(SpriteBatch spriteBatch) 
        {

            if (_bulletTexture != null) 
            {
                _bulletRectangle = new Rectangle((int)_position.X, (int)_position.Y, _bulletTexture.Width, _bulletTexture.Height);

                spriteBatch.Draw(_bulletTexture, _bulletRectangle, Color.White);
                Debug.WriteLine("Bullets are drawing");

            }

        }


    }

}

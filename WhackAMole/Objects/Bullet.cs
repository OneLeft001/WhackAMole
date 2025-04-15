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

        public Vector3 _position { get; set; }

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
                _bulletRectangle = new Rectangle((int)_position.X, (int)_position.Y, _bulletTexture.Width / 2, _bulletTexture.Height / 2);

                spriteBatch.Draw(_bulletTexture, _bulletRectangle, Color.White);
                

            }

        }


    }

}

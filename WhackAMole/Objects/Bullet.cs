using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        private BulletPool _bulletPoolRef;
        

        public Vector3 _position { get; set; }

        public Bullet(Texture2D texture, BulletPool bulletPool) 
        {

            _bulletTexture = texture;
            _bulletPoolRef = bulletPool;
            

        }

        public void update(GameTime gameTime)
        {

            // Needs to damage player when collided with the cursor.
            // And goes back to being inactive in BulletPool.
            // Also become inactive if it goes off screen.
            if (_bulletRectangle.Contains(Mouse.GetState().Position)) {

                _position = new Vector3(1000, 1000, 0);
                //_bulletPoolRef.getBullets().Remove(this); // cannot modify without error in other updates
                //_bulletPoolRef.getBulletsNotInUse().Add(this);
                
            }

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

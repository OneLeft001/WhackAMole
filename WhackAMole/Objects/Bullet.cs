using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackAMole.Managers;

namespace WhackAMole.Objects
{
    class Bullet
    {

        private Texture2D _bulletTexture;
        private Rectangle _bulletRectangle;
        

        private BulletPool _bulletPoolRef;

        public bool IsActive { get; set; }
        private bool _firstActivation = false;

        private Vector2 _cursorPosition;
        
        private float _speed = 15f;

        public Vector2 _position { get; set; }

        public Bullet(Texture2D texture, BulletPool bulletPool) 
        {

            _bulletTexture = texture;
            _bulletPoolRef = bulletPool;
            IsActive = false;

        }

        public void update(GameTime gameTime)
        {

            // Needs to damage player when collided with the cursor.
            // And goes back to being inactive in BulletPool.
            // Also become inactive if it goes off screen.

            if (IsActive && !_firstActivation)
            {

                // get pos of cursor
                // normalize to move towards
                _cursorPosition = Mouse.GetState().Position.ToVector2();
                /*_cursorPosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                Debug.WriteLine("Mouse pos: " + _cursorPosition);

                _cursorPosition.Normalize();
                //_cursorPosition.ToVector2().Normalize();
                Debug.WriteLine("Mouse pos Normalized: " + _cursorPosition);
                */
                _firstActivation = true;

                //var rotation = MathHelper.ToRadians(_cursorPosition.X);
                //_cursorPosition = new((float)Math.Sin(rotation), (float)-Math.Cos(rotation));
                
                
                var toMouse = _cursorPosition - _position;
                var rotation = (float)Math.Atan2(toMouse.X, toMouse.Y);
                _cursorPosition = new((float)Math.Cos(rotation), (float)Math.Sin(rotation));
                
                //_cursorPosition.Normalize();

            }

            if (IsActive && _firstActivation)
            {
                /*
                var toMouse = _cursorPosition - _position;
                var rotation = (float)Math.Atan2(toMouse.X, toMouse.Y);
                _cursorPosition = new((float)Math.Sin(rotation), (float)-Math.Cos(rotation));
                */


                //_cursorPosition.Normalize();
                _position += _cursorPosition * _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                /*_cursorPosition.Normalize();

                if (_position.X < _cursorPosition.X)
                {
                    _position += _cursorPosition * (float)gameTime.ElapsedGameTime.TotalSeconds * _speed;
                }
                else
                {
                    _position -= _cursorPosition * (float)gameTime.ElapsedGameTime.TotalSeconds * _speed;
                }
                */

            }

            if (_bulletRectangle.Contains(Mouse.GetState().Position)) {

                _position = new Vector2(1000, 1000);
                IsActive = false;
                _firstActivation = false;
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

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
        
        private float _speed = 18f;
        private Vector2 _direction;
        private Vector2 _spawnPosition;

        public Vector2 Position { get; set; }

        public Bullet(Texture2D texture, BulletPool bulletPool) 
        {

            _bulletTexture = texture;
            _bulletPoolRef = bulletPool;
            IsActive = false;

        }

        public void update(GameTime gameTime)
        {

            if (IsActive && !_firstActivation)
            {

                _cursorPosition = Mouse.GetState().Position.ToVector2();
                _spawnPosition = Position;
                Vector2 movement = _cursorPosition - _spawnPosition;
                movement.Normalize();
                _direction = movement;


                _firstActivation = true;


            }

            if (IsActive && _firstActivation)
            {
                
                Position += _direction * _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                

            }

            if (_bulletRectangle.Contains(Mouse.GetState().Position)) {

                Position = new Vector2(1000, 1000);
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

                _bulletRectangle = new Rectangle((int)Position.X, (int)Position.Y, _bulletTexture.Width / 2, _bulletTexture.Height / 2);

                spriteBatch.Draw(_bulletTexture, _bulletRectangle, Color.White);


            }

        }


    }

}

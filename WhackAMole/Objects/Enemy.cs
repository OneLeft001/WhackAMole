using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using WhackAMole.Managers;

namespace WhackAMole
{
    class Enemy
    {

        private MouseState mouseState;
        //private bool mouseReleased = true;

        protected virtual Texture2D _sprite {  get; set; }
        private Vector2 _position;
        public Rectangle _rectangle { get { return new Rectangle((int)_position.X, (int)_position.Y, _sprite.Width / 2, _sprite.Height / 2); } }

        public virtual bool IsHarmfull { get { return false; } }


        public Enemy(Texture2D texture) {
            
            _sprite = texture;
            _position = new Vector2(200, 200);

        }

        
        GameTime _gameTimeRef;
        int counter = 0;
        //float _waitTime = 3f; // wait X seconds, but needs to be random (X, X); seconds
        float _timer = 0f;
        public bool _isInUse { get; set; }
        
        
        public virtual void update(GameTime gameTime) 
        {


            if (counter == 0) { // note this needs to be method for when enemy becomes active

                //_timer = (float)gameTime.TotalGameTime.TotalSeconds + _waitTime;
                counter = 2;
                
            }

            //Debug.WriteLine("GameTime: " + (float)gameTime.TotalGameTime.TotalSeconds + ", GameCounter: " + _timer);

            if (gameTime.TotalGameTime.TotalSeconds >= _timer) 
            {

                //Debug.WriteLine("Buzzz");
                _isInUse = false;

            }
            
            _gameTimeRef = gameTime;
            

        }

        public virtual void draw(SpriteBatch spriteBatch) 
        {
        
            

            if(_sprite != null )
            {

                spriteBatch.Draw(_sprite, _rectangle, Color.White);
                

            }

            // Note - if enemy sprite behavior needs to change
            // based on enemies eternal timer then this
            // should be its own method!
            if(_gameTimeRef != null && _gameTimeRef.TotalGameTime.TotalSeconds >= _timer && _timer > 0)
            {
                spriteBatch.Draw(_sprite, _rectangle, Color.Black);
            }


        }

        public void setPosition(Vector2 position)
        {

            _position = position;

        }

        public void SetTimer(GameTime gameTime, float extraTime)
        {

            var rand = new Random();

            int waitTime = rand.Next(1, 3);

            _timer = (float)gameTime.TotalGameTime.TotalSeconds + (float)waitTime + (float)extraTime;

        }
        public float GetTimer() {  return _timer; }
       


    }
}

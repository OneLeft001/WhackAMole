using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackAMole.Managers;

namespace WhackAMole
{
    class Enemy
    {

        private MouseState mouseState;
        //private bool mouseReleased = true;

        private Texture2D _sprite;
        private Vector2 _position;
        public Rectangle _rectangle { get { return new Rectangle((int)_position.X, (int)_position.Y, _sprite.Width / 2, _sprite.Height / 2); } }

        public virtual bool IsHarmfull { get { return false; } }


        public Enemy(Texture2D texture) {
            
            _sprite = texture;
            _position = new Vector2(200, 200);

        }

        public void update(GameTime gameTime) 
        {

            updateAbstractClass(gameTime);

        }

        public void draw(SpriteBatch spriteBatch) 
        {
        
            if(_sprite != null)
            {

                spriteBatch.Draw(_sprite, _rectangle, Color.White);
                

            }

        }

        public void setPosition(Vector2 position)
        {

            _position = position;

        }

        public virtual void updateAbstractClass(GameTime gameTime) { }
       


    }
}

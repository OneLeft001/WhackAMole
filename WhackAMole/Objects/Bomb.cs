using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WhackAMole.ObjectPools;

namespace WhackAMole
{
    class Bomb : Enemy
    {

        //private Texture2D _sprite;
        public override bool IsHarmfull { get { return true; } }

        public bool IsClicked { set { value = false; } }

        public Bomb(Texture2D texture) : base(texture)
        {

            //_sprite = texture;
            _sprite = EnemyPool.ExplosionTexture;

        }

        public override void updateAbstractClass(GameTime gameTime)
        {

            if (this._rectangle.Contains(Mouse.GetState().Position)) 
            {

                //Debug.WriteLine("HOvering over bomb!!");

            }

            base.updateAbstractClass(gameTime);
        }

        public override void draw(SpriteBatch spriteBatch)
        {

            

            spriteBatch.Draw(_sprite, this._rectangle, Color.White);

            base.draw(spriteBatch);

        }


    }



}

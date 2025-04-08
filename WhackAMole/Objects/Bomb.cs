using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WhackAMole
{
    class Bomb : Enemy
    {

        //private Texture2D _sprite;
        public override bool IsHarmfull { get { return true; } }

        public Bomb(Texture2D texture) : base(texture)
        {

            //_sprite = texture;

        }

        public override void updateAbstractClass(GameTime gameTime)
        {

            if (this._rectangle.Contains(Mouse.GetState().Position)) 
            {

                //Debug.WriteLine("HOvering over bomb!!");

            }

            base.updateAbstractClass(gameTime);
        }


    }



}

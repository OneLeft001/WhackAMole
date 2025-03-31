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

namespace WhackAMole
{
    class Mole : Enemy
    {

        //private Texture2D _sprite;

        public Mole(Texture2D texture) : base(texture)
        {

            //_sprite = texture;

        }


    }

    class Bomb : Enemy
    {

        //private Texture2D _sprite;

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

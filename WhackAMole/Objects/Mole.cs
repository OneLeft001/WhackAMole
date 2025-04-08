using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
        public override bool IsHarmfull {  get { return false; } }

        public Mole(Texture2D texture) : base(texture)
        {

            //_sprite = texture;

        }


    }



}

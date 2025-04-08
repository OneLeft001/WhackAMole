using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WhackAMole
{
    class RangerMole : Enemy
    {

        public override bool IsHarmfull { get { return false; } }

        public RangerMole(Texture2D texture) : base(texture) { }

        public override void updateAbstractClass(GameTime gameTime)
        {

            base.updateAbstractClass(gameTime);

        }

    }



}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WhackAMole
{
    class RangerMole : Enemy
    {

        public override bool IsHarmfull { get { return false; } }

        public RangerMole(Texture2D texture) : base(texture) { }

        public override void update(GameTime gameTime)
        {

            // Needs to shoot given a random time.
            // But also needs to be a time before this mole despawns
            // So random time of shooting in between time of spawning in - to time of despawning


            base.update(gameTime);
        }

        

    }



}

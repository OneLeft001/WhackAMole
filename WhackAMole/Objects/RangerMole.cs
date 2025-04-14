using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WhackAMole
{
    class RangerMole : Enemy
    {

        private BulletPool _bulletPoolReference;

        public override bool IsHarmfull { get { return false; } }

        public RangerMole(Texture2D texture, BulletPool _bulletPool) : base(texture) {
        
            _bulletPoolReference = _bulletPool;

        }

        int count = 0;
        public override void update(GameTime gameTime)
        {

            // Needs to shoot given a random time.
            // But also needs to be a time before this mole despawns
            // So random time of shooting in between time of spawning in - to time of despawning

            if (count == 0 && _bulletPoolReference != null && _bulletPoolReference.getBulletsNotInUse().Count > 0)
            {


                var bullet = _bulletPoolReference.getBulletsNotInUse()[0];
                

            }


            base.update(gameTime);
        }

        

    }



}

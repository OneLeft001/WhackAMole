using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WhackAMole.Objects;

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
        private Bullet _bulletInUse;
        public override void update(GameTime gameTime)
        {

            // Needs to shoot given a random time.
            // But also needs to be a time before this mole despawns
            // So random time of shooting in between time of spawning in - to time of despawning

            if (count == 0 && _bulletPoolReference != null && _bulletPoolReference.getBulletsNotInUse().Count > 0)
            {


                _bulletInUse = _bulletPoolReference.getBulletsNotInUse()[0];
                _bulletPoolReference.getBulletsNotInUse().Remove(_bulletInUse);
                _bulletPoolReference.getBullets().Add(_bulletInUse);
                _bulletInUse._position = new Vector3(this._rectangle.X, this._rectangle.Y, 2);
                count = 1;
                

            }


            base.update(gameTime);
        }

        /*
        public override void draw(SpriteBatch spriteBatch)
        {

            if(_bulletPoolReference != null && _bulletInUse != null)
            {
                
                //_bulletInUse._position = new Vector3(this._rectangle.X, this._rectangle.Y, 2);//this._rectangle.Location.ToVector2();
                _bulletInUse.draw(spriteBatch);
                spriteBatch.Draw(this._sprite, this._rectangle, Color.White);
            }

            base.draw(spriteBatch);
        }*/

    }



}

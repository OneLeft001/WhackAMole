using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using WhackAMole.Objects;

namespace WhackAMole
{
    class RangerMole : Enemy
    {

        private BulletPool _bulletPoolReference;

        private Random _random;
        private float _pullBulletAtTime = 0;
        private int count = 0;
        private float _timer = 0;
        private Bullet _bulletInUse;
        public override bool IsHarmfull { get { return false; } }


        public RangerMole(Texture2D texture, BulletPool _bulletPool) : base(texture) {
        
            _bulletPoolReference = _bulletPool;

        }

        
        public override void update(GameTime gameTime)
        {

            // Needs to shoot given a random time.
            // But also needs to be a time before this mole despawns
            // So random time of shooting in between time of spawning in - to time of despawning

            if (count == 0 && _bulletPoolReference != null && _bulletPoolReference.getBulletsNotInUse().Count > 0)
            {
                _random = new Random();
                _pullBulletAtTime = _random.Next((int)_timer, (int)(_timer + (float)gameTime.TotalGameTime.TotalSeconds) - 1);

                /*_bulletInUse = _bulletPoolReference.getBulletsNotInUse()[0];
                _bulletPoolReference.getBulletsNotInUse().Remove(_bulletInUse);
                _bulletPoolReference.getBullets().Add(_bulletInUse);
                _bulletInUse._position = new Vector3(this._rectangle.X, this._rectangle.Y, 2); */
                count = 1;
                

            }

            if(gameTime.TotalGameTime.TotalSeconds >= _pullBulletAtTime && count == 1 && _bulletPoolReference != null)
            {

                _bulletInUse = _bulletPoolReference.getBulletsNotInUse()[0];
                _bulletPoolReference.getBulletsNotInUse().Remove(_bulletInUse);
                _bulletPoolReference.getBullets().Add(_bulletInUse);
                _bulletInUse._position = new Vector3(this._rectangle.X, this._rectangle.Y, 2);

                count = 2;

            }

            if (gameTime.TotalGameTime.TotalSeconds >= _timer)
            {

                //Debug.WriteLine("Buzzz");
                _isInUse = false;

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

       /* public override void SetTimer(GameTime gameTime, float extraTime)
        {

            var rand = new Random();

            int waitTime = rand.Next(1, 3);

            _timer = (float)gameTime.TotalGameTime.TotalSeconds + (float)waitTime + (float)extraTime;

        }*/

    }



}

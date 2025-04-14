using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using WhackAMole.Objects;

namespace WhackAMole
{
    class BulletPool
    {

        private Texture2D _bulletTexture;
        private List<Bullet> _bulletsNotInUse;
        private List<Bullet> _bulletsInUse;
        private int _bulletCount = 10;

        public void initilize()
        {

            _bulletsInUse = new List<Bullet>();
            _bulletsNotInUse = new List<Bullet>();

            
            for (int i = 0; i < _bulletCount; i++) 
            {
                _bulletsNotInUse.Add(new Bullet(_bulletTexture));
            }

        }

        public void loadContent(ContentManager content) 
        {

            _bulletTexture = content.Load<Texture2D>("Pellet");

        }

        public List <Bullet> getBulletsNotInUse() { return _bulletsNotInUse; }
        public List<Bullet> getBullets() { return _bulletsInUse; }

    }

}

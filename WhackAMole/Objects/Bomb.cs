using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Windows.Markup;
using WhackAMole.ObjectPools;

namespace WhackAMole
{
    class Bomb : Enemy
    {

        //private Texture2D _sprite;
        public override bool IsHarmfull { get { return true; } }

        public bool IsClicked { get; set; }

        public Bomb(Texture2D texture) : base(texture)
        {

            _sprite = texture;
            

        }

        public override void update(GameTime gameTime)
        {

            if (IsClicked)
            {
                this._sprite = EnemyPool.ExplosionTexture;
            }

            
            base.update(gameTime);
        }
       

        public override void draw(SpriteBatch spriteBatch)
        {
            // NOTE - INSTEAD OF SWITCHING GRAPHIC TO EXPLOSION, WHEN CLICKED JUST GRAB THE GRAPHIC FROM
            // ITS OWN GRAPHIC POOL AND SET THE POSITION AND SET ITS OWN TIMER!!!
            if (IsClicked)
            {
                _sprite = EnemyPool.ExplosionTexture;
                spriteBatch.Draw(this._sprite, this._rectangle, Color.White);

            }

            base.draw(spriteBatch);

        }


    }



}

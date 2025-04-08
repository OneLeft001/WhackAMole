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
            //_sprite = EnemyPool.ExplosionTexture; -> worked here before?

        }

        public override void updateAbstractClass(GameTime gameTime)
        {

            if (IsClicked)
            {
                this._sprite = EnemyPool.ExplosionTexture;
            }

            base.updateAbstractClass(gameTime);
        }

        public override void draw(SpriteBatch spriteBatch)
        {

            if (IsClicked)
            {
                _sprite = EnemyPool.ExplosionTexture;
                spriteBatch.Draw(this._sprite, this._rectangle, Color.White);

            }

            base.draw(spriteBatch);

        }


    }



}

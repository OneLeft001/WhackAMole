using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackAMole.ObjectPools;

namespace WhackAMole
{
    class Hole
    {
        private Texture2D _hole;
        private Vector2 _position;

        private bool _placementPending = false;
        private bool _isInUse = false;

        public Texture2D _rectangleTexture;
        public bool showRectangle {  get; set; }


        // References to existing objects
        private HolePool _holePoolRef;
        private EnemyPool _enemyPoolRef;
        private Enemy _currentEnemyRef;

        private static int countTime = 310;
        private int largeCountTime = 400;
        private int counter = countTime;


        public Rectangle _rectangle // NOTE; maybe intersection is not working bc getting the rectangle is always making a new rect
        {
            get { return new Rectangle((int)_position.X, (int)_position.Y, _hole.Width / 2, _hole.Height / 2); }
        }


        public void loadContent(ContentManager content)
        {


            // TODO: use this.Content to load your game content here
            _hole = content.Load<Texture2D>("Hole");
            //_hole = GlobalContentManager.Instance.getContentManager().Load<Texture2D>("Hole");

            

        }


        public void update(GameTime gameTime)
        {

            if (_isInUse)
            {

                counter--;

            }

            if (_isInUse && counter <=0)
            {

                _enemyPoolRef.getActiveEnemies().Remove(_currentEnemyRef);
                _enemyPoolRef.getInactiveEnemies().Add(_currentEnemyRef);


                var rand = new Random();

                counter = rand.Next(countTime, largeCountTime);
                _isInUse = false;
                
            }


        }

        public void draw(SpriteBatch spriteBatch) 
        {

            if (_hole != null)
            {
                //spriteBatch.Draw(_hole, new Rectangle((int)_position.X, (int)_position.Y, _hole.Width / 2, _hole.Height / 2), Color.White);
                spriteBatch.Draw(_hole, _rectangle, Color.White);

            }
            

        }

        public void setPosition(Vector2 position) 
        {
        
            _position = position;

        }

        public void setPlacementPending(bool pending)
        {
            _placementPending = pending;
        }

        public Vector2 getPosition() { return _position; }

        public bool getPlacementPending()
        {
            return _placementPending;
        }

        public Texture2D getTexture()
        {
            return _hole;
        }


        public bool getIsInUse()
        {

            return _isInUse;

        }

        public void setIsInUse(bool isInUse)
        {
            _isInUse = isInUse;
        }

        public void getUsedPoolsAndMole(HolePool holePool, EnemyPool enemyPool, Enemy enemy)
        {

            _holePoolRef = holePool;
            _enemyPoolRef = enemyPool;
            _currentEnemyRef = enemy;

        }


    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WhackAMole.ObjectPools;
using WhackAMole.Objects;
namespace WhackAMole
{
    class LevelManager
    {

        private static readonly Lazy<LevelManager> _levelManager = new Lazy<LevelManager>(() => new LevelManager());

        private LevelManager() {  }

        public static LevelManager Instance => _levelManager.Value;


        private MouseState _mouseState;
        private Rectangle _mouseRectangle = new Rectangle(Mouse.GetState().Position.X, Mouse.GetState().Position.Y, 5, 5);
        private bool _mouseReleased = true;
        
        private EnemyPool _enemyPool;
        private HolePool _holePool;
        private PlayerHealth _playerHealth;

        private Texture2D _spawnArea;
        private static float screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        private static float screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        private static float spawnAreaWidth = 1000f;
        private static float spawnAreaHeight = 800f;
        private float spawnAreaPositionX = (screenWidth / 2) - (spawnAreaWidth / 2);
        private float spawnAreaPositionY = (screenHeight / 2) - (spawnAreaHeight /2);

        private SpriteFont _font;
        private int _playerScore  = 0;

        private bool holesPlaced = false;
        private float _extraEnemySpawnTime = 0;



        public void initilize(GraphicsDevice graphics)
        {

            _enemyPool = new EnemyPool();
            _enemyPool.DifficultyLevel = 0;

            _playerHealth = new PlayerHealth();

            //holes = new List<Hole>();
            _spawnArea = new Texture2D(graphics, 1, 1);
            _spawnArea.SetData(new Color[] { Color.LightGreen });

            _holePool = new HolePool();
            _holePool.initilize();

            

            

            //holes.Add(new Hole());


        }


        public void loadContent(ContentManager content)
        {

            _font = content.Load<SpriteFont>("Fonts/gameFont");

            _playerHealth.loadContent(content);
            

            foreach (Hole hole in _holePool.getHolesNotPlaced()) 
            {
            
                hole.loadContent(content);

            }

            for (int i = 0; i < _holePool.getHolesNotPlaced().Count; i++) { }

            _enemyPool.loadContent(content);

            
            

        }


        float _waitTime = 3f; // wait X seconds, but needs to be random (X, X); seconds
        float _timer = 0f;
        public void update(GameTime gameTime)
        {

            _mouseState = Mouse.GetState();
            

            if (!holesPlaced)
            {

                placeHoles();

                holesPlaced = true;

            }

            

            foreach(Hole hole in _holePool.getHolesNotPlaced()) { hole.update(gameTime); }
            foreach (Hole hole in _holePool.getPlacedHoles()) { hole.update(gameTime); }

            if (_enemyPool.getActiveEnemies() != null)
            {
                foreach (Enemy enemy in _enemyPool.getActiveEnemies()) { enemy.update(gameTime); }
            }


            // Limmit amount of enemies on screen.
            // This also needs to be nested withing a timer similar to the enemy/hole timers.

            if (gameTime.TotalGameTime.TotalSeconds >= _timer)// timer is up
            {

                if (_enemyPool.getActiveEnemies().Count < 6)
                {
                    // NOTE - THIS IS LIKELY THE ISSUE!!!
                    // I believe this doesn't currently work. Because the hole/enemy associated with the hole
                    // Gets placed, therefor the timer gets set. Before all the other holes/enemies get activated.
                    // Therefor a while or do-While loops cannot work. Because the timers end before all enemies can
                    // be placed at once.
                    for (int i = 0; i < 6; i++)
                    {
                        placeEnemy();
                    }
                    _extraEnemySpawnTime = 0;
                    

                }
                

                _timer = (float)gameTime.TotalGameTime.TotalSeconds + _waitTime;

            }
            

            // Enemy Cursor Collsion
            ClickEnemy(gameTime);


            // Check player score for difficulty increase
            // Easy: 0-10, Medium: 10-25, Hard: 25+
            // When a threshold is met, EnemyPool must hold more threatening enemies
            // This implies that the pool will need to be cleared & new instances of enemies created
            increaseDifficulty();
            _enemyPool.update(gameTime);


        }

        public void draw(SpriteBatch spriteBatch)
        {

            
            spriteBatch.Draw(_spawnArea, new Rectangle((int)spawnAreaPositionX, (int)spawnAreaPositionY,(int)spawnAreaWidth,(int)spawnAreaHeight), Color.White);


            foreach (Hole hole in _holePool.getHolesNotPlaced()) 
            {
                hole.draw(spriteBatch);
            }

            foreach (Hole hole in _holePool.getPlacedHoles())
            {
                hole.draw(spriteBatch);
            }

            if (_enemyPool.getActiveEnemies() != null)
            {

                foreach (Enemy enemy in _enemyPool.getActiveEnemies())
                {
                    enemy.draw(spriteBatch);
                }
            }

            if(_enemyPool.GetBulletPool() != null)
            {

                foreach(Bullet bullet in _enemyPool.GetBulletPool().getBulletsNotInUse())
                {

                    bullet.draw(spriteBatch);

                }

            }

            _playerHealth.draw(spriteBatch);

            spriteBatch.DrawString(_font, "Score: " + _playerScore, new Vector2(screenWidth / 2, 70), Color.GhostWhite);

        }


        private void placeHoles()
        {

            var rand = new Random();
            int holseNotPlacedNum = _holePool.getHolesNotPlaced().Count;
            int placedHoles = _holePool.getPlacedHoles().Count;


            do
            {

                if(_holePool.getHolesNotPlaced() != null)
                {


                    var hole = _holePool.getHolesNotPlaced()[0];

                    /*
                    float holeOffsetWidth = hole.getTexture().Width / 2;
                    float holeOffsetHeight = hole.getTexture().Height / 2;


                    Vector2 min = new Vector2((spawnAreaPositionX + spawnAreaWidth) - holeOffsetWidth, (spawnAreaPositionY + spawnAreaHeight) - holeOffsetHeight);
                    Vector2 max = new Vector2(spawnAreaPositionX + spawnAreaWidth - holeOffsetWidth, (spawnAreaPositionY + spawnAreaHeight) - holeOffsetHeight);



                    float x = rand.Next((int)(spawnAreaPositionX), (int)(max.X));
                    float y = rand.Next((int)(spawnAreaPositionY), (int)(max.Y));
                    */



                    //Vector2 newPos = new Vector2(x, y);
                    Vector2 newPos = generateNewPosition(hole, rand);


                    //hole.setPosition(newPos);
                    hole.setPosition(newPos);

                    hole.setPlacementPending(true);



                    if (_holePool.getPlacedHoles().Count <= 0)
                    {

                        _holePool.getHolesNotPlaced().Remove(hole);
                        _holePool.getPlacedHoles().Add(hole);

                    }
                    else
                    {

                        bool isCollide = true;
                        bool absolutelyCollided = false;

                        while (isCollide)
                        {

                            foreach (Hole placedHole in _holePool.getPlacedHoles())
                            {


                                if (hole._rectangle.Intersects(placedHole._rectangle))
                                {

                                    isCollide = true;
                                    absolutelyCollided = true;
                                    break;
                                    

                                }
                                

                            }

                            if (absolutelyCollided == false)
                            {

                                _holePool.getHolesNotPlaced().Remove(hole);
                                _holePool.getPlacedHoles().Add(hole);
                                hole.setPosition(newPos);

                                isCollide = false;

                                

                            }
                            if(absolutelyCollided)
                            {

                                //x = rand.Next((int)(spawnAreaPositionX), (int)(max.X));
                                //y = rand.Next((int)(spawnAreaPositionY), (int)(max.Y));



                                //newPos = new Vector2(x, y);
                                newPos = generateNewPosition(hole, rand);
                                hole.setPosition(newPos);

                                isCollide=false;

                            }


                        }
                        
                    }


                }

            } while (_holePool.getHolesNotPlaced().Count > 0);
            Debug.WriteLine("Placement Loop Completed");
            
            

        }

        private Vector2 generateNewPosition(Hole hole, Random rand)
        {

            float holeOffsetWidth = hole.getTexture().Width / 2;
            float holeOffsetHeight = hole.getTexture().Height / 2;


            Vector2 min = new Vector2((spawnAreaPositionX + spawnAreaWidth) - holeOffsetWidth, (spawnAreaPositionY + spawnAreaHeight) - holeOffsetHeight);
            Vector2 max = new Vector2(spawnAreaPositionX + spawnAreaWidth - holeOffsetWidth, (spawnAreaPositionY + spawnAreaHeight) - holeOffsetHeight);



            float x = rand.Next((int)(spawnAreaPositionX), (int)(max.X));
            float y = rand.Next((int)(spawnAreaPositionY), (int)(max.Y));

            return new Vector2(x, y);

        }


        // NOTE - THIS NEEDS TO BE REFACTORED TO FIX
        // - enemy placement
        // - checking what holes and what enemies are active/inactive
        // - does not determine enemy behaviour or life cycle
        
        
        private void placeEnemy() 
        {

            // Needs to be a loop until a maximum number of enemies has been spawned
            
            // pic one of each:

            // need random index for active holes, give holes a bool for this
            var rand = new Random();
            var randHole = rand.Next(0, _holePool.getPlacedHoles().Count);
            //_holePool.getPlacedHoles()[randHole].getIsInUse();

            // if true then get another hole, or maybe don't get anything this frame?

            for (int i = 0; i < 10; i++)
            {

                if (_holePool.getPlacedHoles()[randHole].getIsInUse())
                {

                    randHole = rand.Next(0, _holePool.getPlacedHoles().Count);

                }
                else { break; }
            }


            // need random index for inactive enemies, flip active/inactive lists for this
            var randEnemy = rand.Next(0, _enemyPool.getInactiveEnemies().Count);

            if (randEnemy >= 1 && _holePool.getPlacedHoles()[randHole].getIsInUse() == false)
            {

                var enemy = _enemyPool.getInactiveEnemies()[randEnemy];
                var hole = _holePool.getPlacedHoles()[randHole];

                enemy.setPosition(hole.getPosition());

                // change from is not used, to in use
                hole.setIsInUse(true);
                _enemyPool.getInactiveEnemies().Remove(enemy);
                _enemyPool.getActiveEnemies().Add(enemy);

                _extraEnemySpawnTime += 0.2f;
                // Pass values to set a is in use timer
                hole.getUsedPoolsAndMole(_holePool, _enemyPool, enemy, _extraEnemySpawnTime);

            }


        }


        private void ClickEnemy(GameTime gameTime)
        {

            if (_mouseReleased == true)
            {
                foreach (Enemy enemy in _enemyPool.getActiveEnemies())
                {

                    _mouseRectangle = new Rectangle(_mouseState.X, _mouseState.Y, 5, 5);

                    // Enemy dies
                    if (_mouseRectangle.Intersects(enemy._rectangle) && _mouseState.LeftButton == ButtonState.Pressed && _mouseReleased == true)
                    {
                        

                        

                        _mouseReleased = false;

                        


                        // If enemy can damage player, takeaway player's health -1
                        // Invoke specific enemy class death behaviuour
                        if (enemy.IsHarmfull)
                        {

                            if(enemy is Bomb)
                            {

                                Bomb bomb = (Bomb)enemy;
                                bomb.IsClicked = true;
                                bomb.SetTimer(gameTime, 0.3f);

                            }
                            


                            
                            _playerHealth.looseHealth();

                        }
                        else
                        {

                            _playerScore += 1;


                        }
                        enemy.setPosition(new Vector2(1000, 1000));


                    }


                    if (_mouseState.LeftButton == ButtonState.Released)
                    {

                        _mouseReleased = true;

                    }

                }
            }

            if (_mouseState.LeftButton == ButtonState.Pressed)
            {

                _mouseReleased = false;

            }

            if (_mouseState.LeftButton == ButtonState.Released)
            {

                _mouseReleased = true;

            }

        }
       

        private void increaseDifficulty()
        {

            if (_playerScore > 10 && _playerScore < 25 && _enemyPool.DifficultyLevel == 0) // Medium difficulty
            {

                // Change Enemy Pool to have more bomb enemies
                // Increse _difficultyNum to 1

                _enemyPool.DifficultyLevel = 1;

            }
            else if (_playerScore > 25 && _enemyPool.DifficultyLevel == 1) // Hard difficulty
            {

                // Change Enemy Pool to hold Ranger Moles
                // Increase _difficultyNum to 2

                _enemyPool.DifficultyLevel = 2;

            }
            else // other
            {

            }

        }


    }
}

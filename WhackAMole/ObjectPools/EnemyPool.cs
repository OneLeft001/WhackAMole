using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackAMole.Objects;

namespace WhackAMole.ObjectPools
{
    class EnemyPool
    {


        private Texture2D _moleTexture;
        private Texture2D _bombTexture;
        private Texture2D _rangerMoleTexture;
        

        private List<Enemy> inactiveEnemies;
        private List<Enemy> activeEnemies;

        private int numberOfEnemies = 7;
        public int DifficultyLevel { get; set; }
        private int _previousDifficulty = -1;

        enum levelDifficultyIndex
        {
            easyLevel = 0,
            mediumLevel = 1,
            hardLevel = 2,
            
        }
       

        private void initilize() 
        {

            

            inactiveEnemies = new List<Enemy>();
            activeEnemies = new List<Enemy>();

            /*for (int i = 0; i < numberOfEnemies; i++) 
            {
                inactiveEnemies.Add(new Mole(_moleTexture));
                //inactiveEnemies.Add(new Bomb(_bombTexture));
                //inactiveEnemies.Add(new Enemy(_moleTexture));
                //inactiveEnemies.Add(new Enemy(_bombTexture));
                //inactiveEnemies.Add(new Enemy(_rangerMoleTexture));

            }*/

            initilizeEnemies();

        }

        public void loadContent(ContentManager content)
        {

            _moleTexture = content.Load<Texture2D>("Mole");
            _bombTexture = content.Load<Texture2D>("Enemy");
            _rangerMoleTexture = content.Load<Texture2D>("RangerMole");

            DifficultyLevel = 0;
            //_previousDifficulty = 0;
            initilize();

        }

        public void update(GameTime gameTime)
        {

            initilizeEnemies(); // Left off here, problem, the enemies all get deleted but not created again?
            // I suspect the issue is that initilize is constantly being called, so the enemeis area always being deleted.
            // Potental solution is to have a flag to switch levels on/off

        }

        public List<Enemy> getActiveEnemies() {  return activeEnemies; }
        public List<Enemy> getInactiveEnemies() { return inactiveEnemies; }



        private void initilizeEnemies()
        {
            //LevelDifficultyData.easyLevelData
            //Debug.WriteLine("This is the easy type: " + testEasy);

            if (DifficultyLevel != _previousDifficulty)
            {

                _previousDifficulty = DifficultyLevel;

                switch (DifficultyLevel)
                {

                    case (int)levelDifficultyIndex.easyLevel:// Starting level

                        //cycleEnemyInstanciation((int)levelDifficultyIndex.easyLevel);
                        foreach (var (enemyType, numberOfEnemies) in LevelDifficultyData.easyLevelData)
                        {

                            for (int i = 0; i < numberOfEnemies; i++)
                            {

                                instantiateEnemyType(enemyType);

                            }

                        }

                        break;
                    case (int)levelDifficultyIndex.mediumLevel:// Level Increase 1
                        clearEnemiesLists();
                        //cycleEnemyInstanciation();
                        foreach (var (enemyType, numberOfEnemies) in LevelDifficultyData.mediumLevelData)
                        {

                            for (int i = 0; i < numberOfEnemies; i++)
                            {

                                instantiateEnemyType(enemyType);

                            }

                        }
                        break;
                    case (int)levelDifficultyIndex.hardLevel:// Level Increase 2
                        foreach (var (enemyType, numberOfEnemies) in LevelDifficultyData.hardLevelData)
                        {

                            for (int i = 0; i < numberOfEnemies; i++)
                            {

                                instantiateEnemyType(enemyType);

                            }

                        }
                        break;

                    default:
                        break;

                }
            }

        }

        private void clearEnemiesLists()
        {

            activeEnemies.Clear();
            inactiveEnemies.Clear();

        }

        /*private void cycleEnemyInstanciation(int levelDifficultyIndex)
        {

            switch (levelDifficultyIndex) {

                case
            foreach (var (enemyType, numberOfEnemies) in LevelDifficultyData.easyLevelData)
            {

                for (int i = 0; i < numberOfEnemies; i++)
                {

                    instantiateEnemyType(enemyType);

                }

            }

        }

        }*/

        private void instantiateEnemyType(string enemyType)
        {

            switch (enemyType)
            {

                case "Mole":
                    inactiveEnemies.Add(new Mole(_moleTexture));
                    break;
                case "Bomb":
                    inactiveEnemies.Add(new Bomb(_bombTexture));
                    break;
                case "RangerMole":
                    inactiveEnemies.Add(new RangerMole(_rangerMoleTexture));
                    break;
                default:
                    break;

            }

        }


    }

}

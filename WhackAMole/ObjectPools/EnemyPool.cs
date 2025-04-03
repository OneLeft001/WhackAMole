using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        enum easyLevel
        {
            moleEnemies = 5,
            
            
            
        }
        enum mediumLevel
        {
            moleEnemies = 5,
            bombEnemies = 6,


        }
        enum hardLevel
        {
            moleEnemies = 5,
            bombEnemies = 6,
            rangerMoleEnemies = 7
        }
        

        private void initilize() 
        {

            

            inactiveEnemies = new List<Enemy>();
            activeEnemies = new List<Enemy>();

            for (int i = 0; i < numberOfEnemies; i++) 
            {
                inactiveEnemies.Add(new Mole(_moleTexture));
                //inactiveEnemies.Add(new Bomb(_bombTexture));
                //inactiveEnemies.Add(new Enemy(_moleTexture));
                //inactiveEnemies.Add(new Enemy(_bombTexture));
                //inactiveEnemies.Add(new Enemy(_rangerMoleTexture));

            }

            initilizeEnemies();

        }

        public void loadContent(ContentManager content)
        {

            _moleTexture = content.Load<Texture2D>("Mole");
            _bombTexture = content.Load<Texture2D>("Enemy");
            _rangerMoleTexture = content.Load<Texture2D>("RangerMole");

            DifficultyLevel = 0;
            initilize();

        }

        public List<Enemy> getActiveEnemies() {  return activeEnemies; }
        public List<Enemy> getInactiveEnemies() { return inactiveEnemies; }



        private void initilizeEnemies()
        {

            switch (DifficultyLevel) 
            {
            
                case 0:// Starting level
                    //var enumVal =
                    foreach(string enemyType in Enum.GetNames(typeof(easyLevel)))
                    {
                        //var grabtype = enemyType.GetType().ToString();
                        //Debug.WriteLine(enemyType);
                        //Debug.WriteLine(grabtype);
                        
                        
                        for (int i = 0; i < 5; i++)
                        {

                            validateEnemyType(enemyType);

                        }
                    }
                    break;
                case 1:// Level Increase 1
                    clearEnemiesLists();
                    break;
                case 2:// Level Increase 2
                    break;

                default:
                    break;

            }

        }

        private void clearEnemiesLists()
        {

            activeEnemies.Clear();
            inactiveEnemies.Clear();

        }

        private void validateEnemyType(string enemyType)
        {

            switch (enemyType)
            {

                case easyLevel.moleEnemies.ToString():
                case mediumLevel.moleEnemies:
                case hardLevel.moleEnemies:
                    break;

                case mediumLevel.bombEnemies:
                case hardLevel.bombEnemies:
                    break;

                case hardLevel.rangerMoleEnemies:
                    break;

                default:
                    break;

            }

        }


    }

}

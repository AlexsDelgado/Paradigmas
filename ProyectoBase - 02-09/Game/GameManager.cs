using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameManager
    {
        private static GameManager instance;
        public Enemy currentEnemy;
        public float playerArmor;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public Level currentLevel;

        private GameManager()
        {
            ChangeLevel(LevelType.Menu);
        }

        public void ChangeLevel(LevelType levelType)
        {
            if (currentLevel != null)
            {
                currentLevel = null;
            }


            switch (levelType)
            {
                case LevelType.Menu:
                    currentLevel = new MenuLevel(Engine.GetTexture("Textures/Background.png"), LevelType.Menu);
                    break;
                case LevelType.Level1:
                    currentLevel = new GameLevel1(Engine.GetTexture("GameAssets/Pantallas/mapa1.png"), LevelType.Level1);
                    break;
                case LevelType.Level2:
                    currentLevel = new GameLevel2(Engine.GetTexture("GameAssets/Pantallas/mapa2.png"), LevelType.Level2);
                    break;
                case LevelType.FightScene:
                    currentLevel = new FightScene(Engine.GetTexture("GameAssets/Pantallas/Forest.png"), LevelType.FightScene);
                    break;
                case LevelType.WinScene:
                    currentLevel = new WinLevel(Engine.GetTexture("GameAssets/Pantallas/YouWin.png"), LevelType.WinScene);
                    break;
                case LevelType.LoseScene:
                    currentLevel = new LoseLevel(Engine.GetTexture("GameAssets/Pantallas/YouLose.png"), LevelType.LoseScene);
                    break;
            }
        }
        public void Update()
        {
            currentLevel.Update();
        }

        public void Render()
        {
            currentLevel.Render();
        }
    }
}
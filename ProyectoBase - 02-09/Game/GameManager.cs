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
        public Enemy currentEnemy ;
        public Character currentPlayer;
        public float playerArmor=0;
        public float playerBuff;
        public int coins;
        public ObjectPool<Coin> coinPool;
        public bool enemyDefeated=false;
        //0 mapa 2
        //1 shop
        //2 boss
        public int lastLevel =0;
        public int actualLevel;
        public int score;
        public List<string[]> scoreboard;
        public List<int> scoreboardList;
        public int[] scoreboardValues;
    



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
            scoreboard = new List<string[]>();
            scoreboardList = new List<int>();
            scoreboardValues = new int[3];
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
                    currentLevel = new MenuLevel(Engine.GetTexture("GameAssets/Pantallas/MenuLevel.png"), LevelType.Menu);
                    break;
                case LevelType.Level1:
                    currentLevel = new GameLevel1(Engine.GetTexture("GameAssets/Pantallas/Level1.png"), LevelType.Level1);
                    break;
                case LevelType.Level2:
                    currentLevel = new GameLevel2(Engine.GetTexture("GameAssets/Pantallas/mapa2.png"), LevelType.Level2);
                    break;
                case LevelType.Level3:
                    currentLevel = new GameLevel3(Engine.GetTexture("GameAssets/Pantallas/mapa3.png"), LevelType.Level3);
                    break;
                case LevelType.Shop:
                    currentLevel = new ShopLevel(Engine.GetTexture("GameAssets/Pantallas/mapa1.png"), LevelType.Shop);
                    break;
                case LevelType.FightScene:
                    currentLevel = new FightScene(Engine.GetTexture("GameAssets/Pantallas/Forest.png"), LevelType.FightScene);
                    break;
                case LevelType.WinScene:
                    currentLevel = new WinLevel(Engine.GetTexture("GameAssets/Pantallas/YouWin.png"), LevelType.WinScene);
                    break;
                case LevelType.LoseScene:
                    currentLevel = new LoseLevel(Engine.GetTexture("GameAssets/Pantallas/background1.png"), LevelType.LoseScene);
                    break;
                case LevelType.BossFight:
                    currentLevel = new BossFight(Engine.GetTexture("GameAssets/Pantallas/BossBackground.png"), LevelType.BossFight);
                    break;

            }
        }        
        public bool CheckCoins(int cost)
        {
            
            if (cost > coins)
            {
                Console.WriteLine("no tienes monedas suficientes");
                return false;
            }
            else
            {
                //coins -= cost;
                return true;
            }

            
        }
        public void ResetGame()
        {
            coins = 0;
            currentEnemy = null;
            playerArmor = 0;
            enemyDefeated = false;
            score = 0;
        }
        public void Update()
        {
            currentLevel.Update();
        }
        public void Render()
        {
            currentLevel.Render();
        }
        
        
        
        public void ScoreUpdate(int newScore)
        {
            score += newScore;
            Console.WriteLine($"Score actual: {score}");
        }
        public void ScoreUpdate()
        {
            //score += coins;
            Console.WriteLine($"Score Final: {score}");
            ScoreBoardUpdate();
        }
        public void ScoreBoardUpdate()
        {
            
            //String[] newScoreGG = ScoreTexture();
            //for (int i=0; i<newScoreGG.Length; i++)
            //{
            //    Console.WriteLine(newScoreGG[i]);
            //}
            scoreboardList.Add(score);
            //scoreboard.Add(newScoreGG);
        }
        public void ScoreSort()
        {
            scoreboardList.Sort((a, b) => b.CompareTo(a));
        }

         
        




    }
}
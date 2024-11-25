using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameLevel2 : Level
    {
        private PlayerController playerController;
        private Enemy badGuy;
        private TimeManager timeManager;
        private TransformData spawnPoint;
        private TransformData enemySpawn;
        private Items cartel;
        private bool enemyDefeated =false;


        public GameLevel2(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {
            spawnPoint = new TransformData(0, 0);
            spawnPoint.SetPosition(50, 50);
            enemySpawn = new TransformData(0, 0);
            enemySpawn.SetPosition(400,250);
            //Character player = new Character("Hero", "GameAssets/movimiento1.png", 100, 10, 5, 50, 50);
            //Character player = new Character("Hero", 100, 10, 5, SpawnPoint);
            //player.CreateCharacter(SpawnPoint, "GameAssets/movimiento1.png");
            Character player = GameManager.Instance.currentPlayer;
           
            playerController = new PlayerController(player);


            //badGuy = new Enemy("Bat", "GameAssets/Personajes/enemy.png", 50, 5, 2, 400, 300);
            //badGuy = new Enemy("Mavado", "GameAssets/enemigo1.png", 10, 5, 2, SpawnPointEnemy);
            if (GameManager.Instance.enemyDefeated)
            {
                Console.WriteLine("Hay enemigo");
                enemyDefeated = true;
                player.Movement(enemySpawn.PositionX, enemySpawn.PositionY);
            }
            else
            {
                player.Movement(spawnPoint.PositionX, spawnPoint.PositionY);
            }
            badGuy = new Enemy("Bat","GameAssets/Personajes/enemy.png", "GameAssets/Personajes/bat.png",50,10,20,enemySpawn);
            GameManager.Instance.currentEnemy = badGuy;
            GameManager.Instance.currentEnemy.CreateEnemy(enemySpawn, "GameAssets/Personajes/enemy.png");
            timeManager = new TimeManager();
            cartel = new Items("Cartel", "GameAssets/Assets/cartel.png", 10, 1, 1, 400, 500);

        
        }

        public override void Update()
        {
            //Console.Write(playerController.GetPlayer().GetTransform().PositionX);
            //Console.Write(",");
            //Console.WriteLine(playerController.GetPlayer().GetTransform().PositionY);

            float deltaTime = timeManager.GetDeltaTime();
            playerController.Update(deltaTime);
            Character player = playerController.GetPlayer();
            if (!enemyDefeated)
            {
                if (CollisionsUtilities.IsBoxColliding(
                      new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                      new Vector2(badGuy.GetXPos(), badGuy.GetYPos()), new Vector2(50, 50)))
                {
                    if (Engine.GetKey(Keys.E))
                    {
                        GameManager.Instance.ChangeLevel(LevelType.FightScene);
                    }
                }
            }
  

            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                 new Vector2(cartel.GetXPos(), cartel.GetYPos()), new Vector2(50, 50)))
            {
                if (Engine.GetKey(Keys.E))
                {
                    GameManager.Instance.ChangeLevel(LevelType.Level3);
                }

            }
        }

        public override void Render()
        {
            Engine.Draw(background);
            Character player = playerController.GetPlayer();
          
            Engine.Draw(cartel.GetTexture(), cartel.GetXPos(), cartel.GetYPos());

            if (!enemyDefeated)
            {
                badGuy.EnemyDraw();
                if (CollisionsUtilities.IsBoxColliding(
                     new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                     new Vector2(cartel.GetXPos(), cartel.GetYPos()), new Vector2(50, 50)))
                {
                    Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), cartel.GetXPos(), cartel.GetYPos() - 20);
                }

                if (CollisionsUtilities.IsBoxColliding(
                    new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                    new Vector2(badGuy.GetXPos(), badGuy.GetYPos()), new Vector2(50, 50)))
                {
                    Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), badGuy.GetXPos(), badGuy.GetYPos() - 20);
                    Engine.Draw(Engine.GetTexture("GameAssets/Assets/Mensaje2.png"), 0, 380);

                }
            }
           
            player.CharacterDraw();

     
        }
    }
}

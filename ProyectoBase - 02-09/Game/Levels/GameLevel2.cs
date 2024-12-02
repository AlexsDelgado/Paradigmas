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
        private Asset cartel;
        private Asset cartel2;
        private TransformData spawnCartelShop;
        private TransformData spawnCartelBoss;
        private bool enemyDefeated =false;


        public GameLevel2(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {
            spawnPoint = new TransformData(0, 0);
            spawnPoint.SetPosition(50, 50);
            enemySpawn = new TransformData(0, 0);
            enemySpawn.SetPosition(400,250);


            spawnCartelBoss = new TransformData(400, 500);
            spawnCartelShop = new TransformData(700, 250);


            Character player = GameManager.Instance.currentPlayer;

            Console.WriteLine(GameManager.Instance.lastLevel);
            switch (GameManager.Instance.lastLevel)
            {
                case 0:
                    GameManager.Instance.currentPlayer.Movement(spawnPoint.PositionX, spawnPoint.PositionY);
                    break;
                case 1:
                    GameManager.Instance.currentPlayer.Movement(spawnCartelBoss.PositionX, spawnCartelBoss.PositionY);
                    break;
                case 2:
                    GameManager.Instance.currentPlayer.Movement(spawnCartelShop.PositionX, spawnCartelShop.PositionY);
                    break;
                default:
                    
                    break;
            }


           
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
            GameManager.Instance.currentEnemy.CreateEnemy(enemySpawn, "GameAssets/Personajes/enemy.png", "GameAssets/Personajes/batIcon.png");
            timeManager = new TimeManager();

            cartel = new Asset();
            cartel2 = new Asset();
            cartel.CreateAsset(spawnCartelBoss, "GameAssets/Assets/cartel.png");
            cartel2.CreateAsset(spawnCartelShop, "GameAssets/Assets/cartel.png");
            //cartel = new Items("Cartel", "GameAssets/Assets/cartel.png", 10, 1, 1, 400, 500);
            //cartel2 = new Items("Cartel2", "GameAssets/Assets/cartel.png", 10, 1, 1, 700, 250);



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
                        GameManager.Instance.actualLevel = 0;
                        GameManager.Instance.ChangeLevel(LevelType.FightScene);
                    }
                }
            }
  

            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                 new Vector2(cartel.GetTransform().PositionX, cartel.GetTransform().PositionY), new Vector2(50, 50)))
            {
                if (Engine.GetKey(Keys.E))
                {
                    GameManager.Instance.ChangeLevel(LevelType.Level3);
                    GameManager.Instance.lastLevel = 1;
                }

            }

            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                new Vector2(cartel2.GetTransform().PositionX, cartel2.GetTransform().PositionY), new Vector2(50, 50)))
            {
                if (Engine.GetKey(Keys.E))
                {
                    GameManager.Instance.ChangeLevel(LevelType.Shop);
                    GameManager.Instance.lastLevel = 2;
                }

            }
        }

        public override void Render()
        {
            Engine.Draw(background);
            Character player = playerController.GetPlayer();

            float shopX, shopY, bossX, bossY;
            shopX = cartel2.GetTransform().PositionX;
            shopY = cartel2.GetTransform().PositionY;
            bossX = cartel.GetTransform().PositionX;
            bossY = cartel.GetTransform().PositionY;

            Engine.Draw(cartel.GetTexture(), bossX, bossY);
            Engine.Draw(cartel2.GetTexture(), shopX, shopY);
            

            if (!enemyDefeated)
            {
                badGuy.EnemyDraw();
                if (CollisionsUtilities.IsBoxColliding(
                    new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                    new Vector2(badGuy.GetXPos(), badGuy.GetYPos()), new Vector2(50, 50)))
                {
                    Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), badGuy.GetXPos(), badGuy.GetYPos() - 20);
                    Engine.Draw(Engine.GetTexture("GameAssets/Assets/Mensaje2.png"), 0, 380);

                }
            }
            if (CollisionsUtilities.IsBoxColliding(
                    new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                    new Vector2(bossX, bossY), new Vector2(50, 50)))
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), bossX, bossY- 20);
            }
            if (CollisionsUtilities.IsBoxColliding(
                 new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                 new Vector2(shopX, shopY), new Vector2(50, 50)))
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), shopX, shopY- 20);
            }

            player.CharacterDraw();

     
        }
    }
}

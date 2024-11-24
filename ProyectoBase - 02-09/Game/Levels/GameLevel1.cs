using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameLevel1 : Level
    {
        private PlayerController playerController;
        private npc john;
        private Items cartel;
        private Asset moneda;
        private Coin coins;
        private TimeManager timeManager;
        private TransformData SpawnPoint;
        private TransformData coinSpawn;

        public GameLevel1(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {


            SpawnPoint = new TransformData(0, 0);
            SpawnPoint.SetPosition(50, 50);
            coinSpawn = new TransformData(10, 300);
            //coinSpawn.SetPosition(150, 300);
            //Character player = new Character("Hero", "GameAssets/movimiento1.png", 100, 10, 5, 50, 50);
            Character player = new Character("Hero", 100, 10, 5, SpawnPoint);
            player.CreateCharacter(SpawnPoint,"GameAssets/movimiento1.png");

          //  moneda = new Asset("GameAssets/Assets/chest.png",coinSpawn,1,1);
           // moneda.CreateAsset(coinSpawn, "GameAssets/Assets/chest.png");
            coins = new Coin("GameAssets/Assets/coin.png", coinSpawn, 0.5f, 0.5f);
            coins.CreateAsset(coinSpawn, "GameAssets/Assets/coin.png");

            //spawnPoint.SetPosition(50, 50);
            //Character player = new Character("Hero", "GameAssets/movimiento1.png", 100, 10, 5, 50, 50);
            GameManager.Instance.currentPlayer = player;
            //Character player = new Character("Hero", 100, 10, 5, spawnPoint);
            //player.CreateCharacter(spawnPoint, "GameAssets/Movimiento1.png");
            playerController = new PlayerController(player);
            john = new npc("John", "GameAssets/movimiento1.png", 50, 1, 1, 400, 200);
            cartel = new Items("Cartel", "GameAssets/Assets/cartel.png", 10, 1, 1, 400, 500);
            timeManager = new TimeManager();
        }

        public override void Update()
        {
            float deltaTime = timeManager.GetDeltaTime();
            playerController.Update(deltaTime);
            Character player = playerController.GetPlayer();

            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                new Vector2(cartel.GetXPos(), cartel.GetYPos()), new Vector2(50, 50)))
            {
                if (Engine.GetKey(Keys.E))
                {
                    GameManager.Instance.ChangeLevel(LevelType.Level2);
                }
            }

            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                new Vector2(john.GetXPos(), john.GetYPos()), new Vector2(50, 50)))
            {
                if (Engine.GetKey(Keys.E))
                {
                    Engine.Debug("Ir al cartel");
                }
            }
            if (CollisionsUtilities.IsBoxColliding(
               new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
               new Vector2(coins.GetTransform().PositionX, coins.GetTransform().PositionY), new Vector2(50, 50)))
            {
                if (Engine.GetKey(Keys.E))
                {
                    coins.Interact();
                }
            }


        }

        public override void Render()
        {
            Engine.Draw(background);
            //moneda.Draw();
            coins.Draw(0.5f,0.5f);
            Character player = playerController.GetPlayer();
            player.CharacterDraw();
            //Engine.Draw(player.GetTexture(), player.GetXPos(), player.GetYPos());
            Engine.Draw(john.GetTexture(), john.GetXPos(), john.GetYPos());
            Engine.Draw(cartel.GetTexture(), cartel.GetXPos(), cartel.GetYPos());
      

            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                new Vector2(john.GetXPos(), john.GetYPos()), new Vector2(50, 50)))
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), john.GetXPos(), john.GetYPos() - 20);
            }

            if (CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
                new Vector2(cartel.GetXPos(), cartel.GetYPos()), new Vector2(50, 50)))
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), cartel.GetXPos(), cartel.GetYPos() - 20);
            }
        }
    }
}

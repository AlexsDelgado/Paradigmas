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
        private Coin coins;
        private TimeManager timeManager;
        private TransformData SpawnPoint;
        private TransformData coinSpawn;
        private float coinCD= 3;
        private float coinTimer;
       
        public GameLevel1(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {

            GameManager.Instance.coinPool = new ObjectPool<Coin>(3);
            for (int i = 0; i < 3; i++)
            {
                Coin coin = GameManager.Instance.coinPool.GetObject();
                coin.Initialize($"GameAssets/Assets/coin{i + 1}.png", new TransformData(100 * (i + 1), 430), 1.0f, 1.0f);
                coin.SetCost(i* 2+1);
                GameManager.Instance.coinPool.ReturnObject(coin);
                Console.WriteLine(coin.GetTexture());
                Console.Write(coin.GetTransform().PositionX);
                Console.WriteLine(coin.GetTransform().PositionY);
                Console.WriteLine(coin._cost);
                
            }

            SpawnPoint = new TransformData(0, 0);
            SpawnPoint.SetPosition(50, 50);
            coinSpawn = new TransformData(10, 300);

            Character player = new Character("Hero", 100, 10, 5, SpawnPoint);
            player.CreateCharacter(SpawnPoint,"GameAssets/movimiento1.png");



            //coins = new Coin("GameAssets/Assets/coin.png", coinSpawn, 0.5f, 0.5f);
            //coins.CreateAsset(coinSpawn, "GameAssets/Assets/coin.png");
            coins = GameManager.Instance.coinPool.GetObject();
            //coins.CreateAsset(coinSpawn, "GameAssets/Assets/coin.png");
            //  coins.SetCost(10);


            GameManager.Instance.currentPlayer = player;

            playerController = new PlayerController(player);
            john = new npc("John", "GameAssets/movimiento1.png", 50, 1, 1, 400, 200);
            cartel = new Items("Cartel", "GameAssets/Assets/cartel.png", 10, 1, 1, 400, 500);
            timeManager = new TimeManager();
        }

        public override void Update()
        {
            
        //    Console.WriteLine(GameManager.Instance.coinPool.GetObject().GetTransform().PositionX);
        //    Console.WriteLine(GameManager.Instance.coinPool.GetObject().GetTransform().PositionY);
            float deltaTime = timeManager.GetDeltaTime();
            coinTimer += deltaTime;
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
                //GameManager.Instance.coinPool.GetObject().Interact();
                if(coinTimer>coinCD )
                {
                    coins.Interact();
                    coinTimer = 0;
                    Coin nextCoin = GameManager.Instance.coinPool.GetObject();
                    coins = nextCoin;
                    //Random random = new Random();
                    //int randomX = random.Next(0, 750);
                    //int randomY = random.Next(0, 535);
                    //nextCoin.transform.PositionX = randomX; // Configurar la nueva posición según sea necesario
                    //nextCoin.transform.PositionY = randomY;
                }
                
            }


        }

        public override void Render()
        {
            Engine.Draw(background);
            coins.Draw();

            //GameManager.Instance.coinPool.GetObject().Draw(0.5f, 0.5f);
            Character player = playerController.GetPlayer();
            player.CharacterDraw();

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

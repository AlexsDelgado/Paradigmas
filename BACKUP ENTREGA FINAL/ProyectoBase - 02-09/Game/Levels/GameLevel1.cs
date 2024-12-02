﻿using System;
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
        private TransformData npcSpawn;
        private bool npcMsg = false;
        private float coinCD= 1f;
        private float coinTimer;
        private float msgTimer;
       
        public GameLevel1(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {

            GameManager.Instance.coinPool = new ObjectPool<Coin>(3);
            for (int i = 0; i < 3; i++)
            {
                Coin coin = GameManager.Instance.coinPool.GetObject();
                coin.Initialize($"GameAssets/Sprites/coin{i + 1}.png", new TransformData(130 * (i + 1), 150 * (i + 1)), 1.0f, 1.0f);
                coin.SetCost(i* 2+1);
                GameManager.Instance.coinPool.ReturnObject(coin);
            }

            SpawnPoint = new TransformData(543 ,88);
            npcSpawn = new TransformData(400, 200);

            Character player = new Character("Hero", 100, 10, 5, SpawnPoint);
            GameManager.Instance.currentPlayer = player;

            GameManager.Instance.currentPlayer.CreateCharacter(SpawnPoint, "GameAssets/Personajes/down.png", "GameAssets/Personajes/playerCombat.png");
            coins = GameManager.Instance.coinPool.GetObject();



            playerController = new PlayerController(GameManager.Instance.currentPlayer);
            john = new npc("John", npcSpawn);
            john.CreateCharacter("GameAssets/Personajes/vendor.png");

            cartel = new Items("Cartel", "GameAssets/Assets/cartel.png", 10, 1, 1, 400, 400);
            timeManager = new TimeManager();
        }

        public override void Update()
        {
  
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
                    npcMsg = true;

                }
            }
            if (CollisionsUtilities.IsBoxColliding(
               new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
               new Vector2(coins.GetTransform().PositionX, coins.GetTransform().PositionY), new Vector2(50, 50)))
            {
                if(coinTimer>coinCD )
                {
                    coins.Interact();
                    coinTimer = 0;
                    Coin nextCoin = GameManager.Instance.coinPool.GetObject();
                    coins = nextCoin;

                }
                
            }
           
            if (npcMsg)
            {
                msgTimer += deltaTime;
                if (msgTimer > 3)
                {
                    npcMsg = false;
                    msgTimer = 0;
                }
            }


        }

        public override void Render()
        {
            Engine.Draw(background);
            coins.Draw();

            //GameManager.Instance.coinPool.GetObject().Draw(0.5f, 0.5f);
            Character player = playerController.GetPlayer();
           
            Engine.Draw(john.GetTexture(), john.GetXPos(), john.GetYPos());
            Engine.Draw(cartel.GetTexture(), cartel.GetXPos(), cartel.GetYPos());
            player.CharacterDraw();


            if (npcMsg)
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Assets/Mensaje1.png"), john.GetXPos() - 400, john.GetYPos() + 120);
            }

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
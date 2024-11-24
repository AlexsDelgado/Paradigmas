using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameLevel3 : Level
    {
        private PlayerController playerController;
        private TimeManager timeManager;
        private TransformData SpawnPoint;
        private TransformData bossSpawn;
        private TransformData shop;

        private ItemShop item1;
        private ItemShop item2;
        private ItemShop item3;

        private Enemy boss;


        public GameLevel3(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {
        
            SpawnPoint = new TransformData(0, 0);
            SpawnPoint.SetPosition(200, 10);
            Character player = GameManager.Instance.currentPlayer;
            player.Movement(SpawnPoint.PositionX, SpawnPoint.PositionY);
            playerController = new PlayerController(player);
            timeManager = new TimeManager();


            shop = new TransformData(400, 100);
            item1 = new ItemShop(0,0);
            item1.CreateAsset(shop, "GameAssets/Assets/item1.png");
            shop.SetPosition(450,100);
            item2 = new ItemShop(1,1);
            item2.CreateAsset(shop, "GameAssets/Assets/item2.png");
            shop.SetPosition(500, 100);
            item3 = new ItemShop(0,2);
            item3.CreateAsset(shop, "GameAssets/Assets/item3.png");

            bossSpawn = new TransformData(50, 250);
            boss = new Enemy("Boss", "GameAssets/Personajes/boss.png",100,10,1,bossSpawn);
            boss.CreateEnemy(bossSpawn, "GameAssets/Personajes/boss.png");


        }

        public override void Update()
        {

            float deltaTime = timeManager.GetDeltaTime();
            playerController.Update(deltaTime);
            Character player = playerController.GetPlayer();

            CollisionCheck(player, item1);
            CollisionCheck(player, item2);
            CollisionCheck(player, item3);
            CollisionCheck(player, boss);

        }

        private void CollisionCheck(Character player, ItemShop interactable)
        {
            if (CollisionsUtilities.IsBoxColliding(
            new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
            new Vector2(interactable.GetTransform().PositionX, interactable.GetTransform().PositionY), new Vector2(50, 50)))
            {
                if (Engine.GetKey(Keys.E))
                {
                    interactable.Interact();
                }
            }
        }
        private void CollisionCheck(Character player, Enemy boss)
        {
            if (CollisionsUtilities.IsBoxColliding(
            new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
            new Vector2(boss.GetXPos(), boss.GetYPos()), new Vector2(150, 150)))
            {
                if (Engine.GetKey(Keys.E))
                {
                    GameManager.Instance.ChangeLevel(LevelType.BossFight);
                }
            }
        }



        public override void Render()
        {
            Engine.Draw(background);
            item1.Draw();
            item2.Draw();
            item3.Draw();
            boss.EnemyDraw();
            Character player = playerController.GetPlayer();
            player.CharacterDraw();
        }
    }
}

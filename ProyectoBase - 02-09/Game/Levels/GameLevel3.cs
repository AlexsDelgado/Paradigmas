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

        private Enemy boss;

        private Items cartel;

        public GameLevel3(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {

            SpawnPoint = new TransformData(0, 0);
            SpawnPoint.SetPosition(200, 10);
            Character player = GameManager.Instance.currentPlayer;
            //Entity vendor = new Entity();

            player.Movement(SpawnPoint.PositionX, SpawnPoint.PositionY);
            playerController = new PlayerController(player);
            timeManager = new TimeManager();




            bossSpawn = new TransformData(250, 250);
            boss = new Enemy("Boss", "GameAssets/Personajes/boss.png", "GameAssets/Personajes/bossCombat.png", 100,10,1,bossSpawn);
            //boss.CreateEnemy(bossSpawn, "GameAssets/Personajes/boss.png");
            GameManager.Instance.currentEnemy = boss;
            GameManager.Instance.currentEnemy.CreateEnemy(bossSpawn, "GameAssets/Personajes/boss.png", "GameAssets/Personajes/bossCombat.png");

            cartel = new Items("cartel", "GameAssets/Assets/cartel.png", 10, 1, 1, 50, 50);
        }

        public override void Update()
        {

            float deltaTime = timeManager.GetDeltaTime();
            playerController.Update(deltaTime);
            Character player = playerController.GetPlayer();

            CollisionCheck(player, boss);
            CollisionCheck(player, cartel);

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
            new Vector2(boss.GetTransform().PositionX, boss.GetTransform().PositionY), new Vector2(150, 150)))
            {
                if (Engine.GetKey(Keys.E))
                {
                    GameManager.Instance.ChangeLevel(LevelType.BossFight);
                }
            }
        }

        private void CollisionCheck(Character player, Items item)
        {
            if (CollisionsUtilities.IsBoxColliding(
            new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
            new Vector2(item.GetXPos(), item.GetYPos()), new Vector2(50, 50)))
            {
                if (Engine.GetKey(Keys.E))
                {
                    GameManager.Instance.ChangeLevel(LevelType.Level2);
                }
            }
        }



        public override void Render()
        {
            Engine.Draw(background);            
            boss.EnemyDraw();
            Character player = playerController.GetPlayer();
            player.CharacterDraw();

            Engine.Draw(cartel.GetTexture(), cartel.GetXPos(), cartel.GetYPos());
            if (CollisionsUtilities.IsBoxColliding(
            new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
            new Vector2(cartel.GetXPos(), cartel.GetYPos()), new Vector2(50, 50)))
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), cartel.GetXPos(), cartel.GetYPos() - 20);
            }

            if (CollisionsUtilities.IsBoxColliding(
            new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
             new Vector2(boss.GetTransform().PositionX, boss.GetTransform().PositionY), new Vector2(150, 250)))
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), boss.GetTransform().PositionX, boss.GetTransform().PositionY - 20);
            }
        }
    }
}

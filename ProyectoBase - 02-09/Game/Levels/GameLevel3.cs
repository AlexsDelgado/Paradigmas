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
        private List<ItemShop> items;
        ItemFactory itemFactory;


        private npc john;
        private bool colisionVendor;
        private bool anyBuy;
        private Items alfombra;
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

            anyBuy = false;
            itemFactory = new ItemFactory();
            items = itemFactory.CreateItems();

            shop = new TransformData(350,50);
            john = new npc("Merchant",shop);
            john.CreateCharacter("GameAssets/Personajes/vendor.png");

            bossSpawn = new TransformData(250, 250);
            boss = new Enemy("Boss", "GameAssets/Personajes/boss.png", "GameAssets/Personajes/bossCombat.png", 100,10,1,bossSpawn);
            //boss.CreateEnemy(bossSpawn, "GameAssets/Personajes/boss.png");
            GameManager.Instance.currentEnemy = boss;
            GameManager.Instance.currentEnemy.CreateEnemy(bossSpawn, "GameAssets/Personajes/boss.png");

          alfombra = new Items("alfombra", "GameAssets/Assets/Alfombra.png", 10, 1, 1, 395, 70);
            cartel = new Items("cartel", "GameAssets/Assets/cartel.png", 10, 1, 1, 50, 50);
        }

        public override void Update()
        {

            float deltaTime = timeManager.GetDeltaTime();
            playerController.Update(deltaTime);
            Character player = playerController.GetPlayer();

            if (items!=null)
            {
                foreach (var item in items)
                {
                    if (item !=null)
                    {

                    }
                    CollisionCheck(player, item);
                }
            }
           

            //CollisionCheck(player, item1);
            //CollisionCheck(player, item2);
            //CollisionCheck(player, item3);
            CollisionCheck(player, boss);
            CollisionCheck(player, john,itemFactory);
            CollisionCheck(player, cartel);

        }

        private void CollisionCheck(Character player, npc vendor, ItemFactory factory)
        {
            if (CollisionsUtilities.IsBoxColliding(
                 new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(40, 40),
                 new Vector2(vendor.GetTransform().PositionX, vendor.GetTransform().PositionY), new Vector2(50, 50)))
            {
              
                //Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), john.GetXPos(), john.GetYPos() - 20); ;
                colisionVendor = true;
                //if (Engine.GetKey(Keys.Num1))
                //{
                //    GameManager.Instance.CheckCoins(2);
                //    itemFactory.CreateItem(0);
                //    anyBuy = true;
                //    shopInstance = 0;
                //}
                //if (Engine.GetKey(Keys.Num2))
                //{
                //    GameManager.Instance.CheckCoins(2);
                //    itemFactory.CreateItem(1);
                //    anyBuy = true;
                //    shopInstance = 1;
                //}
                //if (Engine.GetKey(Keys.Num3))
                //{
                //    GameManager.Instance.CheckCoins(2);
                //    itemFactory.CreateItem(2);
                //    anyBuy = true;
                //    shopInstance = 2;
                //}
                if (Engine.GetKey(Keys.E))
                {
                    //compras todo
                    GameManager.Instance.CheckCoins(5);
                    //itemFactory.CreateItems();
                    anyBuy = true;
                    //shopInstance = 3;
                }

            }
            else
            {
                colisionVendor = false;
            }

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
            Engine.Draw(alfombra.GetTexture(), alfombra.GetXPos(), alfombra.GetYPos());
            john.CharacterDraw();
            if (colisionVendor)
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Assets/SHOP MENU.png"), john.GetXPos() + 40, john.GetYPos() - 10);
            }

            if(anyBuy)
            {
                foreach (var item in items)
                {
                    if (item != null) item.Draw();
                }
                //switch (shopInstance)
                //{
                //    case 0:
                //        item1 = items.Find(item => item.GetId() == shopInstance);
                //        if (item1 != default) item1.Draw();

                //        break;

                //    case 1:
                //        items.Find(item => item.GetId() == shopInstance).Draw();
                //        break;

                //    case 2:
                //        items.Find(item => item.GetId() == shopInstance).Draw();
                //        break;
                //    case 3:
                //        foreach (var item in items)
                //        {
                //            if (item != null) item.Draw();
                //        }
                //        break;
                //    default:

                //        break;

                //}

            } 
            
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

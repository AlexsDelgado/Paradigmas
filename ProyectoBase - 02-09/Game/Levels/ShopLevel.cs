using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ShopLevel : Level
    {
        private PlayerController playerController;
        private TimeManager timeManager;
        private TransformData SpawnPoint;
        private TransformData bossSpawn;
        private TransformData shop;

        private ItemShop item1;
        private ItemShop item2;
        private ItemShop item3;

        private Enemy enemy1;
        private Enemy enemy2;
        private Enemy enemy3;

        private List<ItemShop> items;
        ItemFactory itemFactory;


        private npc merchant;
        private bool colisionVendor;
        private bool anyBuy;
        private Asset alfombra;
        private Asset cartel;
        
        public ShopLevel(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {

            SpawnPoint = new TransformData(0, 0);
            SpawnPoint.SetPosition(200, 10);

            TransformData alfombraPosition;
            TransformData cartelPosition;

            alfombraPosition = new TransformData(0, 0);
            alfombraPosition.SetPosition(395, 70);

            cartelPosition = new TransformData(0, 0);
            cartelPosition.SetPosition(50, 50);

            Character player = GameManager.Instance.currentPlayer;
            player.Movement(SpawnPoint.PositionX, SpawnPoint.PositionY);
            playerController = new PlayerController(player);
            timeManager = new TimeManager();

            anyBuy = false;

            itemFactory = new ItemFactory();
            items = itemFactory.CreateItems();

            shop = new TransformData(350, 50);
            merchant = new npc("Merchant", shop);
            merchant.CreateCharacter("GameAssets/Personajes/vendor.png");

            bossSpawn = new TransformData(250, 250);
            enemy1 = new Enemy("Boss", "GameAssets/Personajes/boss.png", "GameAssets/Personajes/bossCombat.png", 100, 10, 1, bossSpawn);
            enemy1.CreateEnemy(bossSpawn, "GameAssets/Personajes/boss.png");
            GameManager.Instance.currentEnemy = enemy1;
            

            alfombra = new Asset();
            cartel = new Asset();

            alfombra.CreateAsset(alfombraPosition, "GameAssets/Assets/Alfombra.png");
            cartel.CreateAsset(cartelPosition, "GameAssets/Assets/cartel.png");

            
        }

        public override void Update()
        {

            float deltaTime = timeManager.GetDeltaTime();
            playerController.Update(deltaTime);
            Character player = playerController.GetPlayer();

            if (items != null)
            {
                foreach (var item in items)
                {
                    if (item != null)
                    {

                    }
                    CollisionCheck(player, item);
                }
            }


            //CollisionCheck(player, item1);
            //CollisionCheck(player, item2);
            //CollisionCheck(player, item3);
            CollisionCheck(player, enemy1);
            CollisionCheck(player, merchant, itemFactory);
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

        private void CollisionCheck(Character player, Asset item)
        {
            if (CollisionsUtilities.IsBoxColliding(
            new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
            new Vector2(item.GetTransform().PositionX, item.GetTransform().PositionY), new Vector2(50, 50)))
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
            cartel.Draw();
            alfombra.Draw();
            //Engine.Draw(alfombra.GetTexture(), alfombra.GetXPos(), alfombra.GetYPos());
            merchant.CharacterDraw();
            if (colisionVendor)
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Assets/SHOP MENU.png"), merchant.GetXPos() + 40, merchant.GetYPos() - 10);
            }

            if (anyBuy)
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

            enemy1.EnemyDraw();
            Character player = playerController.GetPlayer();
            player.CharacterDraw();

           
            if (CollisionsUtilities.IsBoxColliding(
            new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
            new Vector2(cartel.GetTransform().PositionX, cartel.GetTransform().PositionY), new Vector2(50, 50)))
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), cartel.GetTransform().PositionX, cartel.GetTransform().PositionY- 20);
            }

            if (CollisionsUtilities.IsBoxColliding(
            new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(20, 20),
             new Vector2(enemy1.GetTransform().PositionX, enemy1.GetTransform().PositionY), new Vector2(150, 250)))
            {
                Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), enemy1.GetTransform().PositionX, enemy1.GetTransform().PositionY - 20);
            }
        }
    }
}

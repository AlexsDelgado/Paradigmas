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
        private TransformData enemySpawn;
        private TransformData shop;

        private ItemShop item1;
        private ItemShop item2;
        private ItemShop item3;
        private int shopInstance;

        private Enemy enemy1;
        private Enemy enemy2;
        private Enemy enemy3;
        private Enemy enemy4;
        private Enemy enemy5;

        private List<(string name,string avatar,string combat, int hp, int at, int speed,TransformData transform)> enemies;


        private List<ItemShop> items;
        ItemFactory itemFactory;


        private npc merchant;
        private bool colisionVendor;
        private bool anyBuy;
        private Asset alfombra;
        private Asset cartel;
        
        public ShopLevel(Texture background, LevelType p_levelType) : base(background, p_levelType)
        {

            timeManager = new TimeManager();

            //transforms
            enemySpawn = new TransformData(250, 250);
            SpawnPoint = new TransformData(200 , 10);
            shop = new TransformData(350, 50);

            TransformData alfombraPosition;
            TransformData cartelPosition;

            alfombraPosition = new TransformData(0, 0);
            alfombraPosition.SetPosition(395, 70);

            cartelPosition = new TransformData(0, 0);
            cartelPosition.SetPosition(50, 50);

            //creacion 

            Character player = GameManager.Instance.currentPlayer;
            player.Movement(SpawnPoint.PositionX, SpawnPoint.PositionY);
            playerController = new PlayerController(player);


            merchant = new npc("Merchant", shop);
            merchant.CreateCharacter("GameAssets/Personajes/vendor.png");


            alfombra = new Asset();
            alfombra.CreateAsset(alfombraPosition, "GameAssets/Assets/Alfombra.png");

            cartel = new Asset();
            cartel.CreateAsset(cartelPosition, "GameAssets/Assets/cartel.png");

            itemFactory = new ItemFactory();
            items = itemFactory.CreateItems();

            shopInstance = -1;
            item1 = new ItemShop(0, 0);
            item2 = new ItemShop(0, 0);
            item3 = new ItemShop(0, 0);



            anyBuy = false;



            //enemigos

            enemies = new List<(string, string, string, int,int,int, TransformData)>
            {
                ("Bat", "GameAssets/Personajes/enemy.png", "GameAssets/Personajes/bat.png", 100, 10, 1, enemySpawn),
                ("Imp", "GameAssets/Personajes/enemy2.png", "GameAssets/Personajes/enemy2Combat.png", 100, 10, 1, enemySpawn),
                ("Orc", "GameAssets/Personajes/enemy3.png", "GameAssets/Personajes/enemy3Combat.png", 100, 10, 1, enemySpawn),
                ("Slime", "GameAssets/Personajes/enemy4.png", "GameAssets/Personajes/enemy4Combat.png", 100, 10, 1, enemySpawn),
                ("Minotaur", "GameAssets/Personajes/enemy5.png", "GameAssets/Personajes/enemy5Combat.png", 100, 10, 1, enemySpawn)
        };


            enemy1 = new Enemy("Bat", "GameAssets/Personajes/enemy.png", "GameAssets/Personajes/bat.png", 100, 10, 1, enemySpawn);
            enemy1.CreateEnemy(enemySpawn, "GameAssets/Personajes/enemy.png");

            enemy2 = new Enemy("Imp", "GameAssets/Personajes/enemy2.png", "GameAssets/Personajes/enemy2Combat.png", 100, 10, 1, enemySpawn);
            enemy2.CreateEnemy(enemySpawn, "GameAssets/Personajes/enemy2.png");


            enemy3 = new Enemy("Orc", "GameAssets/Personajes/enemy3.png", "GameAssets/Personajes/enemy3Combat.png", 100, 10, 1, enemySpawn);
            enemy3.CreateEnemy(enemySpawn, "GameAssets/Personajes/enemy3.png");

            enemy4 = new Enemy("Slime", "GameAssets/Personajes/enemy4.png", "GameAssets/Personajes/enemy4Combat.png", 100, 10, 1, enemySpawn);
            enemy4.CreateEnemy(enemySpawn, "GameAssets/Personajes/enemy4.png");

            enemy5 = new Enemy("Minotaur", "GameAssets/Personajes/enemy5.png", "GameAssets/Personajes/enemy5Combat.png", 100, 10, 1, enemySpawn);
            enemy5.CreateEnemy(enemySpawn, "GameAssets/Personajes/enemy5.png");

            GetEnemy();
            //GameManager.Instance.currentEnemy = enemy1;


        }
        public void GetEnemy()
        {
            Random random = new Random();
            int enemy = random.Next(0, 5);
            var enemyRandom = enemies[enemy];
            Console.WriteLine(enemy);
            Console.WriteLine(enemyRandom);
            // var itemDefinition = itemDefinitions.Find(item => item.id == id);

            if (enemies != default)
            {
                GameManager.Instance.currentEnemy = new Enemy(enemyRandom.name, enemyRandom.avatar, enemyRandom.combat, enemyRandom.hp, enemyRandom.at, enemyRandom.speed, enemyRandom.transform);

            }

            //return CreateItem(itemDefinition.id, itemDefinition.cost, itemDefinition.position, itemDefinition.texture);
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


            CollisionCheck(player, item1);
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
                //0 400 100
                //1 450 100
                //2 500 100

                if (Engine.GetKey(Keys.Num1))
                {
                    GameManager.Instance.CheckCoins(2);
                    itemFactory.CreateItem(0);
                    item1.GetTransform().SetPosition(400,100);
                    //anyBuy = true;
                    shopInstance = 0;
                }
                if (Engine.GetKey(Keys.Num2))
                {
                    GameManager.Instance.CheckCoins(2);
                    itemFactory.CreateItem(1);
                    //anyBuy = true;
                    item2.GetTransform().SetPosition(450, 100);
                    shopInstance = 1;
                }
                if (Engine.GetKey(Keys.Num3))
                {
                    GameManager.Instance.CheckCoins(2);
                    itemFactory.CreateItem(2);

                    //anyBuy = true;
                    item3.GetTransform().SetPosition(500, 100);
                    shopInstance = 2;
                }
                if (Engine.GetKey(Keys.E))
                {
                    //compras todo
                    GameManager.Instance.CheckCoins(5);
                    //itemFactory.CreateItems();
                    anyBuy = true;
                    //shopInstance = 3;
                }
                if (Engine.GetKey(Keys.F))
                {
                    GetEnemy();
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
                    GameManager.Instance.actualLevel = 2;
                    GameManager.Instance.ChangeLevel(LevelType.FightScene);
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
            if (shopInstance !=-1){
                switch (shopInstance)
                {
                    case 0:
                        item1 = items.Find(item => item.GetId() == shopInstance);
                        
                        if (item1 != default) item1.Draw();

                        break;

                    case 1:
                        items.Find(item => item.GetId() == shopInstance).Draw();
                        break;

                    case 2:
                        items.Find(item => item.GetId() == shopInstance).Draw();
                        break;
                    case 3:
                        foreach (var item in items)
                        {
                            if (item != null) item.Draw();
                        }
                        break;
                    default:

                        break;

                }
            }
            {

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
            if(GameManager.Instance.currentEnemy!=null) GameManager.Instance.currentEnemy.EnemyDraw();
           //enemy1.EnemyDraw();
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

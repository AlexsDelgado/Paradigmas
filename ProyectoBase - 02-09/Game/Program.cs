using System;
using System.Collections.Generic;
using System.Net.Configuration;

namespace Game
{
    public class GameManager
    {
        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();   
                }
                return instance;
            }
        }

        public Level currentLevel;

        private GameManager()
        {
            ChangeLevel(LevelType.Menu);
        }

        public void ChangeLevel(LevelType levelType)
        {
            if (currentLevel != null)
            {
                currentLevel = null;
            }


            switch (levelType)
            {
                case LevelType.Menu:
                    currentLevel = new MenuLevel(Engine.GetTexture("Textures/Background.png"), LevelType.Menu);
                    break;
                case LevelType.Level1:
                    currentLevel = new GameLevel1(Engine.GetTexture("GameAssets/Pantallas/mapa1.png"), LevelType.Level1);
                    break;
                case LevelType.Level2:
                    currentLevel = new GameLevel2(Engine.GetTexture("Textures/Screens/Win.png"), LevelType.Level2);
                    break;
                case LevelType.FightScene:
                    currentLevel = new FightScene(Engine.GetTexture("GameAssets/Pantallas/Forest.png"), LevelType.FightScene);
                    break;
                case LevelType.WinScene:
                    currentLevel = new WinLevel(Engine.GetTexture("GameAssets/Pantallas/YouWin.png"), LevelType.WinScene);
                    break;
                case LevelType.LoseScene:
                    currentLevel = new LoseLevel(Engine.GetTexture("GameAssets/Pantallas/YouLose.png"), LevelType.LoseScene);
                    break;
            }
        }

        public void Update()
        {
            currentLevel.Update();
        }

        public void Render()
        {
            currentLevel.Render(); 
        }
    }

    public class Program
    {
        public static float deltaTime;
        public static DateTime startTime;
        private static float lastFrameTime;
        private static float xPos;
        private static float yPos;
        private static float delayTimer;

        public static List<Entity> entidades = new List<Entity>();
        private static float movementSpeed;
        private static string texturePlayer;
        private static bool cambioTextura;
        private static string textureDirection;
        private static bool isNearJohn;
        private static Texture healthBarBackground;
        private static Texture healthBarFill;


         static void Main(string[] args)
        {
            Engine.Initialize();
            startTime = DateTime.Now;
            xPos = 0;
            yPos = 0;
            Enemy enemigo1 = new Enemy("jose","GameAssets/ship.png",10,1,1,10,10);
            Enemy enemigo2 = new Enemy("norberto","GameAssets/ship.png",10,1,1,10,50);
            entidades.Add(enemigo1);
            entidades.Add(enemigo2);
            movementSpeed = 100;
            texturePlayer = "GameAssets/ship.png";
            textureDirection = "";
            cambioTextura = false;
            float screenWidth = 800;
            float screenHeight = 600;
            float playerWidth = 20;
            float playerHeight = 20; 

            Character player = new Character("Hero", "GameAssets/movimiento1.png", 10, 1, 1, 50, 50);
            Enemy badGuy1 = new Enemy("Mavado", "GameAssets/Bad1.png", 5, 2, 2, 50, 50);
            npc John = new npc("John", "GameAssets/movimiento1.png", 10, 1, 1, 400, 200);

            healthBarBackground = Engine.GetTexture("GameAssets/Assets/barra1.png");
            healthBarFill = Engine.GetTexture("GameAssets/Assets/barra2.png");

            while (true)
            {
                
             //DeltaTime + delay
                var currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
                deltaTime = currentTime - lastFrameTime;
                lastFrameTime = currentTime;
                delayTimer += deltaTime;

                if (delayTimer>3 )
                {
                    Engine.Debug("pasaron 3 segundos delay: /n");
                    Engine.Debug(lastFrameTime);
                    delayTimer = 0;
                    foreach (var VARIABLE in entidades)
                    {
                        Engine.Debug(VARIABLE.GetName());
                    }

                }

                GameManager.Instance.Update();

                player.SetHp(player.GetHp() - 1 * deltaTime);
                if (player.GetHp() < 0) player.SetHp(0); 

                //input
                if (Engine.GetKey(Keys.S))
                {
                    yPos += movementSpeed*deltaTime;
                    cambioTextura = true;
                    player.SetYPos(yPos);
                    textureDirection = "GameAssets/movimiento1.png";

                }
                if (Engine.GetKey(Keys.W))
                {
                    yPos -= movementSpeed*deltaTime;
                    player.SetYPos(yPos);
                    cambioTextura = true;
                    textureDirection = "GameAssets/movimiento2.png";
                }
                if (Engine.GetKey(Keys.A))
                {
                    xPos -= movementSpeed*deltaTime;
                    player.SetXPos(xPos);
                    cambioTextura = true;
                    textureDirection = "GameAssets/movimiento4.png";
                }
                if (Engine.GetKey(Keys.D))
                {
                    xPos += movementSpeed*deltaTime;
                    player.SetXPos(xPos);
                    cambioTextura = true;
                    textureDirection = "GameAssets/movimiento3.png";
                }
                if (Engine.GetKey(Keys.Num1))
                {
                    GameManager.Instance.ChangeLevel(LevelType.Menu);
                }

                xPos = PositionUtilities.Clamp(xPos, 0, screenWidth - playerWidth);
                yPos = PositionUtilities.Clamp(yPos, 0, screenHeight - playerHeight);

                player.SetXPos(xPos);
                player.SetYPos(yPos);


                if (cambioTextura)
                {
                    //texturePlayer = textureDirection;
                    player.SetTexture(textureDirection);
                    cambioTextura = false;
                }
                enemigo1.Movement(100);
                enemigo2.Movement(0,-1);

                isNearJohn = CollisionsUtilities.IsBoxColliding(
                new Vector2(player.GetXPos(), player.GetYPos()), new Vector2(playerWidth, playerHeight),
                new Vector2(John.GetXPos(), John.GetYPos()), new Vector2(50, 50));


                
                if (isNearJohn && Engine.GetKey(Keys.E))
                {
                    Engine.Debug("Debes seguir tu camino");
                }

                //render
                Engine.Clear();
                GameManager.Instance.Render();
                //.Draw(texturePlayer,xPos,yPos);
                if (GameManager.Instance.currentLevel is GameLevel1)
                {
                    DrawHealthBar(player);
                    Engine.Draw(player.GetTexture(), player.GetXPos(), player.GetYPos());
                    Engine.Draw(enemigo1.GetTexture(), enemigo1.GetXPos(), enemigo1.GetYPos());
                    Engine.Draw(enemigo2.GetTexture(), enemigo2.GetYPos(), enemigo2.GetYPos());
                    Engine.Draw(John.GetTexture(), John.GetXPos(), John.GetYPos());

                    if (isNearJohn)
                    {
                        Engine.Draw(Engine.GetTexture("GameAssets/Assets/teclaE.png"), John.GetXPos(), John.GetYPos() - 20);
                    }
                }
                Engine.Show();
            }


        }

        private static void DrawHealthBar(Character player)
        {
            float maxHealth = 10;
            float currentHealth = player.GetHp();
            float healthPercentage = currentHealth / maxHealth;

            float healthBarX = 10;
            float healthBarY = 10;
            float healthBarWidth = 200;
            float healthBarHeight = 20;

            Engine.Draw(healthBarBackground, healthBarX, healthBarY, healthBarWidth / healthBarBackground.Width, healthBarHeight / healthBarBackground.Height);
            Engine.Draw(healthBarFill, healthBarX, healthBarY, (healthBarWidth * healthPercentage) / healthBarFill.Width, healthBarHeight / healthBarFill.Height);
        }

    }
}
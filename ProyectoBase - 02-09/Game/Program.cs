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

        private Level currentLevel;

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
                    currentLevel = new GameLevel1(Engine.GetTexture("Textures/Screens/Level.png"), LevelType.Level1);
                    break;
                case LevelType.Level2:
                    currentLevel = new GameLevel2(Engine.GetTexture("Textures/Screens/Win.png"), LevelType.Level2);
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

            Character player = new Character("Hero", "GameAssets/ship.png", 10, 1, 1, 50, 50);
            
            
            
            
            
            while(true)
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

                if (cambioTextura)
                {
                    //texturePlayer = textureDirection;
                    player.SetTexture(textureDirection);
                    cambioTextura = false;
                }
                enemigo1.Movement(100);
                enemigo2.Movement(0,-1);

                if (Engine.GetKey(Keys.Num1))
                {
                    GameManager.Instance.ChangeLevel(LevelType.Menu);
                }

                if (Engine.GetKey(Keys.Num2))
                {
                    GameManager.Instance.ChangeLevel(LevelType.Level1);
                }

                if (Engine.GetKey(Keys.Num3))
                {
                    GameManager.Instance.ChangeLevel(LevelType.Level2);
                }

                //render
                Engine.Clear();
                GameManager.Instance.Render();
                //.Draw(texturePlayer,xPos,yPos);
                Engine.Draw(player.GetTexture(),player.GetXPos(),player.GetYPos());
                Engine.Draw(enemigo1.GetTexture(),enemigo1.GetXPos(),enemigo1.GetYPos());
                Engine.Draw(enemigo2.GetTexture(),enemigo2.GetXPos(),enemigo2.GetYPos());
                Engine.Show();
            }
        }
    }
}
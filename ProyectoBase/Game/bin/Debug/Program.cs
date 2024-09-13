using System;
using System.Collections.Generic;

namespace Game
{
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

                
                
                //render
                Engine.Clear();
                Engine.Draw("GameAssets/location1.png",0,0);
                //.Draw(texturePlayer,xPos,yPos);
                Engine.Draw(player.GetTexture(),player.GetXPos(),player.GetYPos());
                Engine.Draw(enemigo1.GetTexture(),enemigo1.GetXPos(),enemigo1.GetYPos());
                Engine.Draw(enemigo2.GetTexture(),enemigo2.GetXPos(),enemigo2.GetYPos());
                Engine.Show();
            }
        }
    }
}
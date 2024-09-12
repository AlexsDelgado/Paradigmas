﻿using System;
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
            movementSpeed = 50;
            texturePlayer = "GameAssets/ship.png";
            cambioTextura = false;
            
            
            
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
                        Engine.Debug(VARIABLE.name);
                    }

                }
                
                //input
                if (Engine.GetKey(Keys.S))
                {
                    yPos += movementSpeed*deltaTime;
                    cambioTextura = true;

                }
                if (Engine.GetKey(Keys.W))
                {
                    yPos -= movementSpeed*deltaTime;
                    texturePlayer = "GameAssets/ship.png";
                }
                if (Engine.GetKey(Keys.A))
                {
                    xPos -= movementSpeed*deltaTime;
                }
                if (Engine.GetKey(Keys.D))
                {
                    xPos += movementSpeed*deltaTime;
                }

                if (cambioTextura)
                {
                    texturePlayer = "GameAssets/DWI.png";
                    cambioTextura = false;
                }
                enemigo1.Movement(5);
                enemigo2.Movement(1,1);

                
                
                //render
                Engine.Clear();
                Engine.Draw("GameAssets/location1.png",0,0);
                Engine.Draw(texturePlayer,xPos,yPos);
                Engine.Draw(enemigo1.texture,enemigo1.xPos,enemigo1.yPos);
                Engine.Draw(enemigo2.texture,enemigo2.xPos,enemigo2.yPos);
                Engine.Show();
                
                
            }
        }
    }
}
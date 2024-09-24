using System;
using System.Collections.Generic;
using System.Net.Configuration;

namespace Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Engine.Initialize();
            Character player = new Character("Hero", "GameAssets/movimiento1.png", 10, 1, 1, 50, 50);
            npc john = new npc("John", "GameAssets/movimiento1.png", 10, 1, 1, 400, 200);
            Enemy badGuy1 = new Enemy("Mavado", "GameAssets/enemigo1.png", 5, 2, 2, 500, 50);
            PlayerController playerController = new PlayerController(player);
            NPCController npcController = new NPCController(john);
            EnemyController enemyController = new EnemyController(badGuy1);
            TimeManager timeManager = new TimeManager();
            LevelManager levelManager = new LevelManager(playerController, npcController, enemyController);
            UIManager uiManager = new UIManager(Engine.GetTexture("GameAssets/Assets/barra1.png"), Engine.GetTexture("GameAssets/Assets/barra2.png"));

            while (true)
            {
                //UPDATE
                float deltaTime = timeManager.GetDeltaTime();
                GameManager.Instance.Update();
                playerController.Update(deltaTime);
                levelManager.UpdateLevelCollisions();

                //RENDER
                Engine.Clear();
                GameManager.Instance.Render();
                //uiManager.DrawHealthBar(player);
                Engine.Show();
            }
        }
    }
}
